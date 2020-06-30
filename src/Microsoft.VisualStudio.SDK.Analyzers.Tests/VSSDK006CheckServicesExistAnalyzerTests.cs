﻿// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using Xunit;
using Verify = CSharpCodeFixVerifier<
    Microsoft.VisualStudio.SDK.Analyzers.VSSDK006CheckServicesExistAnalyzer,
    Microsoft.VisualStudio.SDK.Analyzers.VSSDK006CheckServicesExistCodeFix>;

public class VSSDK006CheckServicesExistAnalyzerTests
{
    [Fact]
    public async Task LocalAssigned_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as Microsoft.VisualStudio.Shell.Interop.IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as Microsoft.VisualStudio.Shell.Interop.IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(8, 13, 3, (9, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalAssigned_OleInterop_QueryService_Guid_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    private void SomeMethod(Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider) {
        var svc = oleServiceProvider.QueryService(typeof(SVsBuildManagerAccessor).GUID) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    private void SomeMethod(Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider) {
        var svc = oleServiceProvider.QueryService(typeof(SVsBuildManagerAccessor).GUID) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(7, 13, 3, (8, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalAssigned_OleInterop_QueryService_Generic_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    private void SomeMethod(Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider) {
        var svc = oleServiceProvider.QueryService<SVsBuildManagerAccessor>() as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    private void SomeMethod(Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider) {
        var svc = oleServiceProvider.QueryService<SVsBuildManagerAccessor>() as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(7, 13, 3, (8, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalAssigned_GetService_ThenUsed_WithNullConditionalAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc?.BeginDesignTimeBuild();
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task LocalAssigned_IServiceProvider_GetService_ThenUsedAsync()
    {
        var test = @"
using System;
using Microsoft.VisualStudio.Shell.Interop;

class Test {
    void Initialize(IServiceProvider sp) {
        var svc = sp.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using Microsoft;
using Microsoft.VisualStudio.Shell.Interop;

class Test {
    void Initialize(IServiceProvider sp) {
        var svc = sp.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(7, 13, 3, (8, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalDeclarationAssignedWithDirectCast_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = (IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor));
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = (IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor));
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(8, 13, 3, (9, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalDeclarationAssignedWithAsCast_GetServiceAsync_ThenUsedAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        var svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        var svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(11, 13, 3, (12, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalDeclarationAssignedWithAsCast_GetService_InAsyncPackage_ThenUsedAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(11, 13, 3, (12, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalDeclarationAssignedWithAsCast_GetService_InAsyncPackage_ThenUsed_TwiceAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);

        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();

        var svc2 = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc2.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);

        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();

        var svc2 = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc2);
        svc2.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(17, 13, 4, (18, 9, 4));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalAssignedWithAsCast_GetServiceAsync_ThenUsedAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        IVsBuildManagerAccessor svc;
        svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        IVsBuildManagerAccessor svc;
        svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(12, 9, 3, (13, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task LocalAssignedWithDirectCast_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        IVsBuildManagerAccessor svc;
        svc = (IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor));
        svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        IVsBuildManagerAccessor svc;
        svc = (IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor));
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(9, 9, 3, (10, 9, 3));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        this.svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        this.svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(9, 9, 8, (10, 9, 8));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(9, 9, 8, (13, 9, 8));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task FieldAssigned_GetServiceAsync_ThenUsedElsewhereAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    IVsBuildManagerAccessor svc;
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        this.svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    IVsBuildManagerAccessor svc;
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        this.svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(12, 9, 8, (16, 9, 8));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task FieldAssigned_GetServiceAsync_WithConfigureAwait_ThenUsedElsewhereAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    IVsBuildManagerAccessor svc;
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        this.svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)).ConfigureAwait(true) as IVsBuildManagerAccessor;
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using System;
using System.Threading;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    IVsBuildManagerAccessor svc;
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        this.svc = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)).ConfigureAwait(true) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(12, 9, 8, (16, 9, 8));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereWithIfCheckAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        if (svc != null) {
            svc.BeginDesignTimeBuild();
        }
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereWithIfEqualCheckAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        if (svc == null) {
            return;
        }
        svc.BeginDesignTimeBuild();
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereWithIfIsNullCheckAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        if (svc is null) {
            return;
        }
        svc.BeginDesignTimeBuild();
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereWithIfIsObjectCheckAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        if (svc is object) {
            svc.BeginDesignTimeBuild();
        }
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task FieldAssigned_GetService_ThenUsedElsewhereWithIfIsExpectedTypeCheckAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        if (svc is IVsBuildManagerAccessor) {
            svc.BeginDesignTimeBuild();
        }
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task PropertyAssigned_GetService_ThenUsedWithinClassAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc { get; set; }
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        var fix = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc { get; set; }
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
    }

    void Foo() {
        this.svc.BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(9, 9, 8, (13, 9, 8));
        await Verify.VerifyCodeFixAsync(test, expected, fix);
    }

    [Fact]
    public async Task GetService_DirectlyUsedAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        ((IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor))).BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(8, 35, 15);
        await Verify.VerifyCodeFixAsync(test, expected, test);
    }

    [Fact]
    public async Task GetService_DirectlyUsed_WithConditionalMemberAccessAsync()
    {
        var test = @"
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        ((IVsBuildManagerAccessor)this.GetService(typeof(SVsBuildManagerAccessor)))?.BeginDesignTimeBuild();
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task GetServiceAsync_DirectlyUsedAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        ((IVsBuildManagerAccessor)await this.GetServiceAsync(typeof(SVsBuildManagerAccessor))).BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(11, 41, 20);
        await Verify.VerifyCodeFixAsync(test, expected, test);
    }

    [Fact]
    public async Task GetServiceAsync_WithConfigureAwait_DirectlyUsedAsync()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        ((IVsBuildManagerAccessor)await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)).ConfigureAwait(true)).BeginDesignTimeBuild();
    }
}
";

        DiagnosticResult expected = this.CreateDiagnostic(11, 41, 20);
        await Verify.VerifyAnalyzerAsync(test, expected);
    }

    [Fact]
    public async Task GetServiceAsync_WithConfigureAwait()
    {
        var test = @"
using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

class Test : AsyncPackage {
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        await base.InitializeAsync(cancellationToken, progress);
        var sbm = await this.GetServiceAsync(typeof(SVsBuildManagerAccessor)).ConfigureAwait(true);
    }
}
";

        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task LocalAssigned_CheckedByThrow_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";
        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task LocalAssigned_CheckedByIf_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    protected override void Initialize() {
        base.Initialize();
        var svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        if (svc != null) {
            svc.BeginDesignTimeBuild();
        }
    }
}
";
        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task FieldAssigned_Checked_GetService_ThenUsedAsync()
    {
        var test = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        this.svc = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        Assumes.Present(svc);
        svc.BeginDesignTimeBuild();
    }
}
";
        await Verify.VerifyAnalyzerAsync(test);
    }

    [Fact]
    public async Task PartialClass()
    {
        var test1 = @"
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

partial class Test : Package {
    IVsBuildManagerAccessor svc;
    protected override void Initialize() {
        base.Initialize();
        [|this.svc|] = this.GetService(typeof(SVsBuildManagerAccessor)) as IVsBuildManagerAccessor;
        svc.BeginDesignTimeBuild();
        Foo();
    }
}
";
        var test2 = @"
using System;

partial class Test {
    void Foo() {
        Console.WriteLine();
    }
}
";
        var test = new Verify.Test { TestState = { Sources = { test1, test2 } } };
        await test.RunAsync();
    }

    private DiagnosticResult CreateDiagnostic(int line, int column, int length, params (int line, int column, int length)[] additionalLocations)
    {
        DiagnosticResult diagnostic = Verify.Diagnostic().WithSpan(line, column, line, column + length);
        foreach ((int line, int column, int length) location in additionalLocations)
        {
            diagnostic = diagnostic.WithSpan(location.line, location.column, location.line, location.column + location.length);
        }

        return diagnostic;
    }
}

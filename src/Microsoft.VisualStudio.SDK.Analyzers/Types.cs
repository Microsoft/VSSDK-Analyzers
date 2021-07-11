﻿// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.VisualStudio.SDK.Analyzers
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Gets magic strings that describe types and their members.
    /// </summary>
    internal static class Types
    {
        /// <summary>
        /// Describes the <see cref="Microsoft.Assumes"/> type.
        /// </summary>
        internal static class Assumes
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Microsoft.Assumes"/> type.
            /// </summary>
            internal const string TypeName = nameof(Microsoft.Assumes);

            /// <summary>
            /// The name of the <see cref="Microsoft.Assumes.Present{T}(T)"/> method.
            /// </summary>
            internal const string Present = nameof(Microsoft.Assumes.Present);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.Microsoft;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the Microsoft.VisualStudio.OLE.Interop.IServiceProvider type.
        /// </summary>
        internal static class IOleServiceProvider
        {
            /// <summary>
            /// Gets the simple name of the Microsoft.VisualStudio.OLE.Interop.IServiceProvider type.
            /// </summary>
            internal const string TypeName = "IServiceProvider";

            /// <summary>
            /// The name of the QueryService method.
            /// </summary>
            internal const string QueryService = "QueryService";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioOLEInterop;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the System.IServiceProvider type.
        /// </summary>
        internal static class IServiceProvider
        {
            /// <summary>
            /// Gets the simple name of the System.IServiceProvider type.
            /// </summary>
            internal const string TypeName = "IServiceProvider";

            /// <summary>
            /// The name of the GetService method.
            /// </summary>
            internal const string GetService = "GetService";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.System;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.ServiceProvider"/> type.
        /// </summary>
        internal static class ServiceProvider
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.ServiceProvider"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.ServiceProvider);

            /// <summary>
            /// The name of the GetService method.
            /// </summary>
            internal const string GetService = "GetService";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.IAsyncServiceProvider"/> type.
        /// </summary>
        internal static class IAsyncServiceProvider
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.IAsyncServiceProvider"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.IAsyncServiceProvider);

            /// <summary>
            /// The name of the <see cref="Shell.IAsyncServiceProvider.GetServiceAsync"/> method.
            /// </summary>
            internal const string GetServiceAsync = nameof(Shell.IAsyncServiceProvider.GetServiceAsync);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.AsyncPackage"/> type.
        /// </summary>
        internal static class AsyncPackage
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.AsyncPackage"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.AsyncPackage);

            /// <summary>
            /// The name of the InitializeAsync method.
            /// </summary>
            internal const string InitializeAsync = "InitializeAsync";

            /// <summary>
            /// The name of the GetServiceAsync method.
            /// </summary>
            internal const string GetServiceAsync = "GetServiceAsync";

            /// <summary>
            /// The name of the GetAsyncToolWindowFactory method.
            /// </summary>
            internal const string GetAsyncToolWindowFactory = "GetAsyncToolWindowFactory";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.Package"/> type.
        /// </summary>
        internal static class Package
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.Package"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.Package);

            /// <summary>
            /// The name of the Initialize method.
            /// </summary>
            internal const string Initialize = "Initialize";

            /// <summary>
            /// The name of the GetService method.
            /// </summary>
            internal const string GetService = "GetService";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.PackageUtilities"/> type.
        /// </summary>
        internal static class PackageUtilities
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.PackageUtilities"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.PackageUtilities);

            /// <summary>
            /// The name of the QueryService method.
            /// </summary>
            internal const string QueryService = "QueryService";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="System.Threading.CancellationToken"/> type.
        /// </summary>
        internal static class CancellationToken
        {
            /// <summary>
            /// Gets the simple name of the <see cref="System.Threading.CancellationToken"/> type.
            /// </summary>
            internal const string TypeName = nameof(System.Threading.CancellationToken);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.SystemThreading;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));
        }

        /// <summary>
        /// Describes the <see cref="System.Threading.Tasks.Task"/> type.
        /// </summary>
        internal static class Task
        {
            /// <summary>
            /// Gets the simple name of the <see cref="System.Threading.Tasks.Task"/> type.
            /// </summary>
            internal const string TypeName = nameof(System.Threading.Tasks.Task);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.SystemThreadingTasks;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));
        }

        /// <summary>
        /// Describes the <see cref="Shell.ThreadHelper"/> type.
        /// </summary>
        internal static class ThreadHelper
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.ThreadHelper"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.ThreadHelper);

            /// <summary>
            /// The name of the <see cref="Shell.ThreadHelper.JoinableTaskFactory"/> property.
            /// </summary>
            internal const string JoinableTaskFactory = nameof(Shell.ThreadHelper.JoinableTaskFactory);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Threading.JoinableTaskContext"/> type.
        /// </summary>
        internal static class JoinableTaskContext
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Threading.JoinableTaskContext"/> type.
            /// </summary>
            internal const string TypeName = nameof(Threading.JoinableTaskContext);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioThreading;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Threading.JoinableTaskFactory"/> type.
        /// </summary>
        internal static class JoinableTaskFactory
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Threading.JoinableTaskFactory"/> type.
            /// </summary>
            internal const string TypeName = "JoinableTaskFactory";

            /// <summary>
            /// The name of the <see cref="JoinableTaskFactory.SwitchToMainThreadAsync"/> method.
            /// </summary>
            internal const string SwitchToMainThreadAsync = nameof(JoinableTaskFactory.SwitchToMainThreadAsync);

            /// <summary>
            /// The name of the <see cref="JoinableTaskFactory.RunAsync"/> method.
            /// </summary>
            internal const string RunAsync = "RunAsync";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioThreading;
        }

        /// <summary>
        /// Describes the <see cref="Threading.JoinableTask"/> type.
        /// </summary>
        internal static class JoinableTask
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Threading.JoinableTask"/> type.
            /// </summary>
            internal const string TypeName = "JoinableTask";

            /// <summary>
            /// The name of the <see cref="Threading.JoinableTask.Join"/> method.
            /// </summary>
            internal const string Join = "Join";

            /// <summary>
            /// The name of the <see cref="Threading.JoinableTask.JoinAsync"/> method.
            /// </summary>
            internal const string JoinAsync = "JoinAsync";
        }

        /// <summary>
        /// Describes the <see cref="System.IProgress{T}"/> type.
        /// </summary>
        internal static class IProgress
        {
            /// <summary>
            /// Gets the simple name of the <see cref="System.IProgress{T}"/> type.
            /// </summary>
            internal const string TypeName = nameof(System.IProgress<int>);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.System;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            /// <param name="typeArgument">The type argument for the <see cref="System.IProgress{T}"/> type.</param>
            /// <returns>The type syntax.</returns>
            internal static TypeSyntax TypeSyntaxOf(TypeSyntax typeArgument)
            {
                return Utils.QualifyName(
                    Namespace,
                    SyntaxFactory.GenericName(TypeName).AddTypeArgumentListArguments(typeArgument));
            }
        }

        /// <summary>
        /// Describes the <see cref="Shell.ServiceProgressData"/> type.
        /// </summary>
        internal static class ServiceProgressData
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.ServiceProgressData"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.ServiceProgressData);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));
        }

        /// <summary>
        /// Describes the <see cref="Shell.PackageRegistrationAttribute"/> type.
        /// </summary>
        internal static class PackageRegistrationAttribute
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.PackageRegistrationAttribute"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.PackageRegistrationAttribute);

            /// <summary>
            /// Gets the name of the <see cref="Shell.PackageRegistrationAttribute.AllowsBackgroundLoading"/> property.
            /// </summary>
            internal const string AllowsBackgroundLoading = nameof(Shell.PackageRegistrationAttribute.AllowsBackgroundLoading);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.ProvideToolWindowAttribute"/> type.
        /// </summary>
        internal static class ProvideToolWindowAttribute
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.ProvideToolWindowAttribute"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.ProvideToolWindowAttribute);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.ProvideAutoLoadAttribute"/> type.
        /// </summary>
        internal static class ProvideAutoLoadAttribute
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.ProvideAutoLoadAttribute"/> type.
            /// </summary>
            internal const string TypeName = nameof(Shell.ProvideAutoLoadAttribute);

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }

        /// <summary>
        /// Describes the <see cref="Shell.PackageAutoLoadFlags"/> type.
        /// </summary>
        internal static class PackageAutoLoadFlags
        {
            /// <summary>
            /// Gets the simple name of the <see cref="Shell.PackageAutoLoadFlags"/> type.
            /// </summary>
            internal const string TypeName = "PackageAutoLoadFlags";

            /// <summary>
            /// Gets an array of the nesting namespaces for this type.
            /// </summary>
            internal static readonly IReadOnlyList<string> Namespace = Namespaces.MicrosoftVisualStudioShell;

            /// <summary>
            /// Copy of auto load flag values from <see cref="Shell.PackageAutoLoadFlags"/>.
            /// </summary>
            internal enum Values
            {
                /// <summary>
                /// Indicates synchronous load in all versions of Visual Studio.
                /// </summary>
                None = 0,

                /// <summary>
                /// Indicates auto load request should be ignored when Visual Studio has UIContextRules feature.
                /// </summary>
                SkipWhenUIContextRulesActive = 1,

                /// <summary>
                /// Indicates auto load should be requested asynchronously.
                /// </summary>
                BackgroundLoad = 2,
            }

            /// <summary>
            /// Gets the <see cref="Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax"/> for this type.
            /// </summary>
            internal static TypeSyntax TypeSyntax { get; } = Utils.QualifyName(Namespace, SyntaxFactory.IdentifierName(TypeName));

            /// <summary>
            /// Gets the fully-qualified name of this type as a string.
            /// </summary>
            internal static string FullName { get; } = string.Join(".", Namespace) + "." + TypeName;
        }
    }
}

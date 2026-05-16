#if !NET5_0_OR_GREATER

#pragma warning disable IDE0001
#pragma warning disable IDE0002
#pragma warning disable IDE0130

// ReSharper disable CheckNamespace
// ReSharper disable RedundantAttributeUsageProperty

namespace System.Runtime.CompilerServices;

/// <summary>
/// An attribute that allows parameters to receive the expression of other parameters.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
[Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
internal sealed class CallerArgumentExpressionAttribute : Attribute {

    /// <summary>
    /// Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute"/> class.
    /// </summary>
    /// <param name="parameterName">The condition parameter value.</param>
    public CallerArgumentExpressionAttribute(string parameterName) {
        ParameterName = parameterName;
    }

    /// <summary>
    /// Gets the parameter name the expression is retrieved from.
    /// </summary>
    public string ParameterName { get; }

}

#endif
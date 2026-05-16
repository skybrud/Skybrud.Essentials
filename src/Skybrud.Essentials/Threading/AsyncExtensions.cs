using System;
using System.Threading.Tasks;

namespace Skybrud.Essentials.Threading;

/// <summary>
/// Static class with various extension methods for working with asynchronous code.
/// </summary>
public static class AsyncExtensions {

    /// <summary>
    /// Asynchronously continues the task with the specified function. Useful for chaining multiple asynchronous operations together.
    /// </summary>
    /// <typeparam name="TInput">The type of the input task.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the next function.</typeparam>
    /// <param name="task">The input task,</param>
    /// <param name="next">The function to execute after the input task completes.</param>
    /// <returns>A task representing the result of the next function.</returns>
    public static async Task<TResult> Then<TInput, TResult>(this Task<TInput> task, Func<TInput, Task<TResult>> next) {
        TInput result = await task;
        return await next(result);
    }

    /// <summary>
    /// Synchronously continues the task with the specified function. Useful when the last function in an asynchronous method chain is not asynchronous.
    /// </summary>
    /// <typeparam name="TInput">The type of the input task</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the next function,</typeparam>
    /// <param name="task">The input task,</param>
    /// <param name="next">The function to execute after the input task completes.</param>
    /// <returns>A task representing the result of the next function.</returns>
    public static async Task<TResult> Then<TInput, TResult>(this Task<TInput> task, Func<TInput, TResult> next) {
        TInput result = await task;
        TResult? nextResult = next(result);
        return nextResult;
    }

}
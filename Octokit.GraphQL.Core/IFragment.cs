﻿using System;
using System.Linq.Expressions;

namespace Octokit.GraphQL
{
    /// <summary>
    /// Represents a GraphQL fragment.
    /// </summary>
    /// <see cref="Fragment{TInput, TOutput}"/>.
    public interface IFragment
    {
        /// <summary>
        /// Gets the name of a fragment.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the selector expression.
        /// </summary>
        Expression Expression { get; }

        /// <summary>
        /// Gets the input type of the fragment.
        /// </summary>
        Type InputType { get; }

        /// <summary>
        /// Gets the output type of the fragment.
        /// </summary>
        Type ReturnType { get; }
    }

    public interface IFragment<TInput, out TResult> : IFragment
    {
    }
}

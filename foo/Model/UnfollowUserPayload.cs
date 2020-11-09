namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of UnfollowUser
    /// </summary>
    public class UnfollowUserPayload : QueryableValue<UnfollowUserPayload>
    {
        internal UnfollowUserPayload(Expression expression) : base(expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The user that was unfollowed.
        /// </summary>
        public User User => this.CreateProperty(x => x.User, Octokit.GraphQL.Model.User.Create);

        internal static UnfollowUserPayload Create(Expression expression)
        {
            return new UnfollowUserPayload(expression);
        }
    }
}
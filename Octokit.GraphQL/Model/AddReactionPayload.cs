namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of AddReaction
    /// </summary>
    public class AddReactionPayload : QueryableValue<AddReactionPayload>
    {
        internal AddReactionPayload(Expression expression) : base(expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The reaction object.
        /// **Upcoming Change on 2019-01-01 UTC**
        /// **Description:** Type for `reaction` will change from `Reaction!` to `Reaction`.
        /// **Reason:** In preparation for an upcoming change to the way we report mutation errors, non-nullable payload fields are becoming nullable.
        /// </summary>
        public Reaction Reaction => this.CreateProperty(x => x.Reaction, Octokit.GraphQL.Model.Reaction.Create);

        /// <summary>
        /// The reactable subject.
        /// **Upcoming Change on 2019-01-01 UTC**
        /// **Description:** Type for `subject` will change from `Reactable!` to `Reactable`.
        /// **Reason:** In preparation for an upcoming change to the way we report mutation errors, non-nullable payload fields are becoming nullable.
        /// </summary>
        public IReactable Subject => this.CreateProperty(x => x.Subject, Octokit.GraphQL.Model.Internal.StubIReactable.Create);

        internal static AddReactionPayload Create(Expression expression)
        {
            return new AddReactionPayload(expression);
        }
    }
}
namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of MoveProjectCard
    /// </summary>
    public class MoveProjectCardInput
    {
        /// <summary>
        /// The id of the card to move.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// The id of the column to move it into.
        /// </summary>
        public string ColumnId { get; set; }

        /// <summary>
        /// Place the new card after the card with this id. Pass null to place it at the top.
        /// </summary>
        public string AfterCardId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of DeleteIssue
    /// </summary>
    public class DeleteIssueInput
    {
        /// <summary>
        /// The ID of the issue to delete.
        /// </summary>
        public string IssueId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
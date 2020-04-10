namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UnarchiveRepository
    /// </summary>
    public class UnarchiveRepositoryInput
    {
        /// <summary>
        /// The ID of the repository to unarchive.
        /// </summary>
        public string RepositoryId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
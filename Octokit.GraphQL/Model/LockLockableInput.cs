namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Autogenerated input type of LockLockable
    /// </summary>
    public class LockLockableInput
    {
        /// <summary>
        /// ID of the issue or pull request to be locked.
        /// </summary>
        public ID LockableId { get; set; }

        /// <summary>
        /// A reason for why the issue or pull request will be locked.
        /// </summary>
        public LockReason? LockReason { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
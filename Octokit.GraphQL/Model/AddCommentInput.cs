namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of AddComment
    /// </summary>
    public class AddCommentInput
    {
        /// <summary>
        /// The Node ID of the subject to modify.
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// The contents of the comment.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
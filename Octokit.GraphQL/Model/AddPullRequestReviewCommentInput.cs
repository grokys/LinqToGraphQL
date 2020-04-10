namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of AddPullRequestReviewComment
    /// </summary>
    public class AddPullRequestReviewCommentInput
    {
        /// <summary>
        /// The node ID of the pull request reviewing
        /// </summary>
        public string PullRequestId { get; set; }

        /// <summary>
        /// The Node ID of the review to modify.
        /// </summary>
        public string PullRequestReviewId { get; set; }

        /// <summary>
        /// The SHA of the commit to comment on.
        /// </summary>
        public string CommitOID { get; set; }

        /// <summary>
        /// The text of the comment.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The relative path of the file to comment on.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The line index in the diff to comment on.
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// The comment id to reply to.
        /// </summary>
        public string InReplyTo { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
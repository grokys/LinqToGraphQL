namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of RequestReviews
    /// </summary>
    public class RequestReviewsPayload : QueryableValue<RequestReviewsPayload>
    {
        public RequestReviewsPayload(Expression expression) : base(expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The pull request that is getting requests.
        /// **Upcoming Change on 2019-01-01 UTC**
        /// **Description:** Type for `pullRequest` will change from `PullRequest!` to `PullRequest`.
        /// **Reason:** In preparation for an upcoming change to the way we report mutation errors, non-nullable payload fields are becoming nullable.
        /// </summary>
        public PullRequest PullRequest => this.CreateProperty(x => x.PullRequest, Octokit.GraphQL.Model.PullRequest.Create);

        /// <summary>
        /// The edge from the pull request to the requested reviewers.
        /// **Upcoming Change on 2019-01-01 UTC**
        /// **Description:** Type for `requestedReviewersEdge` will change from `UserEdge!` to `UserEdge`.
        /// **Reason:** In preparation for an upcoming change to the way we report mutation errors, non-nullable payload fields are becoming nullable.
        /// </summary>
        public UserEdge RequestedReviewersEdge => this.CreateProperty(x => x.RequestedReviewersEdge, Octokit.GraphQL.Model.UserEdge.Create);

        internal static RequestReviewsPayload Create(Expression expression)
        {
            return new RequestReviewsPayload(expression);
        }
    }
}
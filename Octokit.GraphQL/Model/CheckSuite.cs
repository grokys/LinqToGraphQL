namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// A check suite.
    /// </summary>
    public class CheckSuite : QueryableValue<CheckSuite>
    {
        public CheckSuite(Expression expression) : base(expression)
        {
        }

        /// <summary>
        /// The GitHub App which created this check suite.
        /// </summary>
        public App App => this.CreateProperty(x => x.App, Octokit.GraphQL.Model.App.Create);

        /// <summary>
        /// The name of the branch for this check suite.
        /// </summary>
        public Ref Branch => this.CreateProperty(x => x.Branch, Octokit.GraphQL.Model.Ref.Create);

        /// <summary>
        /// The check runs associated with a check suite.
        /// </summary>
        /// <param name="after">Returns the elements in the list that come after the specified cursor.</param>
        /// <param name="before">Returns the elements in the list that come before the specified cursor.</param>
        /// <param name="first">Returns the first _n_ elements from the list.</param>
        /// <param name="last">Returns the last _n_ elements from the list.</param>
        /// <param name="filterBy">Filters the check runs by this type.</param>
        public CheckRunConnection CheckRuns(Arg<string>? after = null, Arg<string>? before = null, Arg<int>? first = null, Arg<int>? last = null, Arg<CheckRunFilter>? filterBy = null) => this.CreateMethodCall(x => x.CheckRuns(after, before, first, last, filterBy), Octokit.GraphQL.Model.CheckRunConnection.Create);

        /// <summary>
        /// The commit for this check suite
        /// </summary>
        public Commit Commit => this.CreateProperty(x => x.Commit, Octokit.GraphQL.Model.Commit.Create);

        /// <summary>
        /// The conclusion of this check suite.
        /// </summary>
        public CheckConclusionState? Conclusion { get; }

        /// <summary>
        /// Identifies the date and time when the object was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Identifies the primary key from the database.
        /// </summary>
        public int? DatabaseId { get; }

        public ID Id { get; }

        /// <summary>
        /// A list of open pull requests matching the check suite.
        /// </summary>
        /// <param name="states">A list of states to filter the pull requests by.</param>
        /// <param name="labels">A list of label names to filter the pull requests by.</param>
        /// <param name="headRefName">The head ref name to filter the pull requests by.</param>
        /// <param name="baseRefName">The base ref name to filter the pull requests by.</param>
        /// <param name="orderBy">Ordering options for pull requests returned from the connection.</param>
        /// <param name="after">Returns the elements in the list that come after the specified cursor.</param>
        /// <param name="before">Returns the elements in the list that come before the specified cursor.</param>
        /// <param name="first">Returns the first _n_ elements from the list.</param>
        /// <param name="last">Returns the last _n_ elements from the list.</param>
        public PullRequestConnection MatchingPullRequests(Arg<IEnumerable<PullRequestState>>? states = null, Arg<IEnumerable<string>>? labels = null, Arg<string>? headRefName = null, Arg<string>? baseRefName = null, Arg<IssueOrder>? orderBy = null, Arg<string>? after = null, Arg<string>? before = null, Arg<int>? first = null, Arg<int>? last = null) => this.CreateMethodCall(x => x.MatchingPullRequests(states, labels, headRefName, baseRefName, orderBy, after, before, first, last), Octokit.GraphQL.Model.PullRequestConnection.Create);

        /// <summary>
        /// The push that triggered this check suite.
        /// </summary>
        public Push Push => this.CreateProperty(x => x.Push, Octokit.GraphQL.Model.Push.Create);

        /// <summary>
        /// The repository associated with this check suite.
        /// </summary>
        public Repository Repository => this.CreateProperty(x => x.Repository, Octokit.GraphQL.Model.Repository.Create);

        /// <summary>
        /// The status of this check suite.
        /// </summary>
        public CheckStatusState Status { get; }

        /// <summary>
        /// Identifies the date and time when the object was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; }

        internal static CheckSuite Create(Expression expression)
        {
            return new CheckSuite(expression);
        }
    }
}
namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of CreateBranchProtectionRule
    /// </summary>
    public class CreateBranchProtectionRuleInput
    {
        /// <summary>
        /// The global relay id of the repository in which a new branch protection rule should be created in.
        /// </summary>
        public ID RepositoryId { get; set; }

        /// <summary>
        /// The glob-like pattern used to determine matching branches.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Are approving reviews required to update matching branches.
        /// </summary>
        public bool? RequiresApprovingReviews { get; set; }

        /// <summary>
        /// Number of approving reviews required to update matching branches.
        /// </summary>
        public int? RequiredApprovingReviewCount { get; set; }

        /// <summary>
        /// Are commits required to be signed.
        /// </summary>
        public bool? RequiresCommitSignatures { get; set; }

        /// <summary>
        /// Can admins overwrite branch protection.
        /// </summary>
        public bool? IsAdminEnforced { get; set; }

        /// <summary>
        /// Are status checks required to update matching branches.
        /// </summary>
        public bool? RequiresStatusChecks { get; set; }

        /// <summary>
        /// Are branches required to be up to date before merging.
        /// </summary>
        public bool? RequiresStrictStatusChecks { get; set; }

        /// <summary>
        /// Are reviews from code owners required to update matching branches.
        /// </summary>
        public bool? RequiresCodeOwnerReviews { get; set; }

        /// <summary>
        /// Will new commits pushed to matching branches dismiss pull request review approvals.
        /// </summary>
        public bool? DismissesStaleReviews { get; set; }

        /// <summary>
        /// Is dismissal of pull request reviews restricted.
        /// </summary>
        public bool? RestrictsReviewDismissals { get; set; }

        /// <summary>
        /// A list of User or Team IDs allowed to dismiss reviews on pull requests targeting matching branches.
        /// </summary>
        public IEnumerable<ID> ReviewDismissalActorIds { get; set; }

        /// <summary>
        /// Is pushing to matching branches restricted.
        /// </summary>
        public bool? RestrictsPushes { get; set; }

        /// <summary>
        /// A list of User, Team or App IDs allowed to push to matching branches.
        /// </summary>
        public IEnumerable<ID> PushActorIds { get; set; }

        /// <summary>
        /// List of required status check contexts that must pass for commits to be accepted to matching branches.
        /// </summary>
        public IEnumerable<string> RequiredStatusCheckContexts { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of CreateCheckSuite
    /// </summary>
    public class CreateCheckSuiteInput
    {
        public ID RepositoryId { get; set; }

        public string HeadSha { get; set; }

        public string ClientMutationId { get; set; }
    }
}
namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of UpdateEnterpriseAllowPrivateRepositoryForkingSetting
    /// </summary>
    public class UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload : QueryableValue<UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload>
    {
        internal UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload(Expression expression) : base(expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The enterprise with the updated allow private repository forking setting.
        /// </summary>
        public Enterprise Enterprise => this.CreateProperty(x => x.Enterprise, Octokit.GraphQL.Model.Enterprise.Create);

        /// <summary>
        /// A message confirming the result of updating the allow private repository forking setting.
        /// </summary>
        public string Message { get; }

        internal static UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload Create(Expression expression)
        {
            return new UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload(expression);
        }
    }
}
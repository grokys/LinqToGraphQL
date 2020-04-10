namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateEnterpriseMembersCanInviteCollaboratorsSetting
    /// </summary>
    public class UpdateEnterpriseMembersCanInviteCollaboratorsSettingInput
    {
        /// <summary>
        /// The ID of the enterprise on which to set the members can invite collaborators setting.
        /// </summary>
        public string EnterpriseId { get; set; }

        /// <summary>
        /// The value for the members can invite collaborators setting on the enterprise.
        /// </summary>
        public EnterpriseEnabledDisabledSettingValue SettingValue { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}
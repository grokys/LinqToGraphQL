namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Model;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Things that can be starred.
    /// </summary>
    public interface IStarrable : IQueryableValue<IStarrable>, IQueryableInterface
    {
        ID Id { get; }

        /// <summary>
        /// A list of users who have starred this starrable.
        /// </summary>
        /// <param name="after">Returns the elements in the list that come after the specified cursor.</param>
        /// <param name="before">Returns the elements in the list that come before the specified cursor.</param>
        /// <param name="first">Returns the first _n_ elements from the list.</param>
        /// <param name="last">Returns the last _n_ elements from the list.</param>
        /// <param name="orderBy">Order for connection</param>
        StargazerConnection Stargazers(Arg<string>? after = null, Arg<string>? before = null, Arg<int>? first = null, Arg<int>? last = null, Arg<StarOrder>? orderBy = null);

        /// <summary>
        /// Returns a boolean indicating whether the viewing user has starred this starrable.
        /// </summary>
        bool ViewerHasStarred { get; }
    }
}

namespace Octokit.GraphQL.Model.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    internal class StubIStarrable : QueryableValue<StubIStarrable>, IStarrable
    {
        public StubIStarrable(Expression expression) : base(expression)
        {
        }

        public ID Id { get; }

        public StargazerConnection Stargazers(Arg<string>? after = null, Arg<string>? before = null, Arg<int>? first = null, Arg<int>? last = null, Arg<StarOrder>? orderBy = null) => this.CreateMethodCall(x => x.Stargazers(after, before, first, last, orderBy), Octokit.GraphQL.Model.StargazerConnection.Create);

        public bool ViewerHasStarred { get; }

        internal static StubIStarrable Create(Expression expression)
        {
            return new StubIStarrable(expression);
        }
    }
}
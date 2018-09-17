using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit.GraphQL.Core;
using Octokit.GraphQL.IntegrationTests.Utilities;
using Octokit.GraphQL.Model;
using Xunit;
using static Octokit.GraphQL.Variable;

namespace Octokit.GraphQL.IntegrationTests.Queries
{
    public class RepositoryTests : IntegrationTestBase
    {
        [IntegrationTest]
        public async Task Should_Query_All_RepositoryOwner_Repositories()
        {
            var query = new Query().RepositoryOwner("octokit").Repositories(first: 30).Nodes.Select(repository => repository.Name);

            var repositoryNames = (await Connection.Run(query)).ToArray();

            Assert.Contains("discussions", repositoryNames);
            Assert.Contains("octokit.net", repositoryNames);
            Assert.Contains("octokit.rb", repositoryNames);
            Assert.Contains("octokit.objc", repositoryNames);
            Assert.Contains("go-octokit", repositoryNames);
        }

        [IntegrationTest]
        public async Task Should_Run_Readme_Query()
        {
            var query = new Query()
                .RepositoryOwner(Var("owner"))
                .Repository(Var("name"))
                .Select(repo => new
                {
                    repo.Id,
                    repo.Name,
                    repo.Owner.Login,
                    repo.IsFork,
                    repo.IsPrivate,
                }).Compile();

            var vars = new Dictionary<string, object>
            {
                { "owner", "octokit" },
                { "name", "octokit.graphql.net" },
            };

            var result = Connection.Run(query, vars).Result;
            Assert.Equal(result.Login, "octokit");
            Assert.Equal(result.Name, "octokit.graphql.net");
        }

        [IntegrationTest]
        public async Task Should_Query_Repository_ByName()
        {
            var query = new Query().Repository("octokit", "octokit.net").Select(r => new
            {
                r.Name,
                r.DatabaseId,
            });

            var repository = await Connection.Run(query);

            Assert.NotNull(repository);
            Assert.Equal(repository.Name, "octokit.net");
            Assert.Equal(repository.DatabaseId, 7528679);
        }

        [IntegrationTest]
        public async Task Should_QueryRepositoryOwner_Repositories_OrderBy_Name_Ascending()
        {
            var query = new Query().RepositoryOwner("octokit").Repositories(first: 30, orderBy: new RepositoryOrder
            {
                Direction = OrderDirection.Asc,
                Field = RepositoryOrderField.Name
            }).Nodes.Select(repository => repository.Name);

            var repositoryNames = (await Connection.Run(query)).ToArray();

            Assert.Contains("discussions", repositoryNames);
            Assert.Contains("go-octokit", repositoryNames);
            Assert.Contains("octokit.net", repositoryNames);
            Assert.Contains("octokit.objc", repositoryNames);
            Assert.Contains("octokit.rb", repositoryNames);
        }

        [IntegrationTest]
        public async Task Should_QueryRepositoryOwner_Repositories_OrderBy_CreatedAt_Descending()
        {
            var query = new Query().RepositoryOwner("octokit").Repositories(first: 30, orderBy: new RepositoryOrder
            {
                Direction = OrderDirection.Asc,
                Field = RepositoryOrderField.CreatedAt
            }).Nodes.Select(repository => repository.Name);

            var repositoryNames = (await Connection.Run(query)).ToArray();

            Assert.Contains("octokit.rb", repositoryNames);
            Assert.Contains("octokit.net", repositoryNames);
            Assert.Contains("octokit.objc", repositoryNames);
            Assert.Contains("go-octokit", repositoryNames);
            Assert.Contains("discussions", repositoryNames);
        }

        [IntegrationTest]
        public async Task Should_Query_Repository_With_Variables()
        {
            var query = new Query()
                .Repository(Var("owner"), Var("name"))
                .Select(repository => repository.Name)
                .Compile();
            var vars = new Dictionary<string, object>
            {
                { "owner", "octokit" },
                { "name", "octokit.net" },
            };

            var repositoryName = await Connection.Run(query, vars);

            Assert.Equal("octokit.net", repositoryName);
        }

        [IntegrationTest]
        public async Task Query_Repository_Select_Simple_Fragment()
        {
            var fragment = new Fragment<Model.Repository, string>("repositoryName", repo => repo.Name);

            var query = new Query()
                .Repository("octokit", "octokit.net")
                .Select(fragment);

            var repositoryName = await Connection.Run(query);

            Assert.Equal("octokit.net", repositoryName);
        }

        [IntegrationTest]
        public async Task Query_Repository_Select_Inner_Simple_Fragment()
        {
            var fragment = new Fragment<Model.Repository, string>("repositoryName", repo => repo.Name);

            var query = new Query()
                .Select(q => new
                {
                    Name = q.Repository("octokit", "octokit.net").Select(fragment).SingleOrDefault()
                });


            var repository = await Connection.Run(query);

            Assert.Equal("octokit.net", repository.Name);
        }

        [IntegrationTest]
        public async Task Query_Organization_Repositories_Select_Simple_Fragment()
        {
            var fragment = new Fragment<Model.Repository, string>("repositoryName", repo => repo.Name);

            var query = new Query()
                .Organization("octokit")
                .Repositories(first: 100)
                .Nodes
                .Select(fragment);

            var repositoryName = (await Connection.Run(query)).OrderByDescending(s => s).First();

            Assert.Equal("webhooks.js", repositoryName);
        }

        [IntegrationTest]
        public async Task Query_Repository_Select_Object_Fragment()
        {
            var fragment = new Fragment<Model.Repository, TestModelObject>("repositoryName", repo => new TestModelObject
            {
                IntField1 = repo.ForkCount,
                StringField1 = repo.Name,
                StringField2 = repo.Description
            });

            var query = new Query()
                .Repository("octokit", "octokit.net")
                .Select(fragment);

            var testModelObject = await Connection.Run(query);

            Assert.Equal("octokit.net", testModelObject.StringField1);
        }

        [IntegrationTest]
        public async Task Query_Repository_Select_Object_Fragment_Twice()
        {
            var fragment = new Fragment<Model.Repository, TestModelObject>("repositoryName", repo => new TestModelObject
            {
                IntField1 = repo.ForkCount,
                StringField1 = repo.Name,
                StringField2 = repo.Description
            });

            var query = new Query()
                .Select(q => new
                {
                    repo1 = q.Repository("octokit", "octokit.net").Select(fragment).Single(),
                    repo2 = q.Repository("octokit", "octokit.graphql.net").Select(fragment).Single(),
                });

            var result = await Connection.Run(query);

            Assert.Equal("octokit.net", result.repo1.StringField1);
            Assert.Equal("octokit.graphql.net", result.repo2.StringField1);
        }

        [IntegrationTest]
        public async Task Query_Repository_Select_Inner_Object_Fragment()
        {
            var fragment = new Fragment<Model.Repository, TestModelObject>("repositoryName", repo => new TestModelObject
            {
                IntField1 = repo.ForkCount,
                StringField1 = repo.Name,
                StringField2 = repo.Description
            });

            var query = new Query()
                .Select(q => new
                {
                    TestModel = q.Repository("octokit", "octokit.net").Select(fragment).SingleOrDefault()
                });


            var result = await Connection.Run(query);

            Assert.Equal("octokit.net", result.TestModel.StringField1);
        }

        [IntegrationTest]
        public async Task Query_Organization_Repositories_Select_Object_Fragment()
        {
            var fragment = new Fragment<Model.Repository, TestModelObject>("repositoryName", repo => new TestModelObject
            {
                IntField1 = repo.ForkCount,
                StringField1 = repo.Name,
                StringField2 = repo.Description
            });

            var query = new Query()
                .Organization("octokit")
                .Repositories(first: 100)
                .Nodes
                .Select(fragment);

            var testModelObject = (await Connection.Run(query)).OrderByDescending(s => s.StringField1).First();

            Assert.Equal("webhooks.js", testModelObject.StringField1);
        }

        [IntegrationTest]
        public async Task Query_Organization_Repositories_Select_Multiple_Object_Fragments()
        {
            var fragment = new Fragment<Model.User, TestModelObject>("repositoryName", repo => new TestModelObject
            {
                StringField1 = repo.Login,
                StringField2 = repo.Url
            });

            var query = new Query().Organization("octokit")
                .Select(organization => new
                {
                    Member = organization.Members(10, null, null, null).Nodes
                        .Select(fragment).ToList().OrderBy(o => o.StringField1).First(),

                    MentionableUser = organization.Repository("octokit.net")
                        .MentionableUsers(10, null, null, null).Nodes
                        .Select(fragment).ToList().OrderBy(o => o.StringField1).First()
                });

            var testModelObject = await Connection.Run(query);
            Assert.Equal("alanjrogers", testModelObject.Member.StringField1);
            Assert.Equal("bkeepers", testModelObject.MentionableUser.StringField1);
        }

        [IntegrationTest]
        public async Task Should_Query_Repository_Issues_PullRequests_With_Variables_AutoPaging()
        {
            var query = new Query()
                .Repository(Var("owner"), Var("name"))
                .Select(repository => new
                {
                    Issues = repository.Issues(null, null, null, null, null, null, null).AllPages().Select(issue => issue.Title).ToList(),
                    PullRequests = repository.PullRequests(null, null, null, null, null, null, null, null, null).AllPages().Select(issue => issue.Title).ToList(),
                })
                .Compile();
            var vars = new Dictionary<string, object>
            {
                { "owner", "octokit" },
                { "name", "octokit.net" },
            };

            var result = await Connection.Run(query, vars);

            Assert.True(result.Issues.Count > 500);
            Assert.True(result.PullRequests.Count > 500);
        }

        [IntegrationTest]
        public async Task Should_Query_Repository_Issues_PullRequests_To_Object_AutoPaging()
        {
            var query = new Query()
                .Repository(Var("owner"), Var("name"))
                .Select(repository => new 
                {
                    StringList1 = repository.Issues(null, null, null, null, null, null, null).AllPages().Select(issue => issue.Title).ToList(),
                    StringList2 = repository.Issues(null, null, null, null, null, null, null).AllPages().Select(issue => issue.Title).ToList(),
                })
                .Compile();
            var vars = new Dictionary<string, object>
            {
                { "owner", "octokit" },
                { "name", "octokit.net" },
            };

            var result = await Connection.Run(query, vars);

            Assert.True(result.StringList1.Count > 500);
            Assert.True(result.StringList2.Count > 500);
        }

        [IntegrationTest(Skip = "Querying unions like this no longer works")]
        public async Task Should_Query_Union_Issue_Or_PullRequest()
        {
            var query = new Query().Repository("octokit", "octokit.net")
                .IssueOrPullRequest(1)
                .Select(issueOrPullRequest => new
                {
                    IssueId = issueOrPullRequest.Issue.Id,
                    PullRequestId = issueOrPullRequest.PullRequest.Id
                });

            var result = await Connection.Run(query);
        }

        class TestModelObject
        {
            public string StringField1;
            public string StringField2;
            public int IntField1;
            public int IntField2;
        }
    }
}
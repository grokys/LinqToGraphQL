﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Octokit.GraphQL.Core;
using Octokit.GraphQL.Core.Generation;
using Octokit.GraphQL;
using System.IO;
using Newtonsoft.Json;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //GenerateEntities(args[0]).Wait();
            //RunRepositoryQuery(args[0]).Wait();
            RunSearchQuery(args[0]).Wait();
            Console.ReadKey();
        }

        private static async Task GenerateEntities(string token)
        {
            var connection = new Connection("https://api.github.com/graphql", token);
            var schema = await SchemaReader.ReadSchema(connection);

            Directory.CreateDirectory("src");

            foreach (var file in CodeGenerator.Generate(schema, "Octokit.GraphQL"))
            {
                Console.WriteLine("Writing " + file.FileName);
                File.WriteAllText(Path.Combine("src", file.FileName), file.Content);
            }
        }

        private static async Task RunRepositoryQuery(string token)
        {
            var query = new Query()
                .Select(root => root
                    .RepositoryOwner("grokys")
                    .Repositories(10, null, null, null, null, null, null, null, null)
                    .Edges.Select(x => x.Node)
                    .Select((Repository x) => new
                    {
                        x.Id,
                        x.Name,
                        Owner = x.Owner.Select(o => new
                        {
                            o.Login,
                        }),
                        x.IsFork,
                        x.IsPrivate,
                        root.Viewer.Login,
                    }));

            var connection = new Connection("https://api.github.com/graphql", token);
            var result = (await connection.Run(query));

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        private static async Task RunViewerQuery(string token)
        {
            var query = new Query().Viewer.Select(x => new { x.Login, x.Email });
            var connection = new Connection("https://api.github.com/graphql", token);
            var result = (await connection.Run(query)).Single();

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        private static async Task RunSearchQuery(string token)
        {
            var query = new Query()
                .Search("Steven", SearchType.User, 30)
                .Nodes
                .Select(x => x.User.Name);

            var connection = new Connection("https://api.github.com/graphql", token);
            var result = await connection.Run(query);

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
﻿using System;

namespace Octokit.GraphQL.Core.Generation.Models
{
    public class InputValueModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeModel Type { get; set; }
        public string DefaultValue { get; set; }
    }
}

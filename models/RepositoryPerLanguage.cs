using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class RepositoryPerLanguage
    {
        public string? Language { get; set; }
        public List<GitRepository>? GitRepositories { get; set; }
    }
}



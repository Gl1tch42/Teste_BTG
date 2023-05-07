using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("GitRepositoryOwner")]
    public class GitRepositoryOwner
    {
        [Display(Name = "Login")]
        [Column("Login")]
        [JsonProperty("login")]
        public string? Login { get; set; }

        [Display(Name = "Id")]
        [Column("Id")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [Display(Name = "NodeId")]
        [Column("NodeId")]
        [JsonProperty("node_id")]
        public string? NodeId { get; set; }

        [Display(Name = "AvatarUrl")]
        [Column("AvatarUrl")]
        [JsonProperty("avatar_url")]
        public string? AvatarUrl { get; set; }

        [Display(Name = "HtmlUrl")]
        [Column("HtmlUrl")]
        [JsonProperty("html_url")]
        public string? HtmlUrl { get; set; }

        [Display(Name = "Type")]
        [Column("Type")]
        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("GitRepository")]
    public class GitRepository
    {
        
        [Display(Name = "Id")]
        [Column("Id")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [Display(Name = "INodeIdd")]
        [Column("NodeId")]
        [JsonProperty("node_id")]
        public string? NodeId { get; set; }

        [Display(Name = "Name")]
        [Column("Name")]
        [JsonProperty("name")]
        public string? Name { get; set; }

        [Display(Name = "FullName")]
        [Column("FullName")]
        [JsonProperty("full_name")]
        public string? FullName { get; set; }

        [Display(Name = "Owner")]
        [Column("Owner")]
        [JsonProperty("owner")]
        public GitRepositoryOwner? Owner { get; set; }

        [Display(Name = "HtmlUrl")]
        [Column("HtmlUrl")]
        [JsonProperty("html_url")]
        public string? HtmlUrl { get; set; }

        [Display(Name = "Description")]
        [Column("Description")]
        [JsonProperty("description")]
        public string? Description { get; set; }

        [Display(Name = "Homepage")]
        [Column("Homepage")]
        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [Display(Name = "Language")]
        [Column("Language")]
        [JsonProperty("language")]
        public string? Language { get; set; }
    }
}



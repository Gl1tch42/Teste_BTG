using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

using Api.Service;

namespace Api.Controllers
{
    [Route("api/Git")]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitService _service;

        public GitController(IGitService service)
        {
            _service = service;
        }

        //GitReposytory
        // GET: api/Git/getGitRepositoriesList
        [HttpGet("getGitRepositoriesList")]
        public async Task<ActionResult<IEnumerable<RepositoryPerLanguage>>> GetGitRepositoriesList()
        {
            try
            {
                return await _service.GetGitRepositoriesList();
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }
        }

        // GET: api/""Git/getGitRepositoriesListByLanguage/{language}
        [HttpGet("getGitRepositoriesListByLanguage/{language}")]
        public async Task<ActionResult<IEnumerable<GitRepository>>> GetGitRepositoriesListByLanguage(string language)
        {
            try
            {
                return await _service.GetGitRepositoriesListByLanguage(language);
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }
        }

        // GET: api/Git/addGitRepository
        [HttpGet("addGitRepository")]
        public async Task<ActionResult<bool>> AddGitRepository()
        {
            try
            {
                return await _service.AddGitRepository();
            }
            catch (WebException e)
            {
                Console.WriteLine($"Erro ao buscar repositórios em destaque: {e.Message}");
                return Problem("Problem to set 'MyContext.ProgrammingLanguage'");
            }
        }
    }
}

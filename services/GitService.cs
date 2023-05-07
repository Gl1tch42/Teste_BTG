using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Service
{
    public interface IGitService
    {
        Task<ActionResult<IEnumerable<RepositoryPerLanguage>>> GetGitRepositoriesList();
        Task<ActionResult<IEnumerable<GitRepository>>> GetGitRepositoriesListByLanguage(string language);
        Task<ActionResult<bool>> AddGitRepository();
        bool GitRepositoryExists(int id);
        bool GitRepositoryOwnerExists(long id);
    }

    public class GitService : IGitService
    {
        private readonly MyContext _context;
        public GitService(MyContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<RepositoryPerLanguage>>> GetGitRepositoriesList()
        {
            List<RepositoryPerLanguage> repositoryPerLanguages = new List<RepositoryPerLanguage>();

            var languages = await _context.ProgrammingLanguages.ToListAsync();

            foreach (var language in languages)
            {
                RepositoryPerLanguage repositoryPerLanguage = new RepositoryPerLanguage();
                repositoryPerLanguage.Language = language.Name;
                repositoryPerLanguage.GitRepositories = await _context.GitRepositories.Where(
                x => x.Language.ToLower() == language.Name.ToLower()
                ).ToListAsync();
                repositoryPerLanguages.Add(repositoryPerLanguage);

            }

            return repositoryPerLanguages;
        }

        public async Task<ActionResult<IEnumerable<GitRepository>>> GetGitRepositoriesListByLanguage(string language)
        {
            return await _context.GitRepositories.Where(
                x => x.Language.ToLower() == language.ToLower()
                ).ToListAsync();
        }
        public async Task<ActionResult<bool>> AddGitRepository()
        {
            var languages = _context.ProgrammingLanguages.ToList();

            foreach (var language in languages)
            {
                string url = $"https://api.github.com/search/repositories?q=language:{language.Name}&sort=stars&order=desc&per_page=10";
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("User-Agent", "your_user");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "your_token");
                HttpResponseMessage response = await client.GetAsync(url);
                string json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<dynamic>(json);
                dynamic items = result["items"];

                List<GitRepository> gitRepositories = new List<GitRepository>();
                foreach (var item in items)
                {
                    var serialize = JsonConvert.SerializeObject(item);

                    GitRepository Repository = JsonConvert.DeserializeObject<GitRepository>(serialize);

                    if (!GitRepositoryOwnerExists(Repository.Owner.Id))
                    {
                        _context.GitRepositories.Add(Repository);
                        await _context.SaveChangesAsync();
                    }
                    else
                        gitRepositories.Add(Repository);
                }
            }
            return true;
        }
        public bool GitRepositoryExists(int id)
        {
            return (_context.GitRepositories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public bool GitRepositoryOwnerExists(long id)
        {
            return (_context.GitRepositoryOwner?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
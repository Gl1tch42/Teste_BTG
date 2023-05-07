using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Service
{
    public interface IProgrammingLanguageService
    {
        Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetProgrammingLanguage();
        Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguageById(int id);
        Task<ActionResult<bool>> AddProgrammingLanguage(ProgrammingLanguage programmingLanguages);
        bool ProgrammingLanguageExists(int id);
    }

    public class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private readonly MyContext _context;
        public ProgrammingLanguageService(MyContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetProgrammingLanguage()
        {
            var languages = await _context.ProgrammingLanguages.ToListAsync();
            return languages;
        }
        public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguageById(int id)
        {
            var languange = await _context.ProgrammingLanguages.FindAsync(id);
            return languange;
        }

        private ActionResult<ProgrammingLanguage> NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<bool>> AddProgrammingLanguage(ProgrammingLanguage programmingLanguages)
        {
            _context.ProgrammingLanguages.Add(programmingLanguages);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool ProgrammingLanguageExists(int id)
        {
            return (_context.ProgrammingLanguages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
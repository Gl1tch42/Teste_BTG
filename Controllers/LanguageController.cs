using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IProgrammingLanguageService _service;

        public LanguageController(IProgrammingLanguageService service)
        {
            _service = service;
        }

        //Language
        // GET: api/Language/getListLanguage
        [HttpGet("getListLanguage")]
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetProgrammingLanguage()
        {
            try
            {
                return await _service.GetProgrammingLanguage();
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }
        }

        // GET: api/Language/getProgrammingLanguageById
        [HttpGet("getProgrammingLanguageById/{id}")]
        public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguageById(int id)
        {
            try
            {
                return await _service.GetProgrammingLanguageById(id);
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }
        }
        
        // GET: api/Language/addProgrammingLanguage
        [HttpPost("addProgrammingLanguage")]
        public async Task<ActionResult<bool>> AddProgrammingLanguage(ProgrammingLanguage programmingLanguages)
        {
            try
            {
                if(_service.ProgrammingLanguageExists(programmingLanguages.Id))
                {
                    return Problem("this id is aready used");
                }
                return await _service.AddProgrammingLanguage(programmingLanguages);
            }
            catch (System.Exception e)
            {
                return Problem("Problem to set 'MyContext.ProgrammingLanguage'");
                throw e;
            }
        }
    }
}

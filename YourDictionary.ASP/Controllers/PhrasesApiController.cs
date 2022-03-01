using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionary.ASP.ViewModels;

namespace YourDictionaries.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhrasesDataService _phrasesDataService;

        public PhrasesApiController(IMapper mapper, IPhrasesDataService phrasesDataService)
        {
            _mapper = mapper;
            _phrasesDataService = phrasesDataService;
        }

        // GET: api/PhrasesApi/1
        [HttpGet]
        public async Task<JsonResult> GetPhrasesFromSelectedDictionary(int dictionaryId)
        {
            var phrases = await _phrasesDataService.GetPhrasesFromDictionary(dictionaryId);
            var phrasesVm = phrases.Select(p => _mapper.Map<PhraseViewModel>(p)); 
            return new JsonResult(phrasesVm);
        }
    }
}

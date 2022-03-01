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
    public class DictionariesApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDictionaryDataService _dictionaryDataService;

        public DictionariesApiController(IMapper mapper, IDictionaryDataService dictionaryDataService)
        {
            _mapper = mapper;
            _dictionaryDataService = dictionaryDataService;
        }

        public async Task<JsonResult> GetDictionariesByUserId(int userId)
        {
            var dics = await _dictionaryDataService.GetDictionariesForUser(userId);
            var dicsVm = dics.Select(d => _mapper.Map<DictionaryViewModel>(d));
            return new JsonResult(dicsVm);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionary.ASP.ViewModels;

namespace YourDictionary.ASP.Controllers
{
    [Authorize]
    public class DictionariesController : Controller
    {
        private readonly IDictionaryDataService _dictionaryDataService;
        private readonly IMapper _mapper;

        public DictionariesController(IDictionaryDataService dictionaryDataService, IMapper mapper)
        {
            _dictionaryDataService = dictionaryDataService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUserIdStr = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (loggedInUserIdStr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var success = int.TryParse(loggedInUserIdStr, out int loggedInUserId);
            if (!success)
            {
                return RedirectToAction("Login", "Account");
            }
            var dictionaries = await _dictionaryDataService.GetDictionariesForUser(loggedInUserId);
            var dictionariesViewModels = dictionaries.Select(d => _mapper.Map<DictionaryViewModel>(d));
            return View(dictionariesViewModels.ToList());
        }
    }
}

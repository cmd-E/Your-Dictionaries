using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;
using YourDictionary.ASP.ViewModels;

namespace YourDictionary.ASP.Services.AutoMapper.Profiles
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            MapBothDirections<Dictionary, DictionaryViewModel>();
            MapBothDirections<Phrase, PhraseViewModel>();
            MapBothDirections<User, UserViewModel>();
        }

        private void MapBothDirections<T1, T2>() 
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}

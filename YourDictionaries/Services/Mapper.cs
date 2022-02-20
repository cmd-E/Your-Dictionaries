using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Domain.Models;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Services
{
    public static class Mapper
    {
        public static IMapper MyMapper { get; private set; }
        public static void InitMapper()
        {
            var configExpression = new MapperConfigurationExpression();
            configExpression.CreateMap<Dictionary, DictionaryViewModel>()
                .ForMember(dvm => dvm.Phrases, m => m.MapFrom(d => d.Phrases));
            configExpression.CreateMap<DictionaryViewModel, Dictionary>()
                .ForMember(d => d.Phrases, m => m.MapFrom(dvm => dvm.Phrases));
            configExpression.CreateMap<Phrase, PhraseViewModel>()
                .ForMember(pvm => pvm.AssignedDictionary, m => m.MapFrom(p => p.Dictionary));
            configExpression.CreateMap<PhraseViewModel, Phrase>()
                .ForMember(pvm => pvm.Dictionary, m => m.MapFrom(p => p.AssignedDictionary));
            var mapperConfig = new MapperConfiguration(configExpression);
            MyMapper = new AutoMapper.Mapper(mapperConfig);
        }
    }
}

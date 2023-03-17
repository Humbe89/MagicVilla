using AutoMapper;
using MagicVilla_API.DTOs;
using MagicVilla_API.Models;

namespace MagicVilla_API.Mapping
{
    public class MappinConfig: Profile
    {
        public MappinConfig()
        {
            CreateMap<VillaGetDto, VillaExampleDto>();
            CreateMap<VillaExampleDto, VillaGetDto>();
        }
    }
}

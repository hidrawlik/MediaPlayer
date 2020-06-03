using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Entities;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.BLL.DTOs.UserDTO;

namespace MediaPlayer.BLL
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Music, MusicCUDTO>()
                .ForMember(e => e.Album, opt => opt.Ignore());

            CreateMap<MusicCUDTO, Music>()
                .ForMember(e => e.Album, opt => opt.Ignore());

            CreateMap<Music, MusicViewDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreDTO>()
                .ReverseMap();

            CreateMap<Album, AlbumDTO>()
                .ReverseMap();

            //Identity

            CreateMap<User, UserCreateDTO>()
                .ForMember(e => e.UserName, opt => opt.MapFrom(e => e.UserName))
                .ReverseMap();

            CreateMap<User, UserEditDTO>()
                .ConstructUsing(e => new UserEditDTO(e.Id))
                .ReverseMap();

            CreateMap<User, UserViewDTO>()
                .ConstructUsing(e => new UserViewDTO(e.Id))
                .ReverseMap();
        }
    }
}

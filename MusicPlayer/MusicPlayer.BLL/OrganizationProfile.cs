using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MusicPlayer.DAL.Entities;
using MusicPlayer.BLL.DTOs;

namespace MusicPlayer.BLL
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

            CreateMap<UserPlaylist, PlaylistDTO>()
                .ReverseMap();

            CreateMap<UserPlaylist, PlaylistCUDTO>()
                .ReverseMap();

            CreateMap<MusicPlaylist, MusicPlaylistDTO>()
                .ReverseMap();

            //Identity
            CreateMap<User, UserCreateDTO>()
                .ForMember(e => e.UserName, opt => opt.MapFrom(e => e.UserName))
                .ReverseMap();

            CreateMap<User, UserUpdateDTO>()
                .ConstructUsing(e => new UserUpdateDTO(e.Id))
                .ReverseMap();

            CreateMap<User, UserViewDTO>()
                .ConstructUsing(e => new UserViewDTO(e.Id))
                .ReverseMap();
        }
    }
}

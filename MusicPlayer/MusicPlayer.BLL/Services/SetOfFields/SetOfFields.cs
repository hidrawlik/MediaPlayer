using AutoMapper;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.BLL.Services
{
    public abstract class SetOfFields
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        protected SetOfFields(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}

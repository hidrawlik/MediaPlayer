using AutoMapper;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;

namespace MusicPlayer.BLL.Services
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

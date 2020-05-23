using AutoMapper;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.BLL.Services
{
    public abstract class SetOfFields
    {
        protected readonly IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<OrganizationProfile>()).CreateMapper();
        protected readonly IUnitOfWork unitOfWork;
        protected SetOfFields(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

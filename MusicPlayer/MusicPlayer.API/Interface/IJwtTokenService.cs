using MusicPlayer.BLL.DTOs;

namespace MusicPlayer.API.Interface
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(string email, UserDTO user);
    }
}

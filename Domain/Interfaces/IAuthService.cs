using System.Threading.Tasks;
using DTO.Models;

namespace Domain.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserRegisterDto model);
        Task<LoginResponseDto> LoginAsync(UserLoginDto model);
    }
}
// IAuthService
using NZFTC.Shared.Dtos;
using System.Threading.Tasks;

namespace NZFTC.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(LoginDto login);
        Task RegisterAsync(RegisterDto register);
    }
}
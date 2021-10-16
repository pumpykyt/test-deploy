using System.Threading.Tasks;
using DA.Entities;

namespace Domain.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
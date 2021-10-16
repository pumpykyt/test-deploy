using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string role);
        Task<List<string>> GetRolesAsync();
    }
}
using System.Threading.Tasks;
using DA.Entities;
using DTO.Models;

namespace Domain.Interfaces
{
    public interface IDealService
    {
        Task<DealResponseDto> CreateDealAsync(DealRequestDto model, string userId);
        Task<PagedResponseDto<DealResponseDto>> GetDealsPageAsync(int pageSize, int pageNumber);
        Task DeleteDealAsync(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DA;
using DA.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using DTO.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class DealService : IDealService
    {
        private readonly EFContext _context;

        public DealService(EFContext context)
        {
            _context = context;
        }

        public async Task<DealResponseDto> CreateDealAsync(DealRequestDto model, string userId)
        {
            var deal = model.Adapt<Deal>();
            deal.Created = DateTime.UtcNow;
            await _context.Deals.AddAsync(deal);
            await _context.SaveChangesAsync();
            
            return deal.Adapt<DealResponseDto>(); 
        }

        public async Task<PagedResponseDto<DealResponseDto>> GetDealsPageAsync(int pageSize, int pageNumber)
        {
            var deals = await _context.Deals
                .OrderBy(t => t.Created)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponseDto<DealResponseDto>(deals.Adapt<IEnumerable<DealResponseDto>>());
        }

        public async Task DeleteDealAsync(int id)
        {
            var deal = await _context.Deals.SingleOrDefaultAsync(t => t.Id == id);
            if (deal == null)
            {
                throw new RestException(HttpStatusCode.NotFound);
            }
            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();
        }
    }
}
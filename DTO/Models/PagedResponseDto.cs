using System.Collections;
using System.Collections.Generic;

namespace DTO.Models
{
    public class PagedResponseDto<T>
    {
        public PagedResponseDto()
        {
        }

        public PagedResponseDto(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
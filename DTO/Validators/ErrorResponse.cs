using System.Collections.Generic;
using DTO.Models;

namespace DTO.Validators
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
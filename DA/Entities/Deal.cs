using System;
using System.ComponentModel.DataAnnotations;

namespace DA.Entities
{
    public class Deal
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Task { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public string AuthorId { get; set; }
        public string? PerformerId { get; set; }
        public virtual User Author { get; set; }
        public virtual User Performer { get; set; }
    }
}
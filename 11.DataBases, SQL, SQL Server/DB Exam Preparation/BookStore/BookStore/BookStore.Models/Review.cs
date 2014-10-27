namespace BookStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [Index(IsUnique = true)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}

namespace ForumSys.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ForumSys.Data.Common.Models;

    public class Feedback : AuditInfo, IDeletableEntity
    {
        public Feedback()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public abstract class BaseMaintenance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(55)]
        public string Description { get; set; }

        [Required]
        public bool Enabled { get; set; } = true;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}

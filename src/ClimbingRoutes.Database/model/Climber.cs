using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimbingRoutes.Database.Model
{
    [Table("Climbers")]
    public class Climber
    {
        [Key]
        public int ClimberId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        public IList<Ascent> Ascents { get; set; }
    }
}

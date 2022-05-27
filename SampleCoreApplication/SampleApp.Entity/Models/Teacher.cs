using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleApp.Entity.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Skills { get; set; }
        
        [Range(5,50)]
        public int TotalStudents { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    
        [Required]
        public DateTime AddedOn { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;


namespace ShopkeeperProject.Domain.Entities
{
    public class Contact
    {

        [Key]
        public string Id { get; set; }

        
        [Required]
        public string Phone { get; set; }

        public string? Address { get; set; }

          [Required]
         public string Email  { get; set; }



    

        [Range(0, double.MaxValue)]
         public decimal? CurrentBalance { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;



    }
}




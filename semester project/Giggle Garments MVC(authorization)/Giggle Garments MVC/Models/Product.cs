using System.ComponentModel.DataAnnotations;

namespace Giggle_Garments_MVC.Models
{
    public class Product
    {
        public int? prod_Id { get; set; }

        [Required]
        public  string name { get; set; }
        
        [Required]
        public string description { get; set; }
        
        [Required]
        public decimal? price  { get; set; }
       
        [Required]
        [Range(1,4)]
        public int? category_Id { get; set; }
        public string?  imagePath { get; set; }
    }
}

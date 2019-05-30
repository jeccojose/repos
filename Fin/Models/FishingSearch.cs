using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fin.Models
{
    public class FishingSearch
    {                    
        [Required(ErrorMessage = "Please enter Zipcode")]
        [StringLength(5)]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }
                
        [Required]
        [Display(Name = "Fish Species")]
        public int FishSpecies_ID { get; set; }

        [Required]
        [Display(Name = "Fish Size")]
        public int FishSize_ID { get; set; }
    

        [Required]
        [Display(Name = "Is Youth Only")]
        public bool Is_YouthOnly { get; set; }

        [Required]
        [Display(Name = "Is Youth Friendly")]
        public bool Is_YouthFriendly { get; set; }
    }
}

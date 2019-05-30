using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Models
{
    public class FishingInfo
    {
        public int Waterbody_ID { get; set; }


        [Display(Name = "WaterBody Image")]
        public string WaterBody_Image { get; set; }

        [Display(Name = "GPSCOORDINATES_DECIMAL")]
        public string GPSCOORDINATES_DECIMAL { get; set; }

      


        [Display(Name = "WaterBody")]
        // [Required(ErrorMessage = "Name is required")]
        // [StringLength(160)]
        public string WaterBody_AltName { get; set; }

        [Display(Name = "Description")]
        public string WaterBody_Description { get; set; }

        [Required]
        [Display(Name = "Youth Only")]
        public bool Is_YouthOnly { get; set; }

        [Required]
        [Display(Name = "Youth Friendly")]
        public bool Is_YouthFriendly { get; set; }

        [Display(Name = "Address")]
        public string Street_Address { get; set; }

        [Display(Name = "City/County")]
        public string City_or_County { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Required]
        public int FishSpecies_ID { get; set; }

        [Display(Name = "Fish species")]
        public string FishSpecies_Name { get; set; }

        [Required]
        public int FishSize_ID { get; set; }
    }
}

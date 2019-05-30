using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Models
{
    public class FishingInfoDetail
    {
        public int Waterbody_ID { get; set; }

        [Display(Name = "WaterBody Image")]
        public string WaterBody_Image { get; set; }

        [Display(Name = "WaterBody")]
        public string WaterBody_AltName { get; set; }

        [Display(Name = "Description")]
        public string WaterBody_Description { get; set; }
                
        [Display(Name = "Is Youth Only")]
        public bool Is_YouthOnly { get; set; }

        [Display(Name = "Is Youth Friendly")]
        public bool Is_YouthFriendly { get; set; }

        [Display(Name = "Street Address")]
        public string Street_Address { get; set; }

        [Display(Name = "City/County")]
        public string City_or_County { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
                
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }       

        [Display(Name = "Fish species")]
        public string FishSpecies_Name { get; set; }

        [Display(Name = "Zone")]
        public string Zone { get; set; }

        [Display(Name = "Office")]
        public string Office { get; set; }

        [Display(Name = "WaterBody_Size")]
        public string WaterBody_Size { get; set; }

        [Display(Name = "GPSCOORDINATES_DEGREES")]
        public string GPSCOORDINATES_DEGREES { get; set; }

        [Display(Name = "GPSCOORDINATES_DECIMAL")]
        public string GPSCOORDINATES_DECIMAL { get; set; }

        [Display(Name = "Stocking_StartDay")]
        public DateTime Stocking_StartDay { get; set; }

        [Display(Name = "Stocking_EndDay")]
        public DateTime Stocking_EndDay { get; set; }

        [Display(Name = "Legals")]
        public int Legals { get; set; }

        [Display(Name = "Trophy")]
        public int Trophy { get; set; }

        [Display(Name = "Brood")]
        public int Brood { get; set; }

        [Display(Name = "Total")]
        public int Total { get; set; }

    }
}

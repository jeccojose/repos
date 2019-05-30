using Fin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.ViewModels
{
    public class HomeDetailsViewModel
    {
        public FishingSearch FishingSearchObj { get; set; }

        public IEnumerable<FishingInfo> FishingInfoListObj { get; set; }

        public FishingInfoDetail FishingInfoDetailObj { get; set; }


    }
}

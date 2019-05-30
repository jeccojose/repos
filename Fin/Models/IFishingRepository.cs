using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fin.Models
{
    public interface IFishingRepository
    {
        FishingSearch GetFishingSearch();
        IEnumerable<FishingInfo> GetFishingInfo();
        IEnumerable<FishingInfo> GetFishingInfo(FishingSearch FishingSearchObj);
        FishingInfoDetail GetFishingDetailInfo(int WaterBodyId);
    }
}
 
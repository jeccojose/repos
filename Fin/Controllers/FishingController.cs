using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fin.Models;
using Fin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Fin.Controllers
{
    public class FishingController : Controller
    {
        private IFishingRepository _fishingRepository;

        public FishingController(IFishingRepository fishingRepository)
        {
            _fishingRepository = fishingRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                FishingSearchObj = _fishingRepository.GetFishingSearch(),
                FishingInfoListObj = _fishingRepository.GetFishingInfo()
            };
            return View(homeDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FishingSearch FishingSearchObj)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                FishingSearchObj = FishingSearchObj,
                FishingInfoListObj = _fishingRepository.GetFishingInfo(FishingSearchObj)
            };
            return View(homeDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FishingInfo(FishingSearch FishingSearchObj)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                FishingInfoListObj = _fishingRepository.GetFishingInfo(FishingSearchObj)
            };
            return View(homeDetailsViewModel);
            //if (ModelState.IsValid)
            //{

            //    return View(FishingDataAccessAObj.GetFishingInfo(fishingSearchObj));
            //}
            //else
            //    return View(fishingSearchObj);
        }



        public IActionResult FishingInfoDetail(int WaterBodyId)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                FishingSearchObj = _fishingRepository.GetFishingSearch(),
                FishingInfoDetailObj = _fishingRepository.GetFishingDetailInfo(WaterBodyId)
            };
            return View(homeDetailsViewModel);


            //if (ModelState.IsValid)
            //{
            //    return View(FishingDataAccessAObj.GetFishingDetailInfo(WaterBodyId));
            //}
            //else
            //    return View();
        }

    }

}
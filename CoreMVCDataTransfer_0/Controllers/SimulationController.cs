using CoreMVCDataTransfer_0.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDataTransfer_0.Controllers
{
    public class SimulationController : Controller
    {

        //Bütün Data Transfer yapıları ilkel tipler ile calısmaya uygundur. Her ne kadar kompleks tiplere destek verseler de kompleks tipler ile kullanılmaları kesinlikle saglıklı degildir...
        //Eger siz Model gönderme yöntemiyle veri göndermiyorsanız o verinin karsılanmasına gerek yoktur. Zaten isteseniz de karsılayamazsınız...

        //ViewBag : Sadece Controller'iniz icerisindeki Action'dan View'iniza veri gönderme görevini uygular...

        //ViewData : Action'dan View'a veri gönderir lakin verileri object tipte tutar.

        //TempData: Diger Data Transfer yapılarına ek olarak aynı zamanda Action'dan Action'a da veri gönderebilen bir Data Transfer yapınızdır. Lakin bu temporary bir data'dır (tek kullanımlıktır)


        public IActionResult Index()
        {
            Egitmen egt = new()
            {
                Isim = "Cagri",
                SoyIsim = "Yolyapar"
            };


            //ViewBag.Egitmen = egt; //bu tarz yapıların kompleks tipler ile kullanılmaması gerekir.

            ViewBag.Mesaj = 12;



            return View();
        }

        public IActionResult ViewDataUsage()
        {
            Egitmen egt = new()
            {
                Isim = "Cagri",
                SoyIsim = "Yolyapar"
            };

            //ViewData["mesaj"] = egt;

            //DataTransfer yapılarında aynı isimde bir yapıyı tekrar acarsanız son actıgınız öncekileri ezer...

            ViewData["sayi"] = 12;

            ViewData["sayi"] = 30;

            return View();
        }



        public IActionResult TempDataUsage()
        {
            TempData["sayi"] = 100;
            TempData.Keep("sayi"); //Keep metodu ilgili TempData verisinin kullanımını bir tur daha uzatır
            return View();
        }


        public IActionResult DenemeAction()
        {
            int sayi = Convert.ToInt32(TempData["sayi"]);
            return View();
        }
    }
}

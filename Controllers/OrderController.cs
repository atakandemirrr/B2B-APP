using B2B_Deneme.Models;
using B2B_Deneme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace B2B_Deneme.Controllers
{

    public class OrderController : Controller
    {
        public readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Orders()
        {
            var email = User.Identity.Name;


            VMMusteriler model = new VMMusteriler();

            model.CariSipBilgileri = _context.CariSipBilgileri(email).AsEnumerable().ToList(); ;
             return View(model);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var email = User.Identity.Name;
            var cariBilgileri = _context.CariBilgileri(email);
            var stoklar = _context.Stok();
            var model = new CreateOrder
            {
                CariBilgileri = cariBilgileri,
                Stoklar = stoklar
            };
            //ViewBag.CariBilgileri = cariBilgileri;
            //VMMusteriler model = new VMMusteriler();
            //model.Stoklar = _context.Stok().AsEnumerable().ToList(); ;
            //VMMusteriler model = new VMMusteriler();

            //model.CariBilgileri = _context.CariBilgileri(email);
            //if(model.CariBilgileri.Rows.Count==0)
            //{

            //    return RedirectToAction("Orders", "Order");

            //}
            return View(model);


        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] SiparisView model)
        {
            if (ModelState.IsValid)
            {
                var siparis = new Order
                {
                    StokKod = model.Stok,
                    Price = model.BirimFiyat,
                    Piece = model.Adet,
                    Total = model.Toplam,
                    CreDate = model.CreateDate,
                    UpdateDate = model.UpdateDate,
                    CariKod = model.CariKod,
                    SipSira = model.SipSira,
                    SipSeri = model.SipSeri,
                    Statu = model.Statu
                };

                _context.Orders.Add(siparis);
                _context.SaveChanges();

                return Ok("İşlem başarıyla tamamlandı.");
            }

            return BadRequest("Geçersiz istek.");


        }



        public IActionResult ProductSelection(string stockCode)
        {
            var stoklar = _context.Stok().AsEnumerable().ToList(); ;
            var selectedRow = stoklar.FirstOrDefault(row => row["sto_kod"].ToString() == stockCode);
            if (selectedRow != null)
            {
             
              

                decimal fiyat = Convert.ToDecimal(selectedRow["sfiyat_fiyati"]);

      
                return Json(fiyat);
            }
            else
            {
                decimal fiyat = 0;
                return Json(fiyat);
            }




        }
    }
}

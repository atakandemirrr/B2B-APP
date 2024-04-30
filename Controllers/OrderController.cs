using B2B_Deneme.Models;
using B2B_Deneme.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;

namespace B2B_Deneme.Controllers
{
    [Authorize]

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
            if (cariBilgileri.Rows.Count != 0)
            {
                var stoklar = _context.Stok();
                var model = new CreateOrder
                {
                    CariBilgileri = cariBilgileri,
                    Stoklar = stoklar
                };

                return View(model);
            }

            return RedirectToAction("Orders", "Order");


        }

        [HttpGet]
        public IActionResult EditOrder(string SipSira)
        {
           
            var orders = _context.Orders.Where(x => x.SipSira.ToString() == SipSira).ToList();
            if (orders.Count != 0)
            {
                return View(orders);
            }
            return RedirectToAction("Orders", "Order");


        }


        [HttpPost]
        public int CreateOrder([FromBody] SiparisView model)
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
                    Statu = model.Statu,
                    OrderDate = model.OrderDate,
                    DeliveryDate = model.DeliveryDate
                };
                

                _context.Orders.Add(siparis);
                _context.SaveChanges();

                // Eklenen son kaydın UserTableId değerini almak için:
                var sonEklenenSiparis = _context.Orders.OrderByDescending(o => o.UserTableId).FirstOrDefault(o => o.SipSeri == model.SipSeri && o.SipSira == model.SipSira);
                int userTableId = sonEklenenSiparis.UserTableId;

                return userTableId;

            }
            return 0;

        }

        [HttpPost]
        public IActionResult DeleteOrder(int UserTableID)
        {
            var siparis = _context.Orders.FirstOrDefault(o => o.UserTableId == UserTableID);

            if (siparis != null)
            {
                _context.Orders.Remove(siparis);
                _context.SaveChanges();

                return Ok("Sipariş başarıyla silindi.");
            }

            return NotFound("Sipariş bulunamadı.");
        }

        [HttpPost]
        public IActionResult OrderStatuUpdate(int SipSira,int Statu)
        {
            var siparisler = _context.Orders.Where(o => o.SipSira == SipSira);

            if (siparisler.Any())
            {
                foreach (var siparis in siparisler)
                {
                    siparis.Statu = Statu;
                }

                _context.SaveChanges();

                return Ok("Siparişlerin statüleri başarıyla güncellendi.");
            }

            return NotFound("Siparişler bulunamadı.");
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

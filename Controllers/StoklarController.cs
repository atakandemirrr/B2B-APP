﻿using B2B_Deneme.Models;
using B2B_Deneme.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class StoklarController : Controller
    {
        public readonly DataContext _context;

        public StoklarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Stoklar()
        {
            VMMusteriler model = new VMMusteriler();

            model.Stoklar = _context.Stok().AsEnumerable().ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult EditOrderDropdown()
        {
            List<object> stokListesi = new List<object>();

            foreach (DataRow row in _context.Stok().Rows)
            {
                string stokKod = row["sto_kod"].ToString();
                string stokAd = row["sto_isim"].ToString();

                var stok = new { StokKodu = stokKod, StokAdi = stokAd };
                stokListesi.Add(stok);
            }

            return Json(stokListesi);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcartApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcartApplication.Controllers
{
    public class ECartController : Controller
    {
        [HttpGet]
        public IActionResult UserCart()
        {    
            var _skudetail = new List<Skudetail>()
            {
            new Skudetail(){ Unitname = "A", unitprice = 50 },
            new Skudetail(){ Unitname = "B", unitprice = 30 },
            new Skudetail(){ Unitname = "C", unitprice = 20 },
            new Skudetail(){ Unitname = "D", unitprice = 15 }
            };
            return View(_skudetail);
        }
        
        [HttpPost]
        public IActionResult UserCart(IEnumerable<Skudetail> _skudetail)
        {
            PromotionClass promoclass = new PromotionClass();
            var netamount = promoclass.CalculatePromo(_skudetail);
            ViewBag.netamount = netamount.ToString();
            return View(_skudetail);
        }
    }
}

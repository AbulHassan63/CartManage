using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcartApplication.Models
{
    public class Product
    {
        public List<Skudetail> listSkudetail { get; set; }
    }

    public class Skudetail
    {
        public string Unitname { get; set; }
        public int Unitqty { get; set; }
        public int unitprice { get; set; }

        public decimal Unittotal { get; set; }
        public int total { get; set; }
    }

    public class Promo
    {
        public float Promopercentage { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EcartApplication.Models
{
    public class PromotionClass
    {

        public decimal CalculatePromo(IEnumerable<Skudetail> _Product)
        {
            decimal netamount = 0.0M;
            Promo group1 = new Promo();
            Promo group2 = new Promo();
            Promo group3 = new Promo();
            bool statusflg = true;
            group1.Promopercentage = 13.34F;
            group2.Promopercentage = 25.0f;
            group3.Promopercentage = 30.0f;




            foreach (var item in _Product)
            {
                if (item.Unitname == "A")
                {
                    int remainder;
                    int quotient = Math.DivRem(item.Unitqty, 3, out remainder);
                    int val1 = item.Unitqty - remainder;
                    //var afd = val1 * item.unitprice - (val1 * item.unitprice * group1.Promopercentage / 100);
                    decimal suma = Convert.ToDecimal((val1 * item.unitprice - (val1 * item.unitprice * group1.Promopercentage / 100)) + remainder * item.unitprice);
                    netamount += Math.Round(suma);

                }
                else if (item.Unitname == "B")
                {
                    int remainder;
                    int quotient = Math.DivRem(item.Unitqty, 2, out remainder);
                    int val1 = item.Unitqty - remainder;
                    netamount += Convert.ToDecimal((val1 * item.unitprice - (val1 * item.unitprice * group2.Promopercentage / 100)) + remainder * item.unitprice);

                }
                else if (item.Unitname == "C" || item.Unitname == "D")
                {
                    var cnt = (from val in _Product where (val.Unitname == "C" || val.Unitname == "D") select val).Count();
                    if (statusflg == true)
                    {
                        if (cnt > 1)
                        {

                            var unitqtyC = (from val in _Product where (val.Unitname == "C") select val.Unitqty).ToList();
                            var unitqtyD = (from val in _Product where (val.Unitname == "D") select val.Unitqty).ToList();
                            int remainderc, remainderD, remcd;
                            int qutientcd =Math.DivRem(unitqtyC[0] + unitqtyD[0], 2, out remcd);
                            if (remcd == 0)
                            {
                                netamount += ((unitqtyC[0] + unitqtyD[0])/2 )* 30;
                            }
                            else {
                                int quotientc = Math.DivRem(unitqtyC[0], 2, out remainderc);
                                int quotientd = Math.DivRem(unitqtyD[0], 2, out remainderD);

                                netamount += (quotientc + quotientd) * 30;
                                if (remainderc > 0)
                                {
                                    netamount += remainderc * 20;
                                }
                                if (remainderD > 0)
                                {
                                    netamount += remainderD * 15;
                                }
                            }
                            statusflg = false;

                        }
                        else if (item.Unitname == "C")
                        {
                            netamount += item.Unitqty * item.unitprice;
                        }
                        else if (item.Unitname == "D")
                        {
                            netamount += item.Unitqty * item.unitprice;
                        }
                        statusflg = false;
                    }


                }



            }
            return netamount;

        }
    }
}

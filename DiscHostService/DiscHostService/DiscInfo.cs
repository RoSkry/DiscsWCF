using DiscHostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    public class DiscInfo : IDiscInfo
    {
        List<GroupInfo> groups = new List<GroupInfo>();
        public string MostPopularGroup()
        {
            using (DiscContext context = new DiscContext())
            {
                int max = context.Bands.Include("CDs").Include("CDs.Format").Include("CDs.Selling").Include("CDs.Selling.Seller").Max(p => p.CDs.Max(r => r.Selling.Count()));
                string s = context.CDs.FirstOrDefault(p => p.Selling.Count == 2).Name;

                string str = context.Bands.FirstOrDefault(t => t.CDs.Select(i => i.Name).FirstOrDefault() == s).Name;
                //string fg = groups.FirstOrDefault(p => p.SellingCount == 2).Name;

                return str;
            }

        }

        public List<SellInfo> AllSellInfo()

        {
            List<SellInfo> sell = new List<SellInfo>();
            using (DiscContext context = new DiscContext())
            {

                int c = context.Sellings.Count();
                for (int i = 0; i < c; i++)
                {


                    sell.Add(
                        new SellInfo
                        {
                            SellerName = context.Sellings.Include("CD").Include("Seller").ToList()[i].Seller.Name,
                            BandName = context.Sellings.Include("CD").Include("Seller").Include("CD.Band").Include("CD.Format").ToList()[i].CD.Band.Name,
                            CDName = context.Sellings.Include("CD").Include("Seller").Include("CD.Band").Include("CD.Format").ToList()[i].CD.Name,
                            Cd_Date = context.Sellings.Include("CD").Include("Seller").Include("CD.Band").Include("CD.Format").ToList()[i].CD.Cd_Date,
                            FormatName = context.Sellings.Include("CD").Include("Seller").Include("CD.Band").Include("CD.Format").ToList()[i].CD.Format.Name,
                            DateTime = new DateTime(2018, 9, 5 + i)
                        });
                }
            }

            return sell;

        }

        public List<GroupInfo> TotalAmountSellGroup(string GroupName)
        {


            using (DiscContext context = new DiscContext())
            {

                string se = context.Bands.FirstOrDefault(b => b.Name == GroupName).Name;
                int c = context.Bands.Include("CDs").FirstOrDefault(b => b.Name == GroupName).CDs.Count;

                Console.WriteLine();
                for (int i = 0; i < context.Bands.FirstOrDefault(b => b.Name == GroupName).CDs.Count; i++)
                {
                    groups.Add(new GroupInfo
                    {
                        Name = context.Bands.Include("CDs").Include("CDs.Format").Include("CDs.Selling").Include("CDs.Selling.Seller").FirstOrDefault(b => b.Name == GroupName).CDs.ToList()[i].Name,
                        Cd_Date = context.Bands.Include("CDs").Include("CDs.Format").Include("CDs.Selling").Include("CDs.Selling.Seller").FirstOrDefault(b => b.Name == GroupName).CDs.ToList()[i].Cd_Date,
                        Format = context.Bands.Include("CDs").Include("CDs.Format").Include("CDs.Selling").Include("CDs.Selling.Seller").FirstOrDefault(b => b.Name == GroupName).CDs.ToList()[i].Format.Name,
                        SellingCount = context.Bands.Include("CDs").Include("CDs.Format").Include("CDs.Selling").Include("CDs.Selling.Seller").FirstOrDefault(b => b.Name == GroupName).CDs.ToList()[i].Selling.Count()



                    });
                }





                Console.WriteLine();
                return groups;

            }

        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
       public bool AddDiscBand(SellInfo sellInfo)
        {


            //Band band = new Band();
            //if (context.Bands.Any(p => p.Name == sellInfo.BandName))
            //{
            //    band = context.Bands.FirstOrDefault(p => p.Name == sellInfo.BandName);
            //}
            //else band = new Band { Name = sellInfo.BandName, Year = sellInfo.BandDate };
            try
            {
                AddDisc(sellInfo, AddBand(sellInfo.BandName, sellInfo.BandDate));
            }
            catch(Exception)
            {
                return false;
            }
            //context.CDs.Add(
            //    new CD
            //    {
            //        Name = sellInfo.CDName,
            //        Cd_Date = sellInfo.Cd_Date,
            //        Format = context.Formats.FirstOrDefault(f => f.Name == sellInfo.FormatName),
            //        Band = band
            //    });
            //context.SaveChanges();

            return true;
        }

        private void AddDisc(SellInfo sellInfo, Band band)
        {
            using (DiscContext context = new DiscContext())
            {
                context.CDs.Add(
                    new CD
                    {
                        Name = sellInfo.CDName,
                        Cd_Date = sellInfo.Cd_Date,
                        Format = context.Formats.FirstOrDefault(f => f.Name == sellInfo.FormatName),
                        Band = band
                    });
                context.SaveChanges();
            }
        }

        private Band AddBand(string bandName, int bandDate)
        {
            using (DiscContext context = new DiscContext())
            {
                Band band = new Band();
                if (context.Bands.Any(p => p.Name == bandName))
                {
                    band = context.Bands.FirstOrDefault(p => p.Name == bandName);
                }
                else { band = new Band { Name = bandName, Year = bandDate };
                    context.Bands.Add(band);
                }
                
                return context.Bands.AsEnumerable().Last();
            }
           
        }

        


        public List<Disc> ShowAllDiscs()
        {
            List<Disc> discs = new List<Disc>();
           
            

            using (DiscContext context = new DiscContext())
            {
                for (int i = 0; i < context.CDs.Count(); i++)
                {
                    discs.Add(new Disc {
                        Name=context.CDs.Include("Format").Include("Band").ToList()[i].Name,
                        BandName=context.CDs.Include("Format").Include("Band").ToList()[i].Band.Name,
                        FormatName= context.CDs.Include("Format").Include("Band").ToList()[i].Format.Name,
                        Cd_Date= context.CDs.Include("Format").Include("Band").ToList()[i].Cd_Date
                    });
                }
                return discs;
            }
        }

        public void AddSell(string discName, string cashier)
        {
            using (DiscContext context = new DiscContext())
            {
                context.Sellings.Add(new Selling {


                    CD =context.CDs.FirstOrDefault(s=>s.Name==discName),
                    Seller=context.Sellers.FirstOrDefault(s => s.Name == cashier)
                });
                context.SaveChanges();
            }
        }
    }
}


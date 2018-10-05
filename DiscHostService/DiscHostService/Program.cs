using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DiscContext context = new DiscContext())
            {
                try
                {

                    Database.SetInitializer(new DiscInitializer());

                    context.Database.Initialize(true);


                    Console.WriteLine("Database OK!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                try
                {
                    ServiceHost serviceHost = new ServiceHost(typeof(DiscInfo));
                    DiscInfo disc = new DiscInfo();
                    // disc.AllSellInfo();
                    //disc.TotalAmountSellGroup("Наутилус");
                    //disc.MostPopularGroup();
                    disc.ShowAllDiscs();

                    serviceHost.Open();

                    Console.WriteLine("Up and running!");
                  //  ZodiacFind zodiacFind = new ZodiacFind();
                    //zodiacFind.FindWestHoroscope(new DateTime(2018,6,2));

                    Console.ReadLine();

                    serviceHost.Close();

                    Console.WriteLine("Service closed!");
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}

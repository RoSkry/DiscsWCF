using DiscHostService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    class DiscInitializer: CreateDatabaseIfNotExists<DiscContext>
    {
        protected override void Seed(DiscContext context)
        {
            try
            {
                context.Bands.AddRange(
                        new List<Band>

                    {
         new Band { Name="Сборники"},
         new Band {Name="Виа Гра",Year=2002},
         new Band {Name="Ария",Year=1984},
         new Band {Name="Меладзе",Year=1995},
         new Band {Name="Тальков",Year=1984},
         new Band {Name="Наутилус",Year=1983},
                    });
                context.Formats.AddRange(
                    new List<Format>
                    {
                    new Format{Name="audio"},
                    new Format{Name="mp3"}
                });
                context.Sellers.AddRange(
                    new List<Seller>
                    {
                    new Seller{Name="Федоров Максим"

                    },
                    new Seller{Name="Орлов Александр"

                    }
                   });
                context.SaveChanges();
                Seller seller1 = context.Sellers.FirstOrDefault(s => s.Id == 1);
                Seller seller2 = context.Sellers.FirstOrDefault(s => s.Id == 2);
                context.CDs.AddRange(
                    new List<CD>
                    {
                    new CD{Name="Союз 28", Cd_Date=2004, Band=context.Bands.FirstOrDefault(b=>b.Id==1),Format=context.Formats.FirstOrDefault(f=>f.Id==1) },
                    new CD{Name="Стоп Снято", Cd_Date=2002, Band=context.Bands.FirstOrDefault(b=>b.Id==2),Format=context.Formats.FirstOrDefault(f=>f.Id==1)  },
                    new CD{Name="Крещенье Огнем", Cd_Date=2003, Band=context.Bands.FirstOrDefault(b=>b.Id==3),Format=context.Formats.FirstOrDefault(f=>f.Id==1)},
                    new CD{Name="Все альбомы", Cd_Date=2005, Band=context.Bands.FirstOrDefault(b=>b.Id==4),Format=context.Formats.FirstOrDefault(f=>f.Id==2) },
                    new CD{Name="Все альбомы", Cd_Date=2005, Band=context.Bands.FirstOrDefault(b=>b.Id==5),Format=context.Formats.FirstOrDefault(f=>f.Id==2)},
                    new CD{Name="Лучшие песни", Cd_Date=2005, Band=context.Bands.FirstOrDefault(b=>b.Id==3),Format=context.Formats.FirstOrDefault(f=>f.Id==2)},
                    new CD{Name="Атлантида", Cd_Date=1997, Band=context.Bands.FirstOrDefault(b=>b.Id==6),Format=context.Formats.FirstOrDefault(f=>f.Id==2)},
                    new CD{Name="Атлантида", Cd_Date=1997, Band=context.Bands.FirstOrDefault(b=>b.Id==6),Format=context.Formats.FirstOrDefault(f=>f.Id==1)},
                    new CD{Name="Крылья", Cd_Date=1997, Band=context.Bands.FirstOrDefault(b=>b.Id==6),Format=context.Formats.FirstOrDefault(f=>f.Id==1)},


                    });
                context.SaveChanges();
                CD cD = context.CDs.FirstOrDefault(f=>f.Name=="Союз 28");
                context.Sellings.AddRange(
                    new List<Selling>
                    {
                    new Selling{ Seller=seller1,CD=cD},
                    new Selling{Seller=seller1, CD=context.CDs.FirstOrDefault(f=>f.Id==2)},
                    new Selling{Seller=seller1, CD=context.CDs.FirstOrDefault(f=>f.Id==3)  },
                    new Selling{Seller=seller1, CD=context.CDs.FirstOrDefault(f=>f.Id==4) },
                    new Selling{Seller=seller1, CD=context.CDs.FirstOrDefault(f=>f.Id==5)  },
                    new Selling{Seller=seller2, CD=context.CDs.FirstOrDefault(f=>f.Id==6)},
                    new Selling{Seller=seller2, CD=context.CDs.FirstOrDefault(f=>f.Id==1)},
                    new Selling{Seller=seller2, CD=context.CDs.FirstOrDefault(f=>f.Id==7)},
                    new Selling{Seller=seller1, CD=context.CDs.FirstOrDefault(f=>f.Id==8) },
                    new Selling{ Seller=seller2, CD=context.CDs.FirstOrDefault(f=>f.Id==9)},

                    });
               

                //            select B.Name, Sel.Name
                //from dbo.Bands B
                //join dbo.CDs C on C.Band_Id = B.Id
                //Join dbo.Sellings S on S.Cd_Id = C.Id
                //join dbo.Sellers Sel on Sel.Id = S.Seller_Id
                context.SaveChanges();
 Selling selling = context.Sellings.ToList()[0];
                base.Seed(context);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

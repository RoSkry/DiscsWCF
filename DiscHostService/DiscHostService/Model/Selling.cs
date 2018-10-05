using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService.Model
{
    public class Selling
    {
        public int Id { get; set; }
          
       public Seller Seller { get; set; }

        public CD CD { get; set; }
      
        

     
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
  public  class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        
        public ICollection<CD> CDs { get; set; }

        public Band()
        {
            CDs = new List<CD>();
        }
    }
}

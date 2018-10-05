using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
   public class Format
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CD> CDs { get; set; }
    }
}

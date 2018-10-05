using DiscHostService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    [DataContract]
   public class CD
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Cd_Date { get; set; }

        [DataMember]
        public Band Band { get; set; }

        [DataMember]
        public ICollection<Selling> Selling { get; set; }
        [DataMember]
        public Format Format { get; set; }
    
      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    [DataContract]
    public class Disc
    {
       
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Cd_Date { get; set; }

        [DataMember]
        public string BandName { get; set; }

       
        [DataMember]
        public string FormatName { get; set; }



    }
}

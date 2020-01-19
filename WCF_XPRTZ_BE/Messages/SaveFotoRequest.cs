using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_XPRTZ_BE.Messages
{
    [DataContract]
    public class SaveFotoRequest
    {
        [DataMember]
        public byte[] Foto { get; set; }

        [DataMember]
        public int BadgeNumber { get; set; }
    }
}

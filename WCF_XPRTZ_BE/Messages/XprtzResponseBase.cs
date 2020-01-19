using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_XPRTZ_BE.Messages
{
    [DataContract]
    public abstract class XprtzResponseBase
    {
        [DataMember]
        public bool Success { get; set; }
    }
}

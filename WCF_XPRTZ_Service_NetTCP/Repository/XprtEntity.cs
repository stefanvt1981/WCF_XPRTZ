using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_BE.DTO;

namespace WCF_XPRTZ_Service.Repository
{
    public class XprtEntity
    {
        public XprtEntity()
        { }

        public XprtEntity(Xprt xprt)
        {
            Id = xprt.Id;
            BadgeNumber = xprt.BadgeNumber;
            FirstName = xprt.FirstName;
            LastName = xprt.LastName;
            GeboorteDatum = xprt.GeboorteDatum;
            Skills = xprt.Skills;
        }

        public int Id { get; set; }
        public int BadgeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public List<string> Skills { get; set; }
        public byte[] Photo { get; set; }

        public Xprt ToXprt()
        {
            return new Xprt()
            {
                BadgeNumber = BadgeNumber,
                FirstName = FirstName,
                GeboorteDatum = GeboorteDatum,
                Id = Id,
                LastName = LastName,
                Skills = Skills
            };
        }
    }
}

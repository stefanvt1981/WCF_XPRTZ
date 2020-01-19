using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_BE.DTO;

namespace WCF_XPRTZ_Service.Repository
{
    public class XprtzRepository : IXprtzRepository
    {
        private List<XprtEntity> _entities= new List<XprtEntity>();

        public XprtzRepository()
        {
            Seed();            
        }

        private void Seed()
        {
            _entities.Add(
                new XprtEntity
                {
                    BadgeNumber = 2080,
                    FirstName = "Sander",
                    LastName = "Obdijn",
                    GeboorteDatum = new DateTime(1990, 1, 2),
                    Skills = new List<string> { "DevOps", ".Net Core" },
                });
            _entities.Add(
                new XprtEntity
                {
                    BadgeNumber = 7538,
                    FirstName = "Joeri",
                    LastName = "Lieuw",
                    GeboorteDatum = new DateTime(1990, 2, 3),
                    Skills = new List<string>  { "Asp.Net", ".Net Core" },
                });
            _entities.Add(
                new XprtEntity
                {
                    BadgeNumber = 5144,
                    FirstName = "Dick",
                    LastName = "van Hirtum",
                    GeboorteDatum = new DateTime(1980, 3, 4),
                    Skills = new List<string>  { "Entity Framework", ".Net Core" },
                });           
        }

        public Xprt AddXprt(Xprt xprt)
        {
            var newid = _entities.Max(x => x.Id);

            _entities.Add(new XprtEntity(xprt) { Id = newid });

            xprt.Id = newid;

            return xprt;
        }

        public List<Xprt> AddXprts(List<Xprt> xprts)
        {
            foreach (var xprt in xprts)
            {

                var newid = _entities.Max(x => x.Id);

                _entities.Add(new XprtEntity(xprt) { Id = newid });

                xprt.Id = newid;
            }

            return xprts;
        }

        public Xprt GetById(int id)
        {
            var xprtz = _entities.Where(x => x.Id == id);

            if (xprtz.Any())
            {
                return xprtz.FirstOrDefault().ToXprt();
            }

            return null;
        }

        public Xprt GetByBadgeNumber(int badgeNumber)
        {
            var xprtz = _entities.Where(x => x.BadgeNumber == badgeNumber);

            if (xprtz.Any())
            {
                return xprtz.FirstOrDefault().ToXprt();
            }

            return null;
        }

        public List<Xprt> GetAll()
        {
            if (_entities.Any())
            {
                return _entities.Select(x => x.ToXprt()).ToList();
            }

            return new List<Xprt>();
        }

        public bool AddPhoto(byte[] photo, int badgeNumber)
        {
            var xprtz = _entities.Where(x => x.BadgeNumber == badgeNumber);

            if (xprtz.Any())
            {
                var xprt = xprtz.FirstOrDefault();
                xprt.Photo = photo;

                return true;
            }

            return false;
        }
    }
}

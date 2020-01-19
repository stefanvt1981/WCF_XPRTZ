using System.Collections.Generic;
using WCF_XPRTZ_BE.DTO;

namespace WCF_XPRTZ_Service.Repository
{
    public interface IXprtzRepository
    {
        bool AddPhoto(byte[] photo, int badgeNumber);
        Xprt AddXprt(Xprt xprt);
        List<Xprt> AddXprts(List<Xprt> xprts);
        List<Xprt> GetAll();
        Xprt GetByBadgeNumber(int badgeNumber);
        Xprt GetById(int id);
    }
}
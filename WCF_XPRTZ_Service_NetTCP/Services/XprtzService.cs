using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_BE.DTO;
using WCF_XPRTZ_BE.Messages;
using WCF_XPRTZ_Service.Interfaces;
using WCF_XPRTZ_Service.Repository;

namespace WCF_XPRTZ_Service.Services
{
    public class XprtzService : IXprtzService
    {
        private IXprtzRepository _repository;

        public XprtzService()
        {
            _repository = new XprtzRepository();
        }

        public XprtzService(IXprtzRepository repository)
        {
            _repository = repository;
        }

        public XprtzResponse AddPhoto(SaveFotoRequest request)
        {
            try
            {
                _repository.AddPhoto(request.Foto, request.BadgeNumber);

                return new XprtzResponse() { Success = true };
            }
            catch
            {
                return new XprtzResponse() { Success = false };
            }
        }

        public XprtzResponse GetAll()
        {
            try
            {
                return new XprtzResponse() { Success = true, Xprts = _repository.GetAll() };
            }
            catch
            {
                return new XprtzResponse() { Success = false };
            }
        }

        public XprtzResponse GetByBadgeNumber(int badgeNumber)
        {
            try
            {
                return new XprtzResponse() { Success = true, Xprts = new List<Xprt>() { _repository.GetByBadgeNumber(badgeNumber) } };
            }
            catch
            {
                return new XprtzResponse() { Success = false };
            }
        }

        public XprtzResponse Save(SaveXprtzRequest request)
        {
            try
            {
                return new XprtzResponse() { Success = true, Xprts = new List<Xprt>() { _repository.AddXprt(request.Xprts.FirstOrDefault()) } };
            }
            catch
            {
                return new XprtzResponse() { Success = false };
            }
        }

        public XprtzResponse SaveAll(SaveXprtzRequest request)
        {
            try
            {
                return new XprtzResponse() { Success = true, Xprts = _repository.AddXprts(request.Xprts) };
            }
            catch
            {
                return new XprtzResponse() { Success = false };
            }
        }
    }
}

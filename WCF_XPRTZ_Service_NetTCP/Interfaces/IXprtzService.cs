using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_BE.Messages;

namespace WCF_XPRTZ_Service.Interfaces
{
    [ServiceContract]
    interface IXprtzService
    {
        [OperationContract]
        XprtzResponse GetByBadgeNumber(int badgeNumber);

        [OperationContract]
        XprtzResponse GetAll();

        [OperationContract]
        XprtzResponse Save(SaveXprtzRequest request);

        [OperationContract]
        XprtzResponse SaveAll(SaveXprtzRequest request);

        [OperationContract]
        XprtzResponse AddPhoto(SaveFotoRequest request);
    }
}

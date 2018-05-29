using CommonFrame.IService;
using CommonFrame.Model;
using CommonFrame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrame.Service
{
    class Service_Common_Members : SqlServerRepository_T<Common_Members>, IService_Common_Members
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Interfaces
{
    public interface ICombiningLogic
    {
        public Task GetAndCombine();
    }
}
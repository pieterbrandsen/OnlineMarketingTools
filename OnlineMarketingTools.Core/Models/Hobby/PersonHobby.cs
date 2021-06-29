using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Hobby
{
    public interface IPersonHobby
    {
        public HobbyEnum Hobby { get; set; }
    }
    public class PersonHobby : PersonBase, IPersonHobby
    {
        public HobbyEnum Hobby { get; set; }
    }

    public enum HobbyEnum
    {
        Sport,
        Gaming,
        BirdWatching
    }
}



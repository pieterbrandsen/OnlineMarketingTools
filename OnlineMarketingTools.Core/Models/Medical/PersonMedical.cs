using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Medical
{
    public class PersonMedical : PersonBase
    {
        public MedicalEnum MedicalState { get; set; }
    }
    public enum MedicalEnum
    {
        Injured,
        Uninjured
    }
}

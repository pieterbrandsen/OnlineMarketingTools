using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Medical
{
    public interface IPersonMedical
    {
        public MedicalEnum MedicalState { get; set; }
    }
    public class PersonMedical : PersonBase, IPersonMedical
    {
        public MedicalEnum MedicalState { get; set; }
    }
    public enum MedicalEnum
    {
        Injured,
        Uninjured
    }
}

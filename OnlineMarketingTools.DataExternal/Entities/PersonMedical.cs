namespace OnlineMarketingTools.DataExternal.Entities
{
    public class PersonMedical : PersonBase
    {
        public MedicalEnum MedicalState { get; set; }
    }

    public enum MedicalEnum
    {
        Undetermined,
        Good,
        Fair,
        Serious,
        Critical
    }
}
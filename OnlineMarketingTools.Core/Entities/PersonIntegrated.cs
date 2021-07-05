namespace OnlineMarketingTools.Core.Entities
{
	public class PersonIntegrated : PersonIntegratedBase
                                    //External data interfaces, plugin style
                                    //IPersonExternalHobby, IPersonExternalMedical, IPersonExternalProduct
    {
        // Hobby
        public string Hobby {get; set; }
        
        // Medical
        public string MedicalState {get; set; }
        
        // Product
        public string ProductGenre {get; set; }
    
	}
}

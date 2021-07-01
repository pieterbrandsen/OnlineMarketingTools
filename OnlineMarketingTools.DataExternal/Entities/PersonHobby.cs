namespace OnlineMarketingTools.DataExternal.Entities
{
    public class PersonHobby : PersonBase
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



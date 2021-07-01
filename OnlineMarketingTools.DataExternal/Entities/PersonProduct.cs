namespace OnlineMarketingTools.DataExternal.Entities
{
    public class PersonProduct : PersonBase
    {
        public ProductGenreEnum ProductGenre { get; set; }
    }

    public enum ProductGenreEnum
    {
        Sport,
        Gaming,
        Birdwatching,
        Food,
        Medical
    }
}

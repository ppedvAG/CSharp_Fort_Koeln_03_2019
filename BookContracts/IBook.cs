namespace BookContracts
{
    public interface IBook
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        string[] Authors { get; }
        string CoverURL { get; }
        string PreviewURL { get; }
        bool IsFavorite { get; set; }
    }
}
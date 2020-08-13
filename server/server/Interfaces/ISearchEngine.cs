namespace server.Interfaces
{
    public interface ISearchEngine
    {
        string Search(string keywords, int pageNumber);
    }
}
namespace Service;

public interface IStortingPublicationService
{
    Task<List<string>> Get10FirstPublicationTitles(string sessionId);
}

public class StortingPublicationService : IStortingPublicationService
{
    public Task<List<string>> Get10FirstPublicationTitles(string sessionId)
    {
        // TODO: Implement this method
        // fetch publication titles from 10 first publications in a given session

        throw new NotImplementedException();
    }
}

namespace Service;

public interface IStortingVedtakService
{
    Task<List<string>> Get10FirstVedtakTitles(string sessionId);
}

public class StortingVedtakService : IStortingVedtakService
{
    public Task<List<string>> Get10FirstVedtakTitles(string sessionId)
    {
        // TODO: Implement this method
        // fetch vedtak titles from 10 first publications in a given session


        throw new NotImplementedException();
    }
}

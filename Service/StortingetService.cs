using Service.ExtensionMethods;

namespace Service;

public interface IStortingetService
{
    public string GetVedtakTitle(string publicationId);
    public Task<List<string>> GetPublicationIds(string sessionId); 
}
public class StortingetService(HttpClient httpClient) : IStortingetService
{
    public string GetVedtakTitle(string publicationId)
    {
        //TODO: This line is problematic. Why? Can you fix it?
        var publication = httpClient.GetStringAsync($"publikasjon?publikasjonid={publicationId}").Result;
        return publication.ToXDocument().GetVedtakTitle();
    }

    public Task<List<string>> GetPublicationIds(string sessionId)
    {
        //TODO: Implement this call  
        //Call the following endpoint: publikasjoner?publikasjontype=lovvedtak&sesjonid={sessionId}
        //Use the extension methods .ToXDocument() and .GetPublicationIds() 

        throw new NotImplementedException();
    }
}

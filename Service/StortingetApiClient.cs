using Service.ExtensionMethods;
using System.Xml.Linq;

namespace Service;

public interface IStortingetApiClient
{
    public string GetPublicationTitle(string publicationId);
    public Task<List<string>> GetPublicationIds(string sessionId);
}

public class StortingetApiClient(HttpClient httpClient) : IStortingetApiClient
{
    public string GetPublicationTitle(string publicationId)
    {
        // TODO: This line is problematic. Why? Can you fix it?
        var publicationXml = httpClient.GetStringAsync($"publikasjon?publikasjonid={publicationId}").Result;

        var publication = XDocument.Parse(publicationXml);
        return publication.GetPublicationTitle();
    }

    public Task<List<string>> GetPublicationIds(string sessionId)
    {
        // TODO: Implement this method  
        // Call the following endpoint: publikasjoner?publikasjontype=lovvedtak&sesjonid={sessionId}
        // Use the extension method .GetPublicationIds() 

        throw new NotImplementedException();
    }
}

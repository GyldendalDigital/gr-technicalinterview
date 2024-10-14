using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Service.ExtensionMethods;

public static class XDocumentExtensionMethods
{
    public static XDocument ToXDocument(this string xmlString)
    {
        return XDocument.Parse(xmlString);
    }

    public static string GetVedtakTitle(this XDocument xDocument)
    {
        var titleElement = xDocument.XPathSelectElement("//beslo/vedtak/tit[2]");
        if (titleElement == null)
            throw new ArgumentException("Unable to fetch vedtak title");

        return titleElement.Value;
    }

    public static List<string> GetPublicationIds(this XDocument xDocument)
    {
        var namespaceManager = new XmlNamespaceManager(new NameTable());
        var nsPrefix = "ns";

        var rootNamespace = xDocument.Root?.GetDefaultNamespace() ??
                            throw new ArgumentException("Unable to get default namespace");

        namespaceManager.AddNamespace(nsPrefix, rootNamespace.NamespaceName);
        var publicationElements =
            xDocument.XPathSelectElements($"//{nsPrefix}:publikasjoner_oversikt/{nsPrefix}:publikasjoner_liste/{nsPrefix}:publikasjon/{nsPrefix}:id", namespaceManager);

        return publicationElements.Select(r => r.Value).ToList();
    }
}
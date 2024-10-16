using Service.ExtensionMethods;
using System.Xml.Linq;

namespace UnitTests;

[TestClass]
public class XDocumentExtensionMethodsTests
{
    const string PublicationXml =
"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>" +
"<!DOCTYPE Innstilling PUBLIC \"Stortinget 2016 Ny dokumentstruktur\" \"https://www.stortinget.no/dtd/innstillinger.dtd\">" +
"<Innstilling Status=\"Komplett\">" +
    "<Startseksjon/>" +
    "<Sluttseksjon>" +
        "<VedtakTilLov>" +
            "<OmLoven>" +
                "<A Type=\"Innrykk\">om endringer i lov om Statens pensjonskasse\nog enkelte andre lover\n(opphevelse av minstegrensen for rett til medlemskap)</A>" +
            "</OmLoven>" +
        "</VedtakTilLov>" +
    "</Sluttseksjon>" +
    "<Sign/>" +
"</Innstilling>";

    const string PublicationListXml =
"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
"<publikasjoner_oversikt xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://data.stortinget.no\">" +
    "<respons_dato_tid>2024-10-16T07:28:23.8013814+02:00</respons_dato_tid>" +
    "<versjon>1.6</versjon>" +
    "<publikasjoner_liste>" +
        "<publikasjon>" +
            "<id>vedtak-202324-001</id>" +
        "</publikasjon>" +
        "<publikasjon>" +
            "<id>vedtak-202324-002</id>" +
        "</publikasjon>" +
    "</publikasjoner_liste>" +
    "<sesjon_id>2023-2024</sesjon_id>" +
"</publikasjoner_oversikt>";

    private static readonly XDocument PublicationXDocument = XDocument.Parse(PublicationXml);
    private static readonly XDocument PublicationListXDocument = XDocument.Parse(PublicationListXml);

    [TestMethod]
    public void GetPublicationTitle_Should_return_the_publication_title()
    {
        var publicationTitle = PublicationXDocument.GetPublicationTitle();

        Assert.AreEqual("om endringer i lov om Statens pensjonskasse og enkelte andre lover (opphevelse av minstegrensen for rett til medlemskap)", publicationTitle);
    }

    [TestMethod]
    public void GetPublicationIds_Should_return_all_publication_ids()
    {
        var publicationIds = PublicationListXDocument.GetPublicationIds();

        Assert.AreEqual(2, publicationIds.Count);
        Assert.AreEqual("vedtak-202324-001", publicationIds[0]);
        Assert.AreEqual("vedtak-202324-002", publicationIds[1]);
    }
}

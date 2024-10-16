// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Service;

var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient<IStortingetApiClient, StortingetApiClient>(client =>
{
    client.BaseAddress = new Uri("https://data.stortinget.no/eksport/");
});

var serviceProvider = serviceCollection.BuildServiceProvider();

var stortingetApiClient = serviceProvider.GetRequiredService<IStortingetApiClient>();

var publicationTitle = stortingetApiClient.GetPublicationTitle("vedtak-202324-001");
Console.WriteLine(publicationTitle);

// TODO:
// 1. Implement StortingPublicationService and write result to console.
// 2. Write a unit test for the class.
//
// Example session id to use: 2023-2024

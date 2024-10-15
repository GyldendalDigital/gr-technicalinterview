// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Service;

var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient<IStortingetService, StortingetService>(client =>
{
    client.BaseAddress = new Uri("https://data.stortinget.no/eksport/");
});

var serviceProvider = serviceCollection.BuildServiceProvider();

var stortingetService = serviceProvider.GetRequiredService<IStortingetService>();

//TODO: fetch all vedtak titles from all publication in a given session, for instance
//Example session id to use: 2023-2024, fetch the 10 earliest vedtakId 

var vedtakTitle = stortingetService.GetVedtakTitle("vedtak-202324-001");
Console.WriteLine(vedtakTitle);
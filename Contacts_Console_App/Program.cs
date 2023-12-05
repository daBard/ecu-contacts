using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Contacts_Console_App.Repositories;
using Contacts_Console_App.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<ContactRepository>();
    services.AddSingleton<MenuService>();
    services.AddSingleton<ContactService>();
    services.AddSingleton<FileService>();
    services.AddSingleton<UtilService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.DisplayMenu();


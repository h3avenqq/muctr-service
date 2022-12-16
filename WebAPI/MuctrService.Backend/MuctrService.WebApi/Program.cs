using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MuctrService.Application.Common.Mappings;
using System.Reflection;
using MuctrService.Application;
using MuctrService.Persistence;
using MuctrService.Application.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    options.AddProfile(new AssemblyMappingProfile(typeof(IMuctrServiceDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(optoins =>
{
    optoins.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = serviceProvider.GetRequiredService<MuctrServiceDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception e)
    {
       Console.WriteLine(e.Message);
    }
}

app.UseRouting();
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

using EF.Core.Repositories.Extensions;
using FixCompany.Data.context;
using FixCompany.Entity.Command.entityHandlers;
using FixCompany.Entity.Command.entityRequest;
using FixCompany.Web.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.ConfigureData<FixCompanyContext>();
builder.Services.AddDbContextFactory<FixCompanyContext>();
builder.Services.AddMediatR(cnf =>
{
    cnf.RegisterServicesFromAssembly(typeof(AddEntityRequest).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
    typeof(FixCompany.Entity.View.view.ClientPage).Assembly);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FixCompanyContext>();
    db.Database.Migrate();
}

app.Run();
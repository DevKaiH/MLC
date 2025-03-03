using MLC.Services;
using MLC.Components;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<MlcdataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MLCData")));

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

builder.Services.AddMvc();
builder.Services.AddScoped<IAccountSVC, AccountSVC>();
builder.Services.AddScoped<IUserSVC, UserSVC>();
builder.Services.AddScoped<IPMTSVC, PmtSVC>();
builder.Services.AddScoped<IPCFileSVC, PCFileSVC>();
builder.Services.AddScoped<IBMOFileSVC, BMOFileSVC>();
builder.Services.AddScoped<ITRANSSVC, TransSVC>();
builder.Services.AddScoped<IsettingsSVC, SettingSVC>();
builder.Services.AddScoped<IMemberSVC, MemberSVC>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
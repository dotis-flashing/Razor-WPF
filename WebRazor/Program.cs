using Infrastructure.Service;
using Infrastructure.Service.Implement;
using WebRazor.Pages;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddDJ();

builder.Services.AddRazorPages();
//builder.Services.AddScoped<IRentingTransactionService, RentingTransactionService>();
builder.Services.AddDJ();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton(builder.Services.AddDJ());
builder.Services.AddSession(
//    options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//}
);


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

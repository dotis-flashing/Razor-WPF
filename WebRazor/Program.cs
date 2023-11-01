
using Infrastructure.Service.Implement;
using WebRazor;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddDJ();
var configuration = new ConfigurationBuilder()
.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();
builder.Services.AddDJ(configuration);
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton(builder.Services.AddDJ(configuration));
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<CustomerHub>("/customerHub"); // Điều này khai báo một endpoint SignalR
});
app.Run();

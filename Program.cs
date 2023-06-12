using FlatoutCMS;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddContentManagement(builder.Environment.ContentRootPath, builder.Configuration, Assembly.GetAssembly(typeof(Program)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoint => endpoint.MapFallbackToController(
    action: "Index",
    controller: "CMS"
    ));

app.UseAuthorization();

app.MapRazorPages();

app.Run();

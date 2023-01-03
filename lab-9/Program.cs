using System.Text.Json.Serialization;
using lab_9.Hubs;
using lab_9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books API", Description = "Simple, demo API for books and authors", Version = "v1" });
});
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
);
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration["Data:Connection"]));
builder.Services.AddScoped<IBookService, BookRepositoryEF>();
builder.Services.AddSingleton<IClockProvider, DefaultClock>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
});
app.MapHub<ChatHub>("/chatHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
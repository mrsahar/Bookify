using Bookify.Data;
using Bookify.Repos.interfaces;
using Bookify.Repos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookifyDbContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbString")));

builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddScoped<IAuthor, AuthorService>();
builder.Services.AddScoped<IPublisher, PublisherService>();
builder.Services.AddScoped<IBookService, BookService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Genre}/{action=Index}/{id?}");

app.Run();

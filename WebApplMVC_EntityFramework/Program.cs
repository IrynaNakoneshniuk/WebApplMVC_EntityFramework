using WebApplMVC_EntityFramework.Models;
using WebApplMVC_EntityFramework.Services;
using WebApplMVC_EntityFrameworkDZ.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<BooksContext>();
builder.Services.AddScoped<IDatabaseHandlerRepository,DatabaseHandler>();
builder.Services.AddScoped<IBooksPageSorterFilter, BooksPageSorterFilter>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseRouting(); // ����������� EndpointRoutingMiddleware

// ��������� �������������
// ���������� ��������, ������� ����� �������������� � ��������� �������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BooksNews}/{action=Index}/{id?}"
    );
// ��������� �������������


app.Run();
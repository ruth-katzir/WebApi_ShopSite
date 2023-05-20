using entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using NLog.Web;
using WebAppLoginEx1;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IPasswordsService, PasswordsService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IRatingRepository, RatingRepository>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IRatingService, RatingService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

string connectionString = builder.Configuration["connectionString"];

builder.Services.AddDbContext<MyShopSite325593952Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareLogging();

app.UseMiddlewareRating();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    await next(context);
    if (context.Response.StatusCode == 404)
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("./wwwroot/404.html");
    }
});

app.Run();

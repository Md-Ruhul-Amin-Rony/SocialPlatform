using API.Extensions;
using API.Middleware;
using Application.Activities;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers( opt=> 
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
// wew have created ApplicationServiceExtension on Extensions folder class and move all the services there and declare that method here to make the program.cs file beautiful
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
//           builder.Configuration.GetConnectionString("DefaultConnection")));
////builder.Services.AddDbContext<DataContext>(opt =>
////{
////    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
////});
////builder.Services.AddCors(opt=>
////{
////        opt.AddPolicy( "CorsPolicy", policy =>
////        {
////            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
////        });
////});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
//builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly) ;
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
//app.UseRouting();
app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;



try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}   


app.Run();



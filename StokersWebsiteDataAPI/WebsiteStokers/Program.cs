using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using Datalayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StokersContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("StokersConnection"));
});

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 //   .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors(opt =>
{   
    opt.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//testing CI

//app.UseHttpsRedirection();
//http://localhost:5003/swagger/index.html
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();

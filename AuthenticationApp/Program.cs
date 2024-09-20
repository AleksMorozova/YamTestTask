using AuthenticationApp.Configuration;
using AuthenticationApp.DataAccess;
using AuthenticationApp.DataAccess.Repositories;
using AuthenticationApp.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddDbContext<APIDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("APIDbContext")));

builder.Services.AddSingleton<DbConnectionStringBuilder>(new SqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("APIDbContext")
});
builder.Services.AddTransient<IDbConnection>(provider =>
{
    DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

    var builder = provider.GetRequiredService<DbConnectionStringBuilder>();
    var providerFactory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
    var conn = providerFactory.CreateConnection();
    conn.ConnectionString = builder.ConnectionString;
    return conn;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

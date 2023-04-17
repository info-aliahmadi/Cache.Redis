using Cache.Redis.Cache;
using Cache.Redis.Data;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// implement cache provider
builder.Services.AddCacheProvider(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// the default pool size in 1024 
//Make sure that the maxPoolSize corresponds to your usage scenario;
//if it is too low, DbContext instances will be constantly created and disposed,degrading performance.
//Setting it too high may needlessly consume memory as
//unused DbContext instances are maintained in the pool.
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
    options.UseSqlServer(connectionString
    //,builder =>
    //{
    //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    //}
    )
        .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>())
); // the default pool size in 1024 



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

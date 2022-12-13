using Hangfire;
using Hangfire.Storage.SQLite;
using HangFireApp.Services;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config => config
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSQLiteStorage(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHangfireServer();
builder.Services.AddTransient<IServiceManagement, ServiceManagement>();

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

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    DashboardTitle = "Drivers dashboard",
    Authorization = new []
    {
        new HangfireCustomBasicAuthenticationFilter()
        {
            Pass = "password",
            User = "alex"
        }
    }
});

app.MapHangfireDashboard();

RecurringJob.AddOrUpdate<IServiceManagement>(x => x.SyncData(), "0 * * ? * *");  

app.Run();

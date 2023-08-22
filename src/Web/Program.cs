using CinemaBooking.Web.Infrastructure;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHangfireDashboard();

app.MapControllers();

app.Run();
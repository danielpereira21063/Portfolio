using Portfolio.API.Filters;
using Portfolio.Infra.Data.Transaction;
using Portfolio.Infra.IoC;
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddControllers(config => config.Filters.Add(typeof(CustomExceptionFilter)));

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next.Invoke();
    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
    await unitOfWork.CommitAsync();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Urls.Add("https://127.0.0.1:7178");
}
else
{
    //prod
    app.Urls.Add("https://127.0.0.1:7179");
}

app.UseCors("Default");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

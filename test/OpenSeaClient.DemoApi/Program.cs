using OpenSeaClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IOpenSeaClient, OpenSeaHttpClient>(config =>
{
    config.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["OpenSeaApiKey"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/",  ctx =>
    {
        ctx.Response.Redirect("swagger");

        return Task.CompletedTask;
    });
});

app.MapControllers();

app.Run();

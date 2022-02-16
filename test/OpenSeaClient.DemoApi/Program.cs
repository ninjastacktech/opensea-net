using OpenSeaClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IOpenSeaClient, OpenSeaHttpClient>(config =>
{
    // Replace with your OpenSea API Key or comment this line
    config.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["OpenSeaApiKey"]);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cors =>
    {
        var url = builder.Configuration["CrossOriginUrl"];

        if (!string.IsNullOrEmpty(url))
        {
            cors.WithOrigins(url);
        }
        else
        {
            cors.AllowAnyHeader();
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

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

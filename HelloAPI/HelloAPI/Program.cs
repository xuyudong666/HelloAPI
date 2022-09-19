using HelloAPI;
using HelloAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options=>
{
    options.Filters.Add(typeof(ActionParameterValidationFilter));
});

builder.Configuration.AddJsonFile("UISetting.json");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<UISetting>(builder.Configuration);
var app = builder.Build();

foreach (var item in builder.Configuration.AsEnumerable())
{
    Console.WriteLine($"Key:{item.Key},Value:{item.Value}");

}
Console.WriteLine($"content:{builder.Configuration["content"]}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HtpMethodCheckMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

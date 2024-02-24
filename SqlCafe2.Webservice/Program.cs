using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "SqlCafe2.Webservice", Version = "v1" });
});

builder.Services.AddCarter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISaudacao v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapCarter();

await app.RunAsync();

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

services.AddCors();

// Configure TokenOptions from json file as class
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
services.AddSingleton(signingConfigurations);

services.AddSingleton<ITokenHandler, TokenHandler>();

services.AddOurAuthentication(tokenOptions, signingConfigurations);

services.AddSwaggerExtension();

services.AddDbContext<MainDBContext>();

//--------------Injection Services--------------
services.AddCustomServices();
services.AddCustomBusinessLogic();

services.AddExtensionsService();

//--------------Injection Services--------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
    app.UseCustomSwagger();
    app.UseDeveloperExceptionPage();

// global cors policy
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

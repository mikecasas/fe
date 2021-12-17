global using FastEndpoints;
global using FastEndpoints.Security; //add this


using Microsoft.OpenApi.Models;
using FastEndpoints.Swagger; //add this

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("TokenSigningKey"); //add this
//builder.Services.AddSwagger(); //add this


builder.Services.AddSwagger(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    options.CustomSchemaIds(x => x.Name);
    options.TagActionsBy(x => new[] { x.RelativePath?.Split('/')[1] });
});


var app = builder.Build();
app.UseAuthentication(); //add this
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwagger(); //add this
app.UseSwaggerUI(); //add this
app.Run();
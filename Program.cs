using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources.Annotations;
using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.GTR.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNpgsql<GTRContext>(builder.Configuration["Database:ConnectionString"],
    options => { options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); });

builder.Services.AddJsonApi<GTRContext>(options =>
{
    options.DefaultAttrCapabilities = AttrCapabilities.AllowView |
                                      AttrCapabilities.AllowFilter |
                                      AttrCapabilities.AllowSort;

    options.DefaultHasManyCapabilities = HasManyCapabilities.AllowView |
                                         HasManyCapabilities.AllowInclude |
                                         HasManyCapabilities.AllowFilter;

    options.DefaultHasOneCapabilities = HasOneCapabilities.AllowView |
                                        HasOneCapabilities.AllowInclude;

    options.MaximumPageSize = new PageSize(100);
    options.IncludeTotalResourceCount = true;
    options.AllowUnknownFieldsInRequestBody = false;
    options.IncludeJsonApiVersion = true;
    options.IncludeRequestBodyInErrors = true;
    options.IncludeExceptionStackTraceInErrors = false;
});

WebApplication app = builder.Build();

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseJsonApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

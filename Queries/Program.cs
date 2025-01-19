using AzureFunctions.Extensions.Swashbuckle;
using CQRS.Data;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure;
using Queries;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddDbContext<CQRSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CQRSContext") ?? throw new InvalidOperationException("Connection string 'CQRSContext' not found.")));

// Add services to the container.
builder.Services.AddRepository()
                .AddRequestHandlers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwashBuckle(opts => {
    opts.AddCodeParameter = true;
    opts.Documents = new[] {
                    new SwaggerDocument {
                        Name = "v1",
                            Title = "Swagger document",
                            Description = "Integrate Swagger UI With Azure Functions",
                            Version = "v2"
                    }
                };
    opts.ConfigureSwaggerGen = x => {
        x.CustomOperationIds(apiDesc => {
            return apiDesc.TryGetMethodInfo(out MethodInfo mInfo) ? mInfo.Name : default(Guid).ToString();
        });
    };
});
builder.Build().Run();

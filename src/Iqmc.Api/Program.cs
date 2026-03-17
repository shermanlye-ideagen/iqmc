using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.MapGet("/health", () => new { Status = "healthy", Product = "IQMC", Version = "1.0.0" });

app.MapGet("/audits", () => new[]
{
    new { Id = 1, Title = "ISO 9001 Internal Audit", Status = "Scheduled", DueDate = "2026-04-01" },
    new { Id = 2, Title = "Supplier Quality Review", Status = "In Progress", DueDate = "2026-03-25" }
});

app.MapPost("/findings", (FindingRequest req) =>
    new { Message = $"Finding '{req.Title}' recorded", Classification = req.Classification });

app.Run();

record FindingRequest(string Title, string Classification, string AuditId);

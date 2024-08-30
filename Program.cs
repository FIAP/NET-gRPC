using InvestmentGrpcService.Services;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

// Adicione o serviço de reflexão gRPC
builder.Services.AddGrpcReflection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Ative o serviço de reflexão gRPC no modo de desenvolvimento
    app.MapGrpcReflectionService();
}

// Configure o pipeline de requisições HTTP.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();

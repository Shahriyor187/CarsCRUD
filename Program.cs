using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure services
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.Configure(app.Environment);

app.Run();
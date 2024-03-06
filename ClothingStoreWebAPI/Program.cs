// New instance of the WebApplicationBuilder class with preconfigured defaults
using ClothingStoreWebAPI.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Collection of services for the application to compose
string CorsPolicy = "CorsPolicy";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: CorsPolicy, policy =>
	{
		policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
	});
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClothingStoreContext>();

// Building of the WebApplication
WebApplication app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(CorsPolicy);
app.UseAuthorization();
app.MapControllers();

// Running of the WebApplication
app.Run();

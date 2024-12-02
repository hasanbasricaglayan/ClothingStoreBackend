using System.Text;
using ClothingStoreBackend.Data;
using ClothingStoreBackend.Mappers.CategoryMappers;
using ClothingStoreBackend.Mappers.OrderMappers;
using ClothingStoreBackend.Mappers.OrderProductMappers;
using ClothingStoreBackend.Mappers.ProductMappers;
using ClothingStoreBackend.Mappers.UserMappers;
using ClothingStoreBackend.Services.AuthenticationServices;
using ClothingStoreBackend.Services.CategoryRepositories;
using ClothingStoreBackend.Services.OrderRepositories;
using ClothingStoreBackend.Services.ProductRepositories;
using ClothingStoreBackend.Services.UserRepositories;
using Microsoft.IdentityModel.Tokens;

// New instance of the WebApplicationBuilder class with preconfigured defaults
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

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICategoryMapper, CategoryMapper>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderProductMapper, OrderProductMapper>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
	options.TokenValidationParameters = new()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Authentication:Issuer"],
		ValidAudience = builder.Configuration["Authentication:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]!))
	};
});
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Running of the WebApplication
app.Run();

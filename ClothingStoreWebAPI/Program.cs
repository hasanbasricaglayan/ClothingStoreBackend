using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Mappers.CategoryMappers;
using ClothingStoreWebAPI.Mappers.OrderMappers;
using ClothingStoreWebAPI.Mappers.OrderProductMappers;
using ClothingStoreWebAPI.Mappers.ProductMappers;
using ClothingStoreWebAPI.Mappers.UserMappers;
using ClothingStoreWebAPI.Services.CategoryRepositories;
using ClothingStoreWebAPI.Services.OrderRepositories;
using ClothingStoreWebAPI.Services.ProductRepositories;
using ClothingStoreWebAPI.Services.UserRepositories;
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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<ICategoryMapper, CategoryMapper>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
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
		IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]!))

	};
});

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

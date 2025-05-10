using demoFinal.Data;
using demoFinal.Mapper;
using demoFinal.Repository;
using demoFinal.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(opciones =>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("conexion1")));

//Agregamos los repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

//Se agrega los Mappers
builder.Services.AddAutoMapper(typeof(CategoriaMapper));
builder.Services.AddAutoMapper(typeof(ProductoMapper));
    

// Swagger Configuration (opcional, si estás usando Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//CONTROLADORES
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors("PoliticaCors");
app.UseAuthorization();
app.MapControllers();

app.Run();

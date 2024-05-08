using System.Reflection;
using AutoMapper;
using Delivery.Api.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
string connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("La variable de entorno no está configurada.");
    return;
}

// Crear el cliente de MongoDB
MongoClient mongoClient = new MongoClient(connectionString);

// Obtener o crear la base de datos
IMongoDatabase database = mongoClient.GetDatabase("delivery");

IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("test");

// Crear un documento para insertar
var document = new BsonDocument
{
    { "clave", "valor" },
    { "otra_clave", "otro_valor" }
};

collection.InsertOne(document);
builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetEntryAssembly()));
builder.Services.AddSingleton(database);

var config = new MapperConfiguration(cfg => { });

IMapper mapper = config.CreateMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(); // ← AGREGAR ESTO

var app = builder.Build();

app.MapGet("/api/Avatar", async ([FromServices] IHttpClientFactory httpFactory) =>
{
    var http = httpFactory.CreateClient(); // ← CAMBIAR ESTO

    int avatarID = Random.Shared.Next(1, 151);

    var response = await http.GetStringAsync(
        $"https://pokeapi.co/api/v2/pokemon/{avatarID}");

    using var doc = JsonDocument.Parse(response);
    var imageUrl = doc.RootElement
        .GetProperty("sprites")
        .GetProperty("front_default")
        .GetString();

    return Results.Ok(new
    {
        avatarID = avatarID,
        imageUrl = imageUrl
    });
});

// Endpoint de prioridad — recibe descripción y devuelve Alta/Media/Baja
app.MapPost("/api/Priority", ([FromBody] PriorityRequest request) =>
{
    var priority = EvaluatePriority(request.Description);
    return Results.Ok(new { priority = priority });
});

// Lógica de negocio
string EvaluatePriority(string description)
{
    var altaKeywords = new[] { "caído", "error", "crítico", "no funciona", "urgente", "bloqueado" };
    var bajaKeywords = new[] { "consulta", "duda", "sugerencia", "mejora" };

    var desc = description.ToLower();

    if (altaKeywords.Any(k => desc.Contains(k)))
        return "Alta";

    if (bajaKeywords.Any(k => desc.Contains(k)))
        return "Baja";

    return "Media"; // default según tu croquis
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

record PriorityRequest(string Description);
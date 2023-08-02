using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UIPathDummyAPI.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Dummy API for UiPath Learning");

app.MapPost("/csv", ([FromBody] CSVData csvData) =>
{
    //var dataToArray = csvData.Data?.Split(" ");
    //Console.WriteLine($"{dataToArray?[1]} - Height: {dataToArray?[3]}, Weight: {dataToArray?[5]}");
    Console.WriteLine("CSV Headers: " + csvData.Headers);
    Console.WriteLine("Sent CSV Data: " + csvData.Data);
    Console.WriteLine();

    if(csvData == null || csvData.Data == "")
    {
        return Results.BadRequest("No data received.");
    }

    return Results.Ok("Sent CSV Data: " + csvData.Data);
});

app.MapPost("/bulktrees", ([FromBody] TreeArray treesData) =>
{
    if(treesData.Data == null)
    {
        return Results.BadRequest();
    }

    var arr = treesData.Data;
    foreach(var tree in arr)
    {
        Console.WriteLine($"{tree.Index} - Girth: {tree.Girth} Height: {tree.Height} Volume: {tree.Volume}");
    }
    return Results.Ok();
});

app.Run();

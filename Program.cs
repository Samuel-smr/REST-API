using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dataa;
using WebApplication1.Modelss;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddSingleton<ICategory, CategoryDal>();
builder.Services.AddSingleton<IInstructor, InstructorADO>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
//app.MapGet("api/v1/helloservices/{name}", (string name) => $"Hello {name}"); //url jadi langsung kasi nama setelah /
*/
/*app.MapGet("api/v1/categories", (ICategory categoryData) =>{
    Category category= new Category();
    category.categoryId = 1;
    category.categoryName = "ASP.NET Core";
    return category;
});*/

// app.MapGet("api/v1/categories/{id}", (ICategory categoryData, int id)=>{
//     var category = categoryData.GetCategoryById(id);
//     return category;
// });

// app.MapPost("api/v1/categories", (ICategory categoryData, Category category)=>{
//     var newCategory = categoryData.AddCategory(category);
//     return newCategory;
// });

app.MapPost("api/v1/instructors", (IInstructor instructorData, Instructor instructor)=>{
    var newInstructor = instructorData.AddInstructor(instructor);
    return newInstructor;
});

app.MapPut("api/v1/instructors", (IInstructor instructorData, Instructor instructor)=>{
    var updatedInstructor = instructorData.updateInstructor(instructor);
    return updatedInstructor;
});

app.MapDelete("api/v1/instructors/{id}", (IInstructor instructorData, int id)=>{
    instructorData.DeleteInstructor(id);
    return Results.NoContent();
});

app.MapGet("api/v1/instructors/{id}", (IInstructor instructorData, int id)=>{
    var instructors = instructorData.GetInstructorById(id);
    return instructors;
});

app.MapGet("api/v1/instructors", (IInstructor instructorData)=>{
    var instructors = instructorData.GetInstructors();
    return instructors;
});



app.Run();


/*
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/

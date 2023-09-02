using InvestigadorAPI;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<InvestigadorContext>(builder.Configuration.GetConnectionString("connInvestigador"));



var app = builder.Build();

app.MapGet("/dbcon", async ([FromServices] InvestigadorContext dbContext) =>
{
	dbContext.Database.EnsureCreated();
	return Results.Ok("Base de datos lista");
});

app.MapGet("/api/investigador", async ([FromServices] InvestigadorContext context) => {

	return Results.Ok(context.Investigadores);

});

app.MapGet("/api/investigador/{id}", async ([FromServices] InvestigadorContext context, [FromRoute] Guid id) => {

	var tarea = context.Investigadores.Find(id);

    if (tarea == null)
    {
		return Results.NotFound();
    }
	else
	{
		return Results.Ok(tarea);
	}

});

app.MapGet("/api/proyecto", async ([FromServices] InvestigadorContext context) => {

	return Results.Ok(context.Proyectos);

});

app.MapGet("/api/proyecto/{id}", async ([FromServices] InvestigadorContext context, [FromRoute] Guid id) => {

	var tarea = context.Proyectos.Find(id);

	if (tarea == null)
	{
		return Results.NotFound();
	}
	else
	{
		return Results.Ok(tarea);
	}

});


app.MapPost("/api/proyecto", async ([FromServices] InvestigadorContext context, [FromBody] Proyecto proyecto) => {

	proyecto.proyectoID = Guid.NewGuid();
	proyecto.fechaInicio = DateTime.Now;

	await context.Proyectos.AddAsync(proyecto);

	await context.SaveChangesAsync();

	return Results.Ok(context.Proyectos);

});


app.MapPost("/api/investigador", async ([FromServices] InvestigadorContext context, [FromBody] Investigador investigador) => {

	investigador.InvestigadorID = Guid.NewGuid();


	await context.Investigadores.AddAsync(investigador);

	await context.SaveChangesAsync();

	return Results.Ok(context.Proyectos);

});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

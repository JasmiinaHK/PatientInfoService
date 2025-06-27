var builder = WebApplication.CreateBuilder(args);

// Ovdje dodajemo podršku za kontrolere
builder.Services.AddControllers();

var app = builder.Build();

// Ovdje dodajemo podršku za API rute
app.UseAuthorization();

app.MapControllers();

app.Run();

// Ovo je potrebno ako želimo kasnije da pišemo testove
public partial class Program { }


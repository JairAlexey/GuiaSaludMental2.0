using WebApplicationProyecto.Configurations;
using WebApplicationProyecto.Services;
using Microsoft.Extensions.Configuration;
using WebApplicationProyecto.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Obtener la configuraci�n del builder
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura y registra ApiSettings en el contenedor de servicios usando la secci�n 'ApiSettings' del archivo de configuraci�n.
builder.Services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

// Agrega el servicio HttpClient al contenedor. Esto permite inyectar y usar HttpClient en cualquier parte de la aplicaci�n.
builder.Services.AddHttpClient();

// Registra el servicio ApiService como 'Scoped', lo que significa que se crear� una instancia por cada solicitud. 
builder.Services.AddScoped<IApiService, ApiService>();//Iyectamos nuestra interaz con nuestra clase

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura la ruta predeterminada para que apunte a la acci�n 'Login' en el controlador 'Home'.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=PaginaInicio}/{id?}");

app.Run();

using WebApplicationProyecto.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WebApplicationProyecto.Configurations;
using WebApplicationProyecto.Models;
using System.Drawing;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationProyecto.Services
{
    public class ApiService : IApiService
    {
        // URL base de la API con la que se interactúa.

        private readonly string _baseUrl; //Se separa porque se hace mas facil modificarse si se cambia la ip o el dominio

        // Cliente HTTP utilizado para hacer las peticiones a la API.
        private readonly HttpClient _httpClient;

        // Constructor: inicializa el URL base y el cliente HTTP.
        public ApiService(IOptions<ApiSettings> apiSettings, HttpClient httpClient) //Constructor
        {
            _baseUrl = apiSettings.Value.BaseUrl; //Para llamar
            _httpClient = httpClient;
        }

        public async Task<List<Usuarios>> getUsuario()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/User"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<List<Usuarios>>(content);
                return usuario;
            }
            return null;
        }

        public async Task<Usuarios> getUsuario(int IdUsuario)
        {
          

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/User/{IdUsuario}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuarios>(content);
                return usuario;
            }
            return null;
        }

        public async Task<bool> addUsuario(Usuarios usuarios)
        {
            var jsonString = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/User/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateUsuario(int IdUsuario, Usuarios usuarios)
        {
            var jsonString = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/User/{IdUsuario}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteUsuario(int IdUsuario)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/User/{IdUsuario}");

            return response.IsSuccessStatusCode;
        }




        //METODOAS DE CAPACITACIONES

        public async Task<List<Capacitaciones>> getCapacitaciones()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Capacitaciones"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var capacitaciones = JsonConvert.DeserializeObject<List<Capacitaciones>>(content);
                return capacitaciones;
            }
            return null;
        }

        public async Task<Capacitaciones> getCapacitaciones(int IdCapacitaciones)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var capacitaciones = JsonConvert.DeserializeObject<Capacitaciones>(content);
                return capacitaciones;
            }
            return null;
        }

        public async Task<bool> addCapacitaciones(Capacitaciones capacitaciones)
        {
            var jsonString = JsonConvert.SerializeObject(capacitaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Capacitaciones/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateCapacitaciones(int IdCapacitaciones, Capacitaciones capacitaciones)
        {

            var jsonString = JsonConvert.SerializeObject(capacitaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteCapacitaciones(int IdCapacitaciones)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}");

            return response.IsSuccessStatusCode;
        }



        //METODOS DE LOGIN Y DETERMINAR ROL PARA LOS PERMISOS

        public async Task<bool> IniciarSesion(Usuarios inicioSesion)
        {
            // Asegúrate de que este método esté obteniendo los usuarios correctamente
            var usuarios = await getUsuario();

            // Verificar si hay algún usuario que coincida con las credenciales proporcionadas
            var usuario = usuarios.FirstOrDefault(u => u.Correo == inicioSesion.Correo && u.Password == inicioSesion.Password);

            // Devolver true si se encuentra un usuario que coincida con las credenciales, de lo contrario, devolver false
            return usuario != null;

        }

        public async Task<bool> DeterminarRol(Usuarios inicioSesion)
        {
            var usuarios = await getUsuario();

            // Verificar si el usuario tiene el rol de administrador
            var esAdministrador = usuarios.Any(u => u.Rol == "admin");

            // Devolver true si el usuario es administrador, de lo contrario, devolver false
            return esAdministrador;
        }


    }
}

using WebApplicationProyecto.Models;

namespace WebApplicationProyecto.Services
{
    public interface IApiService
    {
        Task<List<Usuarios>> getUsuario();
        Task<Usuarios> getUsuario(int IdUsuario);
        Task<bool> addUsuario(Usuarios usuarios);
        Task<bool> updateUsuario(int IdUsuario, Usuarios usuarios);
        Task<bool> deleteUsuario(int IdUsuario);

        Task<List<Capacitaciones>> getCapacitaciones();
        Task<Capacitaciones> getCapacitaciones(int IdCapacitaciones);
        Task<bool> addCapacitaciones(Capacitaciones capacitaciones);
        Task<bool> updateCapacitaciones(int IdCapacitaciones, Capacitaciones capacitaciones);
        Task<bool> deleteCapacitaciones(int IdCapacitaciones);

        Task<bool> IniciarSesion(Usuarios usuarios);

        Task<bool> DeterminarRol(Usuarios usuarios);
    }
}

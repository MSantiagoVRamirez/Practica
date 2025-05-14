namespace Practica.Server.Services
{
    public interface IPruebaService
    {
        Task<decimal> ListarMedicamentos();
        Task<decimal?> sumaMedicamentos();
        Task<decimal> SumaEstados(int presentacionId)

    }
}

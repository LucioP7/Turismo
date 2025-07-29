
namespace TurismoServices.Class
{
    public static class ApiEndpoints
    {
        public static string Actividad { get; set; } = "actividades";
        public static string Administrador { get; set; } = "administradores";
        public static string Cliente { get; set; } = "clientes";
        public static string Destino { get; set; } = "destinos";
        public static string Itinerario { get; set; } = "itinerarios";

        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Actividad) => Actividad,
                nameof(Administrador) => Administrador,
                nameof(Destino) => Destino,
                nameof(Itinerario) => Itinerario,
                nameof(Cliente) => Cliente,

                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}

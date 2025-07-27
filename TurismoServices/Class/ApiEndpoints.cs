
namespace TurismoServices.Class
{
    public static class ApiEndpoints
    {
        public static string Actividad { get; set; } = "Actividades";
        public static string Administrador { get; set; } = "Administradores";
        public static string Cliente { get; set; } = "Clientes";
        public static string Destino { get; set; } = "Destinos";
        public static string Itinerario { get; set; } = "Itinerarios";

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

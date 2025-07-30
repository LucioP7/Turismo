namespace TurismoServices.Class
{
    public static class ApiEndpoints
    {
        public static string Actividad { get; set; } = "actividades";
        public static string Administrador { get; set; } = "administradores";
        public static string Cliente { get; set; } = "clientes";
        public static string Destino { get; set; } = "destinos";
        public static string Itinerario { get; set; } = "itinerarios";
        public static string Venta { get; set; } = "ventas";
        public static string DetalleVenta { get; set; } = "detallesventas";

        public static string GetEndpoint(string name)
        {
            return name.ToLower() switch
            {
                "actividad" => Actividad,
                "administrador" => Administrador,
                "cliente" => Cliente,
                "destino" => Destino,
                "itinerario" => Itinerario,
                "venta" => Venta,
                "detalleventa" => DetalleVenta,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}

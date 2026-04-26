namespace ARPATicket.Priority.Handlers
{
    public class PriorityHandlerBaja : PriorityHandler
    {
        protected static readonly string[] _keywords =
            { "consulta", "pregunta", "duda", "información", "no urgente", "sugerencia", "mejora" }; // Palabras clave para prioridad Baja

        public override string? Handle(string description)
        {
            if (_keywords.Any(k => description.Contains(k, StringComparison.OrdinalIgnoreCase))) 
                return "Baja"; // Si la descripción contiene alguna de las palabras clave, se asigna prioridad Baja
            return _next?.Handle(description); // Si no se encuentra ninguna palabra clave, se delega al siguiente handler en la cadena
        }
    }
}

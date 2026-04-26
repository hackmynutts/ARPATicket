namespace ARPATicket.Priority.Handlers
{
    public class PriorityHandlerAlta : PriorityHandler
    {
        private static readonly string[] _keywords =
            { "caído", "error", "errores", "crítico", "no funciona", "urgente", "bloqueado" }; // Palabras clave para prioridad Alta

        public override string? Handle(string description)
        {
            if (_keywords.Any(k => description.Contains(k, StringComparison.OrdinalIgnoreCase))) 
                return "Alta"; // Si la descripción contiene alguna de las palabras clave, se asigna prioridad Alta

            return _next?.Handle(description); // Si no se encuentra ninguna palabra clave, se delega al siguiente handler en la cadena
        }
    }
}

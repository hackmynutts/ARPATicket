namespace ARPATicket.Priority.Handlers
{
    public abstract class PriorityHandler
    {
        protected PriorityHandler? _next;

        public PriorityHandler SetNext(PriorityHandler next)
        {
            _next = next;
            return next;
        }
        public abstract string? Handle(string description); // metodo abstracto que cada handler implementará como ellos quieran en base a las palabras clave que tengan para cada prioridad
    }
}

namespace ARPATicket.Priority.Handlers
{
    public class PriorityHandlerDefault : PriorityHandler
    {
        public override string? Handle(string description)
        {
            return "Media"; // Si ningún handler anterior asignó una prioridad, se asigna la prioridad Media por defecto
        }//sin next ya que siempre se correra al final de la cadena y no hay nada más a quien delegar
    }
}

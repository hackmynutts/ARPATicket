namespace ARPATicket.API.Commands
{
    public interface ICommand<TResult>
    {
        Task<TResult> Execute();
    }
}

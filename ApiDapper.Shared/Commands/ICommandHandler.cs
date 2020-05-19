namespace ApiDapper.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        // Como o handler server para escrita e leitura, foi criado uma interface para o retorno
        ICommandResult Handle(T command);
    }
}
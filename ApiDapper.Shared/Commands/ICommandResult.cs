namespace ApiDapper.Shared.Commands
{
    // Criado para retorno no handler
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
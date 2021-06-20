using Novabase.Domain.Commands.Contracts;

namespace Novabase.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
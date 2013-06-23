using System.Text;

namespace ShoppingCenter
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output);
    }
}

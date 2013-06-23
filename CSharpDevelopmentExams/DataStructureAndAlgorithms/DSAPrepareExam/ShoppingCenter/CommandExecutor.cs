using System;
using System.Linq;
using System.Text;

namespace ShoppingCenter
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandTypes.AddProduct:
                    AddProductCommand(catalog, command, output);
                    break;
                case CommandTypes.DeleteProducts:
                    DeleteProductsCommand(catalog, command, output);
                    break;
                case CommandTypes.FindProductsByName:
                    FindProductsByNameCommand(catalog, command, output);
                    break;
                case CommandTypes.FindProductsByPriceRange:
                    FindProductsByPriceRangeCommand(catalog, command, output);
                    break;
                case CommandTypes.FindProductsByProducer:
                    FindProductsByProducerCommand(catalog, command, output);
                    break;
                default:
                    throw new ArgumentException("Unknown command: " + command.Type.ToString());
            }
        }

        private static void AddProductCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            catalog.Add(new Content(command.Parameters));
            output.AppendLine("Product added");
        }

        private static void DeleteProductsCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            int updatedCount = 0;

            if (command.Parameters.Length > 1)
            {
                updatedCount = catalog.Delete(command.Parameters[0], command.Parameters[1]);
            }
            else
            {
                updatedCount = catalog.Delete(string.Empty, command.Parameters[0]);
            }
            
            output.AppendLine(String.Format("{0} products deleted", updatedCount));
        }

        private static void FindProductsByNameCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            var contentList = catalog.GetContentByName(command.Parameters[0]);
            if (contentList != null && contentList.Count() > 0)
            {
                foreach (IContent content in contentList)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
            else
            {
                output.AppendLine("No products found");
            }
        }

        private void FindProductsByPriceRangeCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            var contentList = catalog.GetContentByPriceRange(double.Parse(command.Parameters[0]), double.Parse(command.Parameters[1]));
            if (contentList != null && contentList.Count() > 0)
            {
                foreach (IContent content in contentList)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
            else
            {
                output.AppendLine("No products found");
            }
        }

        private void FindProductsByProducerCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            var contentList = catalog.GetContentByProducer(command.Parameters[0]);
            if (contentList != null && contentList.Count() > 0)
            {
                foreach (IContent content in contentList)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
            else
            {
                output.AppendLine("No products found");
            }
        }

        private static void IsValidParameters(ICommand command)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Invalid number of parameters for command " + command.Type.ToString());
            }
        }
    }
}
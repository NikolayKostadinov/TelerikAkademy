using System.Collections.Generic;

namespace ShoppingCenter
{
    public interface ICatalog
    {
        void Add(IContent content);

        int Delete(string parameters, string parameters1);

        IEnumerable<IContent> GetContentByName(string name);

        IEnumerable<IContent> GetContentByProducer(string producer);

        IEnumerable<IContent> GetContentByPriceRange(double minPrice, double maxPrice);
    }
}

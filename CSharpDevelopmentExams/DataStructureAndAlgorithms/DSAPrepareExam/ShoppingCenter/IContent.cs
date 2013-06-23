using System;

namespace ShoppingCenter
{
    public interface IContent : IComparable
    {
        string Name { get; set; }

        double Price { get; set; }

        string Producer { get; set; }

        string TextRepresentation { get; set; }
    }
}

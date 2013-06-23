using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    public class Catalog : ICatalog
    {
        private readonly OrderedMultiDictionary<string, IContent> name;
        private readonly OrderedMultiDictionary<string, IContent> producer;
        private readonly OrderedMultiDictionary<double, IContent> price;

        public Catalog()
        {
            this.name = new OrderedMultiDictionary<string, IContent>(true);
            this.price = new OrderedMultiDictionary<double, IContent>(true);
            this.producer = new OrderedMultiDictionary<string, IContent>(true);
        }

        public void Add(IContent content)
        {
            this.name.Add(content.Name, content);
            this.price.Add(content.Price, content);
            this.producer.Add(content.Producer, content);
        }

        public int Delete(string name, string producer)
        {
            var theElements = 0;
            ICollection<IContent> contentToList = new Collection<IContent>();

            if (!string.IsNullOrEmpty(name))
            {
                //remove by name and producer
                contentToList = this.name[name].Where(c => c.Producer == producer).ToList();
                foreach (IContent content in contentToList)
                {
                    this.price.Remove(content.Price, content);
                    this.producer.Remove(content.Producer, content);
                    this.name.Remove(content.Name, content);
                    theElements++;
                }
            }
            else
            {
                //remove by producer only
                contentToList = this.producer[producer];
                foreach (IContent content in contentToList)
                {
                    this.name.Remove(content.Name, content);
                    this.price.Remove(content.Price, content);
                    
                    theElements++;
                }
            }

            this.producer.Remove(producer);

            return theElements;
        }

        public IEnumerable<IContent> GetContentByName(string value)
        {
            return this.name[value];
            //var result = from c in this.name[value]
            //             select c;
            //if (result == null)
            //{
            //    throw new NullReferenceException("GetListContent return null selected list");
            //}
            //return result;
        }

        public IEnumerable<IContent> GetContentByProducer(string value)
        {
            return this.producer[value];
            //var result = from c in this.producer[value]
            //             select c;
            //if (result == null)
            //{
            //    throw new NullReferenceException("GetListContent return null selected list");
            //}
            //return result;
        }

        public IEnumerable<IContent> GetContentByPriceRange(double minPrice, double maxPrice)
        {
            return this.price.Range(minPrice, true, maxPrice, true).Values;
        }
    }
}
using System;

namespace ShoppingCenter
{
    public class Content : IContent
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }
        
        public string TextRepresentation
        {
            get
            {
                return this.ToString();
            }
            set { }
        }

        public Content(string[] commandParams)
        {
            this.Name = commandParams[(int)ContentItemTypes.Name];
            this.Price = double.Parse(commandParams[(int)ContentItemTypes.Price]);
            this.Producer = commandParams[(int)ContentItemTypes.Producer];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResul;
            }
            
            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            var output = "{" + String.Format("{0};{1};{2}",
                                        this.Name, this.Producer,
                                        this.Price.ToString("0.00")) + "}";
            return output;
        }
    }
}
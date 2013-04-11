using System;
using System.Text;

namespace CodeFormatting
{
    class Event : IComparable
    {
        private readonly DateTime date;
        private readonly String title;
        private readonly String location;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            if (this == null && other == null)
            {
                return 0;
            }
            else if (this == null)
            {
                return -1;
            }
            else if (other == null)
            {
                return 1;
            }
            else
            {
                int byDate = this.date.CompareTo(other.date);
                int byTitle = this.title.CompareTo(other.title);
                int byLocation = this.location.CompareTo(other.location);
                
                if (byDate == 0)
                {
                    if (byTitle == 0)
                    {
                        return byLocation;
                    }
                    else
                    {
                        return byTitle;
                    }
                }
                else
                {
                    return byDate;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }
         
            return toString.ToString();
        }
    }
}
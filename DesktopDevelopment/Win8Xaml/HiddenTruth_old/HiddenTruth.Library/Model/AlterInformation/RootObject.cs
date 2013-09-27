using System;
using System.Linq;
using System.Text;

namespace HiddenTruth.Library.Model.AlterInformation
{
    public class RootObject
    {
        public ResponseData responseData { get; set; }
        public object responseDetails { get; set; }
        public int responseStatus { get; set; }
    }
}

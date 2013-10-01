using System.Runtime.Serialization;

namespace HiddenTruth.Library.Model.AlterInformation
{
    [DataContract]
    public class ResponseData
    {
        [DataMember]
        public Feed Feed { get; set; }
    }
}
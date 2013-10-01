﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HiddenTruth.Library.Model.AlterInformation
{
    [DataContract]
    public class MediaGroup
    {
        [DataMember]
        public List<Content> Contents { get; set; }
    }
}
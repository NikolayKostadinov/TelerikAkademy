using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace HiddenTruth.Library.Model
{
    [DataContract]
    [KnownType("GetKnownTypes")]  // for serialization
    public class ResultContract
    {
        private static List<Type> KnownTypes { get; set; }

        public static List<Type> GetKnownTypes()
        {
            return KnownTypes;
        }

        static ResultContract()
        {
            KnownTypes = new List<Type>();
            try
            {
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (!type.IsAbstract && type.IsSubclassOf(typeof(ResultContract)))
                    {
                        KnownTypes.Add(type);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

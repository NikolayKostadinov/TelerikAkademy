using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace HiddenTruth.Library.Helpers
{
    public class DynamicDictionary : DynamicObject, INotifyPropertyChanged
    {
        public DynamicDictionary()
        {
            InternalValues = new Dictionary<string, object>();
        }

        //public DynamicRow Row { get; protected set; }
        protected Dictionary<string, object> InternalValues { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return InternalValues.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {

            InternalValues[binder.Name] = value;
            FirePropertyChanged(binder.Name);
            return true;
        }

        public void FirePropertyChanged(string propName)
        {
            var propChange = PropertyChanged;
            if (propChange != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DynamicDictionary<TValue> : DynamicObject
    {
        private Dictionary<string, TValue> _dictionary;

        public DynamicDictionary()
        {
            _dictionary = new Dictionary<string, TValue>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            TValue data;
            if (!_dictionary.TryGetValue(binder.Name, out data))
            {
                throw new KeyNotFoundException("There's no key by that name");
            }

            result = (TValue) data;

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_dictionary.ContainsKey(binder.Name))
            {
                _dictionary[binder.Name] = (TValue) value;
            }
            else
            {
                _dictionary.Add(binder.Name, (TValue) value);
            }

            return true;
        }
    }
}

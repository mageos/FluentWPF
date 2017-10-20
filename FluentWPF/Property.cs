using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{

    public class Property<T> : IProperty<T>
    {
        protected T _value;
        protected T _oldValue;
        protected bool _isSet = false;

        public Property(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public T Value => _value;

        public bool HasChanges => EqualityComparer<T>.Default.Equals(_oldValue, _value);

        object IProperty.Value => Value;

        public bool Set(T newValue)
        {
            if (!_isSet)
            {
                _value = newValue;
                _isSet = true;
                return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{
    /// <summary>
    /// Interface representing a property
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// The name of the property
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The current value of the property
        /// </summary>
        object Value { get; }        
    }

    /// <summary>
    /// Interface describing a typed property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProperty<T> : IProperty
    {
        new T Value { get; }

        bool Set(T newValue);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{
    public class PropertyHasChangesChangedEventArgs
    {
        public PropertyHasChangesChangedEventArgs(string propertyName)
        {
            Guard.AgainstNullOrEmpty(propertyName, nameof(propertyName));

            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }

    public interface INotifyPropertyHasChanges
    {
        event EventHandler<PropertyHasChangesChangedEventArgs> PropertyHasChangesChanged;

        bool HasChanges(string propertyName);
    }
}

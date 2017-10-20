using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{
    /// <summary>
    /// Uses a CustomTypeDescriptor to automatically decorate a view model
    /// </summary>
    /// <typeparam name="TModel">The POCO class type to wrap</typeparam>
    public partial class BindableDecorator<TModel> : ICustomTypeDescriptor, INotifyPropertyChanged
    {
        private static readonly List<PropertyDescriptor> _templateDescriptors = new List<PropertyDescriptor>();

        private TModel _model;
        private readonly PropertyDescriptorCollection _properties;

        public event PropertyChangedEventHandler PropertyChanged;

        public BindableDecorator(TModel model)
        {
            _model = model;
            _properties = new PropertyDescriptorCollection(_templateDescriptors.Select(template => new BindablePropertyDescriptor<TModel>(this, template)).ToArray(), false);
        }

        public TModel Model => _model;

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(_model);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(_model);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(_model);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(_model);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(_model);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(_model);
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(_model);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(_model);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return _properties;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(_model, attributes);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static BindableDecorator()
        {         
            _templateDescriptors.AddRange(TypeDescriptor.GetProperties(typeof(TModel)).Cast<PropertyDescriptor>());
        }
    }    
}

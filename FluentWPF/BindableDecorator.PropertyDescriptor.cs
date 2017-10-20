using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{
    partial class BindableDecorator<TModel>
    {
        private class BindablePropertyDescriptor<TModel> : PropertyDescriptor
        {
            private readonly PropertyDescriptor _baseDescriptor;
            private readonly BindableDecorator<TModel> _wrapper;

            public BindablePropertyDescriptor(BindableDecorator<TModel> wrapper, PropertyDescriptor baseProp) : base(baseProp)
            {                
                _baseDescriptor = baseProp;
                _wrapper = wrapper;
            }

            public override Type ComponentType => typeof(TModel);

            public override bool IsReadOnly => _baseDescriptor.IsReadOnly;

            public override Type PropertyType => _baseDescriptor.PropertyType;

            public object Value => _baseDescriptor.GetValue(_wrapper.Model);

            public override bool CanResetValue(object component)
            {
                return _baseDescriptor.CanResetValue(component);
            }

            public override object GetValue(object component)
            {
                if (!(component is BindableDecorator<TModel> wrapper))
                {
                    return component;
                }

                return _baseDescriptor.GetValue(_wrapper.Model);
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
                if (!(component is BindableDecorator<TModel> wrapper))
                {
                    return;
                }

                _baseDescriptor.SetValue(wrapper.Model, value);

                wrapper.RaisePropertyChanged(_baseDescriptor.Name);
            }

            public override bool ShouldSerializeValue(object component)
            {
                if (!(component is BindableDecorator<TModel> wrapper))
                {
                    return false;
                }

                return _baseDescriptor.ShouldSerializeValue(wrapper.Model);
            }
        }
    }
}

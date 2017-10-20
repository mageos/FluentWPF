using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF.Sample
{
    public class TestViewModel : BindableDecorator<TestModel>
    {
        public TestViewModel(TestModel model) : base(model)
        {
        }
    }
}

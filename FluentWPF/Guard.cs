using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWPF
{
    public static class Guard
    {
        public static void AgainstNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void AgainstNullOrEmpty(string str, string parameter)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException($"{parameter} cannot be null or empty.");
            }
        }
    }
}

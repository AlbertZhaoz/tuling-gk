using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingDemo
{
    public class TulingModel
    {
        public string Name { get; set; }
        public Category CategoryProp { get; set; }
    }
    
    public enum Category
    {
        Akun,
        Xc,
        Xj
    }
}

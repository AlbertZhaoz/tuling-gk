using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DXApplication1
{
    [POCOViewModel()]
    public class MainViewModel
    {
        public virtual string TextEditContent { get; set; } = "TextEditOne";
        public virtual string TextEditContent2 { get; set; } = "TextEditTwo";

        public void ChangeTextEditOne()
        {
            TextEditContent = "Tuling";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuling.GkOne.NoMvvm.Models
{
    public class LogModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OperationTime { get; set; }
        public string  Operation { get; set; }
        public string  IpAddress { get; set; }
    }
}

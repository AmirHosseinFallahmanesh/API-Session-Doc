using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Model
{
    public class ApiResponceModel<T>
    {
        public ApiResponceModel()
        {
            this.ResponceDateTime = DateTime.Now;
        }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public DateTime ResponceDateTime { get;private set; }

        public bool IsFailed { get; set; } = false;
    }
}

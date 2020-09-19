using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MainLocation { get; set; }
    }
}

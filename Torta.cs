using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsAlkfejl
{
    public record Torta
    {
        public string Color { get; init; }
        public string Size { get; init; }
        public int Sugar { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuery
{
    class Animal    
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public int RemainingNumber { get; set; }
    }
}

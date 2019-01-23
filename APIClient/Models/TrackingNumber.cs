using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Models
{
    public class TrackingNumber
    {
        public string meterId { get; set; }
        public string rangeStart { get; set; }
        public string rangeEnd { get; set; }
        public string nextNumber { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public string systemId { get; set; }
    }
}

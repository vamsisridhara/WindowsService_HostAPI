using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Models
{
    public class File
    {
        public string meterId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public string systemId { get; set; }
    }
}

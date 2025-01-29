using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPshka.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DeadLine { get; set; }
        public long Budget { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; } = null!;
        public List<string> Stages { get; set; } = new List<string>();

    }
}

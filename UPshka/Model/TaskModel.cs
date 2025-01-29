using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPshka.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; }
        public int TaskStatus { get; set; }
        public DateTime TaskDeadline { get; set; }
        public int AssignedEmployee { get; set; }
        public int StageId { get; set; }
        public string StageDescription { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int OperationSystemId { get; set; }
        public OperationSystem OperationSystem { get; set; }
        public string Platform { get; set; }
        public string Experience { get; set; }
        public string Language { get; set; }
        public string EditorUsed { get; set; }
        public string Url { get; set; }
        public DateTime FromYear { get; set; }
        public byte[] Image { get; set; }
    }
}

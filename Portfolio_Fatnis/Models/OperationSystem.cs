using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Models
{
    public class OperationSystem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

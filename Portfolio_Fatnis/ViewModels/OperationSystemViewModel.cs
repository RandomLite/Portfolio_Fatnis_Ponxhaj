using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.ViewModels
{
    public class OperationSystemViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

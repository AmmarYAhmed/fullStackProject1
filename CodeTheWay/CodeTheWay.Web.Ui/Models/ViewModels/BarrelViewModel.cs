using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Models.ViewModels
{
    public class BarrelViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int Contents { get; set; }
        public String CurrentLocation { get; set; }
    }
}

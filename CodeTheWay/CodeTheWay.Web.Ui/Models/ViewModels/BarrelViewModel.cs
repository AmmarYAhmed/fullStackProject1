using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.Enums;

namespace CodeTheWay.Web.Ui.Models.ViewModels
{
    public class BarrelViewModel
    {
        public Guid Id { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public DateTime DateCreated { get; set; }
        public Contents Contents { get; set; }
        public string CurrentLocation { get; set; }
        public Size Size { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLC.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string ItemText { get; set; }
        public object ItemData { get; set; }
        public bool IsChecked { get; set; }
    }
}

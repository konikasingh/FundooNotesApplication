using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models.Lable
{
    public class LableModel
    {
        [DataType(DataType.Text)]
        public string LableName { get; set; }
    }
}

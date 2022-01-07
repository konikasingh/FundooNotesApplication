using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class CollaboratorModel
    {
        public long CollaborateId { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public long NotesId { get; set; }
    }
}

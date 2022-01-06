using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class Collaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long CollaboratorId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "SenderEmail:")]
        public string SenderEmail { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ReceiverEmail:")]
        public string ReceiverEmail { get; set; }

        public Notes Notes { get; set; }

        [ForeignKey("Notes")]

        public long NotesId { get; set; }
    }
}

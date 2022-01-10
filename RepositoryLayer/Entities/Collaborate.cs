using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class Collaborate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }


        public Notes Notes { get; set; }
        public long NotesId { get; set; }


        public User User { get; set; }
        public long Id { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Collaborater_Email { get; set; }

    }
}

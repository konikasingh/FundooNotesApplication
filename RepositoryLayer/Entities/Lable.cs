using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class Lable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long LableId { get; set; }
        public string Lables { get; set; }
        public Notes Notes { get; set; }

        [ForeignKey("Notes")]
        public long NotesId { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public long Id { get; set; }
    }
}

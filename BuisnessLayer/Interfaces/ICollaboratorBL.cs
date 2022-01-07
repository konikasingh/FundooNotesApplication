using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
        public string AddCollaborator(CollaboratorModel collaborators);
        public string DeleteCollaborator(long id);
        public IEnumerable<Collaborate> GetCollaborators();
    }
}

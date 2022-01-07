using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
        public string AddCollaborator(CollaboratorModel collaborators);
        public string DeleteCollaborator(long id);
    }
}

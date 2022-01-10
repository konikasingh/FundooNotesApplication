using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
        public void AddCollaborate(long notesId, long TokenId, CollaboratorModel model);
        public Collaborate GetCollabtrWithId(long collabtrId);
        public void DeleteCollabtr(Collaborate collab);

    }
}

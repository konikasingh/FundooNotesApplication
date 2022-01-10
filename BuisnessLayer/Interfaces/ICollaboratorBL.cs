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
        public void AddCollaborate(long notesId, long TokenId, CollaboratorModel model);
        public Collaborate GetCollabtrWithId(long collabtrId);
        public void DeleteCollabtr(Collaborate collab);

    }
}

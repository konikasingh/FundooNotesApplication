using BuisnessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        ICollaboratorRL CollaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.CollaboratorRL = collaboratorRL;
        }

        /// <summary>
        /// Method to call AddCollaborator() to add the collaborator
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="TokenId"></param>
        /// <param name="model"></param>
        public void AddCollaborate(long notesId, long TokenId, CollaboratorModel model)
        {
            try
            {
                this.CollaboratorRL.AddCollaborate(notesId, TokenId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Method to call GetCollaborator with id to delete the collaboator using id
        /// </summary>
        /// <param name="collabtrId"></param>
        /// <returns></returns>
        public Collaborate GetCollabtrWithId(long collabtrId)
        {
            try
            {
                return this.CollaboratorRL.GetCollabtrWithId(collabtrId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to call the DeleteCollaborator to delete the collaborator
        /// </summary>
        /// <param name="collab"></param>
        public void DeleteCollabtr(Collaborate collab)
        {
            try
            {
                this.CollaboratorRL.DeleteCollabtr(collab);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

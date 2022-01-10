using CommonLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;

namespace RepositoryLayer.Services
{
    //NotesRepository class implements INotes Interface
    public class CollaboratorRL : ICollaboratorRL
    {
        ucontext context;

        /// <summary>
        /// Initialize the ucontext as a dbcontext
        /// </summary>
        /// <param name="context"></param>
        public CollaboratorRL(ucontext context)
        {
            this.context = context;  //created the context parameter of context class
        }

        /// <summary>
        /// Method of add the collaborator
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="TokenId"></param>
        /// <param name="model"></param>
        public void AddCollaborate(long notesId, long TokenId, CollaboratorModel model)
        {
            try
            {
                var validNotesAndUser = this.context.NotesTable.Where(e => e.Id == TokenId);
                Collaborate collaborate = new()
                {
                    NotesId = notesId,
                    Id = TokenId,
                    Collaborater_Email = model.Collaborator_Email
                };
                this.context.Add(collaborate);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method for get the collaborator which is added
        /// </summary>
        /// <param name="collabtrId"></param>
        /// <returns></returns>
        public Collaborate GetCollabtrWithId(long collabtrId)
        {
            try
            {
                return this.context.CollaboratorTable.FirstOrDefault(e => e.CollaboratorId == collabtrId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Method for delete the collaborator
        /// </summary>
        /// <param name="collab"></param>
        public void DeleteCollabtr(Collaborate collab)
        {
            try
            {
                this.context.CollaboratorTable.Remove(collab);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

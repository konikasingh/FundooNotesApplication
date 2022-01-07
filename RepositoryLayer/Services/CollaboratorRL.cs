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
    public class CollaboratorRL: ICollaboratorRL
    {
        ucontext context;
        

        public CollaboratorRL(ucontext context)
        {
            this.context = context;  //created the context parameter of context class
        }

        /// <summary>
        /// Method to Add collaborators to note
        /// </summary>
        /// <param name="collaborators"></param>
        /// <returns>string message</returns>
        public string AddCollaborator(CollaboratorModel collaborators)
        {
            try
            {
                string message;
                if (collaborators != null)
                {
                    Collaborate nCollaborate = new Collaborate();
                    nCollaborate.NotesId = collaborators.NotesId;
                    nCollaborate.SenderEmail = collaborators.SenderEmail;
                    nCollaborate.ReceiverEmail = collaborators.ReceiverEmail;
                    this.context.CollaborateTable.Add(nCollaborate); 
                    this.context.SaveChanges();
                    message = "New Collaborator added Successfully !";
                    return message;
                }

                message = "New Collaborator not added to Database";
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Method to Remove collaborator
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>string message</returns>
        public string DeleteCollaborator(long id)
        {
            try
            {
                var collaborator = this.context.CollaborateTable.Find(id);
                if (collaborator != null)
                {
                    this.context.CollaborateTable.Remove(collaborator);
                    this.context.SaveChangesAsync();
                    return "Collaborator Deleted Successfully !";
                }

                return "Unable to delete this Collaborator.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Method to Retrieve All collaborators
        /// </summary>
        /// <returns>existing collaborators</returns>
        public IEnumerable<Collaborate> GetCollaborators()
        {
                return context.CollaborateTable.ToList();
        }
    }
}

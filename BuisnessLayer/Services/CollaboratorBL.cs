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
        /// added the collaborator in database
        /// </summary>
        /// <param name="collaborator"></param>
        /// <returns></returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            string message = this.CollaboratorRL.AddCollaborator(collaborator);
            return message;
        }
        /// <summary>
        /// delete the collaborator in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteCollaborator(long id)
        {
            string message = this.CollaboratorRL.DeleteCollaborator(id);
            return message;
        }
        /// <summary>
        /// get all the data of collaborator from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Collaborate> GetCollaborators()
        {
            return this.CollaboratorRL.GetCollaborators();
        }
    }
}

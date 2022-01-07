using BuisnessLayer.Interfaces;
using CommonLayer.Models;
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
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            string message = this.CollaboratorRL.AddCollaborator(collaborator);
            return message;
        }
    }
}

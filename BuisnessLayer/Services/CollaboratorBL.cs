//using BuisnessLayer.Interfaces;
//using CommonLayer.Models;
//using RepositoryLayer.Entities;
//using RepositoryLayer.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BuisnessLayer.Services
//{
//    public class CollaboratorBL : ICollaboratorBL
//    {
//        ICollaboratorRL CollaboratorRL;
//        public CollaboratorBL(ICollaboratorRL collaboratorRL)
//        {
//            this.CollaboratorRL = collaboratorRL;
//        }
//        public FundooCollaborate GetCollabWithId(long collabId)
//        {
//            try
//            {
//                return this.collaborateRL.GetCollabWithId(collabId);
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public void DeleteCollab(FundooCollaborate collab)
//        {
//            try
//            {
//                this.collaborateRL.DeleteCollab(collab);
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public void AddCollaborate(long notesId, long jwtUserId, CollaborateModel model)
//        {
//            try
//            {
//                this.collaborateRL.AddCollaborate(notesId, jwtUserId, model);
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//    }
//}

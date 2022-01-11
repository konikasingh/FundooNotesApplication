using CommonLayer.Models;
using CommonLayer.Models.Lable;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer.Services
{
    public class LableRL: ILableRL
    {
        ucontext context;
        public LableRL(ucontext context)
        {
            this.context = context;  //created the context parameter of context class
        }
        /// <summary>
        /// Method for create the lable
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="TokenId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public LableResponseModel CreateLable(long notesId, long TokenId, LableModel model)
        {

                try
                {
                    var validNotesAndUser = this.context.UserTable.Where(e => e.Id == TokenId);
                    Lable lable = new()
                    {
                        NotesId = notesId,
                        Id = TokenId,
                        LableName = model.LableName
                    };
                    this.context.Add(lable);
                    this.context.SaveChanges();

                    LableResponseModel responseModel = new()
                    {
                        LableId = lable.LableId,
                        NotesId = lable.NotesId,
                        Id = lable.Id,
                        LableName = lable.LableName

                    };
                    return responseModel;
                }
                catch (Exception)
                {
                    throw;
                } 
        }
        /// <summary>
        /// Method for Getting all the lable
        /// </summary>
        /// <param name="TokenId"></param>
        /// <returns></returns>
        public LableResponseModel GetAllLable(long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {
                    var response = this.context.LableTable.FirstOrDefault(e => e.Id == TokenId);
                    LableResponseModel model = new()
                    {
                        LableId = response.LableId,
                        NotesId = response.NotesId,
                        Id = response.Id,
                        LableName = response.LableName
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Method for Getting the lable with id
        /// </summary>
        /// <param name="lableId"></param>
        /// <param name="TokenId"></param>
        /// <returns></returns>
        public Lable GetLablesWithId(long lableId, long TokenId)
        {
            var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
            if (validUserId != null)
            {
                return this.context.LableTable.FirstOrDefault(e => e.LableId == lableId);
            }
            return null;
        }
        /// <summary>
        /// Method for Response the lable
        /// </summary>
        /// <param name="lableId"></param>
        /// <param name="TokenId"></param>
        /// <returns></returns>
        public LableResponseModel GetLableId(long lableId, long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {
                    var response = this.context.LableTable.FirstOrDefault(e => e.LableId == lableId && e.Id == TokenId);
                    LableResponseModel model = new()
                    {
                        LableId = response.LableId,
                        NotesId = response.NotesId,
                        Id = response.Id,
                        LableName = response.LableName
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method for Update the lable
        /// </summary>
        /// <param name="updateLable"></param>
        /// <param name="model"></param>
        /// <param name="TokenId"></param>
        public void UpdateLable(Lable updateLable, LableModel model, long TokenId)
        {
            try
            {
                var validTokenId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validTokenId != null)
                {
                    updateLable.LableName = model.LableName;
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLable(Lable model, long TokenId)
        {
            try
            {
                var validTokenId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validTokenId != null)
                {
                    this.context.LableTable.Remove(model);
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method for Adding the lable
        /// </summary>
        /// <param name="model"></param>
        /// <param name="TokenId"></param>
        /// <returns></returns>
        public Lable AddLable(LableModel model, long TokenId)
        {
            try
            {
                var validTokenId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validTokenId != null)
                {
                    Lable lable = new()
                    {
                        LableName = model.LableName,
                        Id = TokenId
                    };
                    return lable;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using BuisnessLayer.Interfaces;
using CommonLayer.Models.Lable;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class LableBL: ILableBL
    {
        ILableRL LableRL;
        public LableBL(ILableRL lableRL)
        {
            this.LableRL = lableRL;
        }
        public LableResponseModel CreateLable(long notesId, long TokenId, LableModel model)
        {
            try
            {
                return this.LableRL.CreateLable(notesId, TokenId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LableResponseModel GetAllLable(long TokenId)
        {
            try
            {
                return this.LableRL.GetAllLable(TokenId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Lable GetLablesWithId(long lableId, long TokenId)
        {
            return this.LableRL.GetLablesWithId(lableId, TokenId);
        }

        public LableResponseModel GetLableId(long lableId, long TokenId)
        {
            try
            {
                return this.LableRL.GetLableId(lableId, TokenId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateLable(Lable updateLable, LableModel model, long TokenId)
        {
            try
            {
                this.LableRL.UpdateLable(updateLable, model, TokenId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteLable(Lable lable, long TokenId)
        {
            try
            {
                this.LableRL.DeleteLable(lable, TokenId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LableResponseModel AddLable(LableModel model, long TokenId)
        {
            return this.LableRL.AddLable(model, TokenId);
        }
    }
}

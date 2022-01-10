using BuisnessLayer.Interfaces;
using CommonLayer.Models.Lable;
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
    }
}

using CommonLayer.Models;
using CommonLayer.Models.Lable;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface ILableBL
    {
        public LableResponseModel CreateLable(long notesId, long TokenId, LableModel model);
        public LableResponseModel GetLableId(long lableId, long TokenId);
        public LableResponseModel GetAllLable(long TokenId);
        public void UpdateLable(Lable updateLable, LableModel model, long TokenId);
        public Lable GetLablesWithId(long lableId, long TokenId);
        public void DeleteLable(Lable lable, long TokenId);
        public LableResponseModel AddLable(LableModel model, long TokenId);
    }
}

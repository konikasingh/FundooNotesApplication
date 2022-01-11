using CommonLayer.Models.Lable;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILableRL
    {
        LableResponseModel CreateLable(long notesId, long TokenId, LableModel model);
        
        LableResponseModel GetLableId(long lableId, long TokenId);
        LableResponseModel GetAllLable(long TokenId);
        public void UpdateLable(Lable updateLable, LableModel model, long TokenId);
        Lable GetLablesWithId(long lableId, long TokenId);
        void DeleteLable(Lable model, long TokenId);
        Lable AddLable(LableModel model, long TokenId);


    }
}

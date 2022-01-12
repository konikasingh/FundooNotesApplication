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
        public LableResponseModel CreateLable(long notesId, long TokenId, LableModel model);        
        public LableResponseModel GetLableId(long lableId, long TokenId);
        public LableResponseModel GetAllLable(long TokenId);
        public void UpdateLable(Lable updateLable, LableModel model, long TokenId);
        public Lable GetLablesWithId(long lableId, long TokenId);
        public void DeleteLable(Lable model, long TokenId);
        public Lable AddLable(LableModel model, long TokenId);


    }
}

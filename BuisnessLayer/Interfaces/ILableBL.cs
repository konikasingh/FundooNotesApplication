using CommonLayer.Models;
using CommonLayer.Models.Lable;
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

    }
}

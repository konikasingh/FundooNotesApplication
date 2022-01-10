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
    }
}

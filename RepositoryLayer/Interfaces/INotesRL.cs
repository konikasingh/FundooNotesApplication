﻿using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        public bool CreateNotes(NotesModel client, long tokenId);
        public IEnumerable<Notes> GetNotesDetail();
        public Notes GetWithId(long id);
        public void UpdateNotes(Notes APerson, Notes person);
        public void DeleteNotes(Notes person);
        public NotesModel PinorUnpinNote(int id, long TokenId);
        public NotesModel ArchiveOrUnArchieveNote(int id, long TokenId);
        public NotesModel TrashOrRestoreNote(int id, long TokenId);
        public string AddColor(long id, string color);
        public void ImageNotes(Notes imageNotes, IFormFile image, long TokenId);

    }
}

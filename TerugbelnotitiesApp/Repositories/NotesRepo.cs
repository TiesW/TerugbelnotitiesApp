using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TerugbelnotitiesApp.Models;

namespace TerugbelnotitiesApp.Repositories
{
    public class NotesRepo : INotesRepo
    {
        private TerugbelnotitiesContext context = new TerugbelnotitiesContext();

        public async Task<List<Notities>> getNotes()
        {
            return await context.Notities.Select(n => new Notities { 
                Id = n.Id,
                AssignedUserId = n.AssignedUserId,
                AssignedUserName = n.AssignedUserName,
                AssigningUserId = n.AssigningUserId,
                AssigningUserName = n.AssigningUserName,
                Category = n.Category,
                Notitie = n.Notitie,
                PersonToCallName = n.PersonToCallName,
                Phone = n.Phone,
                Processed = n.Processed,
                Timestamp = n.Timestamp
            }).ToListAsync();
        }
        public void addNote(NotitieViewModel model)
        {
            context.Notities.Add(new Notities
            {
                AssignedUserId = model.AssignedUserId,
                AssignedUserName = model.AssignedUserName,
                AssigningUserId = model.AssigningUserId,
                AssigningUserName = model.AssigningUserName,
                Category = model.Category,
                Notitie = model.Notitie,
                PersonToCallName = model.PersonToCallName,
                Phone = model.Phone,
                Processed = model.Processed,
                Timestamp = model.Timestamp
            });
            context.SaveChanges();
        }

        public void deleteNote(int Id)
        {
            var note = context.Notities.Single(w => w.Id == Id);
            context.Notities.Remove(note);
            context.SaveChanges();
        }

        public void editNote(int id, string notitie)
        {
            var note = context.Notities.Single(w => w.Id == id);
            note.Notitie = notitie;
            //note.Processed = note.Processed;
            context.SaveChanges();
        }
        public void editNoteProcessed(int id, bool processed)
        {
            var note = context.Notities.Single(w => w.Id == id);
            note.Processed = processed;
            context.SaveChanges();
        }
    }
}

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
        public async Task addNote(NotitieViewModel model)
        {
            await context.Notities.AddAsync(new Notities
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
            await context.SaveChangesAsync();
        }

        public async Task deleteNote(int Id)
        {
            var note = context.Notities.Single(n => n.Id == Id);
            context.Notities.Remove(note);
            await context.SaveChangesAsync();
        }

        public async Task editNote(int id, string notitie)
        {
            var note = context.Notities.Single(n => n.Id == id);
            note.Notitie = notitie;
            await context.SaveChangesAsync();
        }
        public async Task editProcessed(int id, bool processed)
        {
            var note = context.Notities.Single(n => n.Id == id);
            note.Processed = processed;
            await context.SaveChangesAsync();
        }
    }
}

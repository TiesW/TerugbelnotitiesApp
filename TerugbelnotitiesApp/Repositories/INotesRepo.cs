using DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerugbelnotitiesApp.Models;

namespace TerugbelnotitiesApp.Repositories
{
    public interface INotesRepo
    {
        Task<List<Notities>> getNotes();
        void addNote(NotitieViewModel model);
        void deleteNote(int id);
        void editNote(int id, string notitie);
        void editNoteProcessed(int id, bool processed);
    }
}
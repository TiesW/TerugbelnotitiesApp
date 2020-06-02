using DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerugbelnotitiesApp.Models;

namespace TerugbelnotitiesApp.Repositories
{
    public interface INotesRepo
    {
        Task<List<Notities>> getNotes();
        Task addNote(NotitieViewModel model);
        Task deleteNote(int id);
        Task editNote(int id, string notitie);
        Task editProcessed(int id, bool processed);
    }
}
using src.Persistence.Model;
using src.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public class NoteService 
    {
        private readonly IRepository<Note> _repository;
        public NoteService(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task AddNoteToDb(Note note)
        {
            await _repository.AddAnEntityAsync(note);
        }

        public async Task<int> DeleteNote(int id)
        {
            Note note = await _repository.GetSingleAsync(id);
            _repository.Delete(note);
            return await _repository.Save();
        }
        
        public async Task<int> UpdateNote(Note note)
        {
            _repository.Update(note);
            return await _repository.Save();
        }


    }
}

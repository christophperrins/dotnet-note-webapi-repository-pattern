using src.Persistence.Entity;
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

        public async Task<int> CreateNote(Note note)
        {
            return await _repository.AddAsync(note);
        }

        public async Task<int> DeleteNote(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        
        public async Task<List<Note>> GetAllNotes()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task<int> UpdateNote(Note note)
        {
            return await _repository.UpdateAsync(note);
        }
    }
}

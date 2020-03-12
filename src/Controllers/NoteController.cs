using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Data;
using src.Dto;
using src.Persistence.Entity;
using src.Services;

namespace src.Controllers
{
    [ApiController]
    [Route("/note")]
    public class NoteController : ControllerBase
    {

        private readonly ILogger<NoteController> _logger;
        private readonly IMapper _mapper;
        private readonly NoteService _noteService;

        public NoteController(ILogger<NoteController> logger, IMapper mapper, NoteService noteService)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<List<NoteDto>> GetAll()
        {
            List<Note> list = await _noteService.GetAllNotes();
            List<Note> notes = list;
            return _mapper.Map<List<NoteDto>>(notes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<NoteDto> GetAsync(int id)
        {
            Note note = await _noteService.GetNote(id);
            return _mapper.Map<NoteDto>(note);
        }

        [HttpPost]
        public async Task<int> PostyAsync([FromBody] NoteDtoWithoutId noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            return await _noteService.CreateNote(note);
        }

        [HttpPut]
        public async Task<int> Putty([FromBody] NoteDto noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            return await _noteService.UpdateNote(note);
        }

        //[HttpPut]
        //public async Task<int> PuttyAlso([FromBody] NoteDto noteDto)
        //{
        //    Note noteEntity = await _context.Note.FirstAsync(note => note.Id == noteDto.Id)
        //    noteEntity.Text = noteDto.Text;
        //    return await _context.SaveChangesAsync();
        //}

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DelettyAsync(int id)
        {
            return await _noteService.DeleteNote(id);
        }
    }
}

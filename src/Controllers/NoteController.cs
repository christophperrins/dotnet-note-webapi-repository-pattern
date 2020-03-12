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
using src.Persistence.Model;
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
            List<Note> notes = await _noteService.GetAllNotesAsync();
            return _mapper.Map<List<NoteDto>>(notes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<NoteDto> GetAsync(int id)
        {
            Note note = await _noteService.GetNoteAsync(id);
            return _mapper.Map<NoteDto>(note);
        }

        [HttpPost]
        public async Task PostyAsync([FromBody] NoteDtoWithoutId noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            await _noteService.AddNoteToDb(note);
        }

        [HttpPut]
        public async Task<int> Putty([FromBody] NoteDto noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            return await _noteService.UpdateNote(note);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DelettyAsync(int id)
        {
            return await _noteService.DeleteNote(id);
        }
    }
}

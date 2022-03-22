using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNotesApi.Data;
using MyNotesApi.Dtos;

namespace MyNotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        #region MyChanges
        [HttpPut("{id}")]
        public async Task<ActionResult<Note>> PutNote(int id, PutNoteDto dto)//IActionResult yerine ActionResult<Note> => NoContent yerine notu döndürmek için
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var note = await _context.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            note.Title = dto.Title;
            note.Content = dto.Content;
            note.ModifiedTime = DateTime.Now;

            _context.Update(note);
            await _context.SaveChangesAsync();

            return note;
        }
        #endregion

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(PostNoteDto dto)
        {
            var note = new Note()
            {
                Content = dto.Content,
                Title = dto.Title
            };
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

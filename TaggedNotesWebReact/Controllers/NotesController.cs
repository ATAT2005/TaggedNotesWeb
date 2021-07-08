using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using TaggedNotesWeb.Models;
using TaggedNotesWeb.Logic.Interfaces;
using TaggedNotesWeb.Logic.Entities;

namespace TaggedNotesWebReact.Controllers
{
	/// <summary>
	/// Web API contoller for notes
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class NotesController : ControllerBase
	{
		private readonly INoteService _noteService;

		private readonly ITagService _tagService;

		private readonly ILinkService _linkService;

		private readonly IMapper _noteDtoToModelMapper;

		private readonly IMapper _noteModelToDtoMapper;

		private readonly IMapper _tagMapper;

		private readonly IMapper _linkMapper;

		private readonly ILogger<NotesController> _logger;

		public NotesController(INoteService noteService, ITagService tagService, ILinkService linkService, ILogger<NotesController> logger)
		{
			_noteService = noteService;
			_tagService = tagService;
			_linkService = linkService;

			_logger = logger;

			_noteDtoToModelMapper = new MapperConfiguration(cfg => cfg.CreateMap<NoteDTO, NoteModel>()).CreateMapper();
			_noteModelToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<NoteModel, NoteDTO>()).CreateMapper();
			_tagMapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, TagModel>()).CreateMapper();
			_linkMapper = new MapperConfiguration(cfg => cfg.CreateMap<LinkDTO, LinkModel>()).CreateMapper();
		}

		/// <summary>
		/// Returns all notes
		/// </summary>
		/// <returns>All note collection</returns>
		[HttpGet]
		public IEnumerable<NoteModel> Get()
		{
			var notesDto = _noteService.GetNotes();
			var tagsDto = _tagService.GetTags();
			var linksDto = _linkService.GetLinks();

			var viewModel = new ViewModel();

			viewModel.Notes = _noteDtoToModelMapper.Map<IEnumerable<NoteDTO>, List<NoteModel>>(notesDto);
			viewModel.Tags = _tagMapper.Map<IEnumerable<TagDTO>, List<TagModel>>(tagsDto);
			viewModel.Links = _linkMapper.Map<IEnumerable<LinkDTO>, List<LinkModel>>(linksDto);

			foreach (var note in viewModel.Notes)
			{
				var idTags = _linkService.GetLinks().Where(link => link.IdNote == note.Id).Select(link => link.IdTag).ToList();
				var tags = _tagService.GetTags().Where(tag => idTags.Contains(tag.Id));
				note.LinkedTags = string.Join(", ", tags.Select(tag => tag.Name));
			}

			return viewModel.Notes;
		}

		/// <summary>
		/// Saves notes to database
		/// </summary>
		/// <param name="notes">Note collection to save</param>
		[HttpPost]
		public void Post([FromBody] IEnumerable<NoteModel> notes)
		{
			var notesDto = _noteService.GetNotes();

			foreach (var note in notes)
			{
				var dtoNote = _noteModelToDtoMapper.Map<NoteModel, NoteDTO>(note);

				var existingNote = _noteService.GetNote(note.Id);
				
				if (existingNote == null)
					_noteService.AddNote(dtoNote);
				else
					_noteService.UpdateNote(dtoNote);
			}

			foreach (var noteDto in notesDto)
				if (!notes.Any(x => x.Id == noteDto.Id))
				{
					_noteService.DeleteNote(noteDto);
				}

			_noteService.SaveChanges();
		}
	}
}
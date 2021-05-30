using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using TaggedNotesWeb.Models;
using TaggedNotesWeb.Logic.Interfaces;
using TaggedNotesWeb.Logic.Entities;

namespace TaggedNotesWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly INoteService _noteService;

		private readonly ITagService _tagService;

		private readonly ILinkService _linkService;

		private readonly IMapper _noteMapper;

		private readonly IMapper _tagMapper;

		private readonly IMapper _linkMapper;

		private readonly ILogger<HomeController> _logger;

		public HomeController(INoteService noteService, ITagService tagService, ILinkService linkService, ILogger<HomeController> logger)
		{
			_noteService = noteService;
			_tagService = tagService;
			_linkService = linkService;

			_logger = logger;

			_noteMapper = new MapperConfiguration(cfg => cfg.CreateMap<NoteDTO, NoteModel>()).CreateMapper();
			_tagMapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, TagModel>()).CreateMapper();
			_linkMapper = new MapperConfiguration(cfg => cfg.CreateMap<LinkDTO, LinkModel>()).CreateMapper();
		}

		public IActionResult Index()
		{
			var notesDto = _noteService.GetNotes();
			var tagsDto = _tagService.GetTags();
			var linksDto = _linkService.GetLinks();

			var viewModel = new ViewModel();

			viewModel.Notes = _noteMapper.Map<IEnumerable<NoteDTO>, List<NoteModel>>(notesDto);
			viewModel.Tags = _tagMapper.Map<IEnumerable<TagDTO>, List<TagModel>>(tagsDto);
			viewModel.Links = _linkMapper.Map<IEnumerable<LinkDTO>, List<LinkModel>>(linksDto);

			foreach (var note in viewModel.Notes)
			{
				var idTags = _linkService.GetLinks().Where(link => link.IdNote == note.Id).Select(link => link.IdTag).ToList();
				var tags = _tagService.GetTags().Where(tag => idTags.Contains(tag.Id));
				note.LinkedTags = string.Join(", ", tags.Select(tag => tag.Name));
			}

			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		protected override void Dispose(bool disposing)
		{
			_noteService.Dispose();
			_tagService.Dispose();
			_linkService.Dispose();

			base.Dispose(disposing);
		}
	}
}

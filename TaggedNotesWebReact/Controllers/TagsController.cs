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
	/// Web API contoller for tags
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class TagsController : ControllerBase
	{
		private readonly ITagService _tagService;

		private readonly IMapper _tagDtoToModelMapper;

		private readonly IMapper _tagModelToDtoMapper;

		private readonly IMapper _tagMapper;

		private readonly ILogger<NotesController> _logger;

		public TagsController(INoteService noteService, ITagService tagService, ILinkService linkService, ILogger<NotesController> logger)
		{
			_tagService = tagService;

			_logger = logger;

			_tagDtoToModelMapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, TagModel>()).CreateMapper();
			_tagModelToDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<TagModel, TagDTO>()).CreateMapper();
		}

		/// <summary>
		/// Returns all tags
		/// </summary>
		/// <returns>All tag collection</returns>
		[HttpGet]
		public IEnumerable<TagModel> Get()
		{
			var tagsDto = _tagService.GetTags();

			var viewModel = new ViewModel();

			viewModel.Tags = _tagDtoToModelMapper.Map<IEnumerable<TagDTO>, List<TagModel>>(tagsDto);

			return viewModel.Tags;
		}

		/// <summary>
		/// Saves tags to database
		/// </summary>
		/// <param name="tags">Tag collection to save</param>
		[HttpPost]
		public void Post([FromBody] IEnumerable<TagModel> tags)
		{
			var tagsDto = _tagService.GetTags();

			foreach (var tag in tags)
			{
				var existingNote = _tagService.GetTag(tag.Id);
				if (existingNote == null)
				{
					var addedTag = _tagModelToDtoMapper.Map<TagModel, TagDTO>(tag);
					_tagService.AddTag(addedTag);
				}
			}

			foreach (var tagDto in tagsDto)
				if (!tags.Any(x => x.Id == tagDto.Id))
				{
					_tagService.DeleteTag(tagDto);
				}

			_tagService.SaveChanges();
		}
	}
}
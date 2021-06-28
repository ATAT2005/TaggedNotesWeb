using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using Moq;

using TaggedNotesWeb.Logic.Entities;
using TaggedNotesWeb.Logic.Interfaces;
using TaggedNotesWeb.Logic.Services;
using TaggedNotesWeb.Models;
using TaggedNotesWebReact.Controllers;

namespace TaggedNotesWebReact.Tests
{
	public class HomeControllerTests
	{
		Mock<INoteService> _noteServiceMock;

		Mock<ITagService> _tagServiceMock;

		Mock<ILinkService> _linkServiceMock;

		NotesController _noteController;

		IActionResult _homeView;

		[SetUp]
		public void Setup()
		{
			_noteServiceMock = new Mock<INoteService>();
			_noteServiceMock.Setup(serv => serv.GetNotes()).Returns(GetNotesMock());

			_tagServiceMock = new Mock<ITagService>();
			_tagServiceMock.Setup(serv => serv.GetTags()).Returns(GetTagsMock());

			_linkServiceMock = new Mock<ILinkService>();
			_linkServiceMock.Setup(serv => serv.GetLinks()).Returns(GetLinksMock());

			_noteController = new NotesController(_noteServiceMock.Object, _tagServiceMock.Object, _linkServiceMock.Object, null);
		}

		private IEnumerable<NoteDTO> GetNotesMock()
		{
			foreach (var noteDTO in new NoteDTO[] { new NoteDTO { Id=1, Text="note1"},
													new NoteDTO { Id=2, Text="note2"},
													new NoteDTO { Id=3, Text="note3"},
													new NoteDTO { Id=4, Text="note4"}})
				yield return noteDTO;
		}

		private IEnumerable<TagDTO> GetTagsMock()
		{
			foreach (var tagDTO in new TagDTO[] {   new TagDTO { Id=1, Name="tag1"},
													new TagDTO { Id=2, Name="tag2"},
													new TagDTO { Id=3, Name="tag3"},
													new TagDTO { Id=4, Name="tag4"}})
				yield return tagDTO;
		}

		private IEnumerable<LinkDTO> GetLinksMock()
		{
			foreach (var linkDTO in new LinkDTO[] { new LinkDTO { Id=1, IdNote=1, IdTag=1},
													new LinkDTO { Id=2, IdNote=1, IdTag=2},
													new LinkDTO { Id=3, IdNote=2, IdTag=3},
													new LinkDTO { Id=4, IdNote=3, IdTag=4}})
				yield return linkDTO;
		}

		[Test]
		public void CheckViewType()
		{
			Assert.IsAssignableFrom<List<NoteModel>>(_noteController.Get());
		}

		[Test]
		public void CheckNoteCount()
		{
			Assert.AreEqual(_noteController.Get().Count(), GetNotesMock().Count());
		}
	}
}
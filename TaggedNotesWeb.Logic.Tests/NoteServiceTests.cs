using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Moq;

using TaggedNotesWeb.Logic.Entities;
using TaggedNotesWeb.Logic.Interfaces;
using TaggedNotesWeb.Logic.Services;

namespace TaggedNotesWeb.Logic.Tests
{
	public class NoteServiceTests
	{
		Mock<INoteService> _noteServiceMock;

		[SetUp]
		public void Setup()
		{
			_noteServiceMock = new Mock<INoteService>();

			_noteServiceMock.Setup(serv => serv.GetNotes()).Returns(GetNotesMock());

			_noteServiceMock.Setup(serv => serv.GetNote(null)).Returns(() => null);

			_noteServiceMock.Setup(serv => serv.GetNote(1)).Returns(() => new NoteDTO { Id = 1, Text = "note1" });
		}

		private IEnumerable<NoteDTO> GetNotesMock()
		{
			foreach (var noteDTO in new NoteDTO[] { new NoteDTO { Id=1, Text="note1"},
													new NoteDTO { Id=2, Text="note2"},
													new NoteDTO { Id=3, Text="note3"},
													new NoteDTO { Id=4, Text="note4"}})
				yield return noteDTO;
		}

		[Test]
		public void TestGetNotes()
		{
			Assert.AreEqual(_noteServiceMock.Object.GetNotes().Count(), 4);
		}

		[Test]
		public void TestGetNullNote()
		{
			Assert.Null(_noteServiceMock.Object.GetNote(null));
		}

		[Test]
		public void TestGetNotNulNote()
		{
			Assert.NotNull(_noteServiceMock.Object.GetNote(1));
		}

		[Test]
		public void TestCompareTexts()
		{
			Assert.AreEqual(_noteServiceMock.Object.GetNote(1).Text, "note1");
		}
	}
}
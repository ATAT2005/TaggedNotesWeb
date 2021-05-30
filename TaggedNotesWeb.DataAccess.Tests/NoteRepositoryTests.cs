using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;

using NUnit.Framework;

using Moq;

using TaggedNotesWeb.DataAccess.EF;
using TaggedNotesWeb.DataAccess.Entities;
using TaggedNotesWeb.DataAccess.Interfaces;
using TaggedNotesWeb.DataAccess.Repositories;

namespace TaggedNotesWeb.DataAccess.Tests
{
	public class NoteRepositoryTests
	{
		Mock<IRepository<NoteDAL>> _noteRepositoryMock;

		[SetUp]
		public void Setup()
		{
			_noteRepositoryMock = new Mock<IRepository<NoteDAL>>();
			
			_noteRepositoryMock.Setup(repo => repo.ReadAll()).Returns(() => new List<NoteDAL>
			{
				new NoteDAL { Id=1, Text="note1"},
				new NoteDAL { Id=2, Text="note2"},
				new NoteDAL { Id=3, Text="note3"},
				new NoteDAL { Id=4, Text="note4"}
			});

			_noteRepositoryMock.Setup(repo => repo.Read(null)).Returns(() => null);

			_noteRepositoryMock.Setup(repo => repo.Read(1)).Returns(() => new NoteDAL { Id = 1, Text = "note1" });
		}

		[Test]
		public void TestReadAllNotes()
		{
			Assert.AreEqual(_noteRepositoryMock.Object.ReadAll().Count(), 4);
		}

		[Test]
		public void TestReadNullNote()
		{
			Assert.Null(_noteRepositoryMock.Object.Read(null));
		}

		[Test]
		public void TestReadNotNulNote()
		{
			Assert.NotNull(_noteRepositoryMock.Object.Read(1));
		}

		[Test]
		public void TestCompareTexts()
		{
			Assert.AreEqual(_noteRepositoryMock.Object.Read(1).Text, "note1");
		}
	}
}
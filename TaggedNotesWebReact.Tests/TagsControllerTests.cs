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
	public class TagsControllerTests
	{
		Mock<ITagService> _tagServiceMock;

		TagsController _tagController;

		[SetUp]
		public void Setup()
		{
			_tagServiceMock = new Mock<ITagService>();
			_tagServiceMock.Setup(serv => serv.GetTags()).Returns(GetTagsMock());

			_tagController = new TagsController(null, _tagServiceMock.Object, null, null);
		}

		private IEnumerable<TagDTO> GetTagsMock()
		{
			foreach (var tagDTO in new TagDTO[] {   new TagDTO { Id=1, Name="tag1"},
													new TagDTO { Id=2, Name="tag2"},
													new TagDTO { Id=3, Name="tag3"},
													new TagDTO { Id=4, Name="tag4"}})
				yield return tagDTO;
		}

		[Test]
		public void CheckGetType()
		{
			Assert.IsAssignableFrom<List<TagModel>>(_tagController.Get());
		}

		[Test]
		public void CheckTagCount()
		{
			Assert.AreEqual(_tagController.Get().Count(), GetTagsMock().Count());
		}
	}
}
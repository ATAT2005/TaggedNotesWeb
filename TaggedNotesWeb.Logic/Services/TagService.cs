using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TaggedNotesWeb.DataAccess.Entities;
using TaggedNotesWeb.DataAccess.Interfaces;
using TaggedNotesWeb.Logic.Entities;
using TaggedNotesWeb.Logic.Interfaces;

namespace TaggedNotesWeb.Logic.Services
{
	public class TagService : ITagService
	{
		IUnitOfWork _unitOfWork { get; set; }

		IMapper _mapper { get; set; }

		public TagService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDAL, TagDTO>()).CreateMapper();
		}

		public void AddTag(TagDTO Tag)
		{
			_unitOfWork.Tags.Create(_mapper.Map<TagDTO, TagDAL>(Tag));
		}

		public void UpdateTag(TagDTO Tag)
		{
			_unitOfWork.Tags.Update(_mapper.Map<TagDTO, TagDAL>(Tag));
		}

		public void DeleteTag(TagDTO Tag)
		{
			_unitOfWork.Tags.Delete(Tag?.Id);
		}

		public TagDTO GetTag(int? idTag)
		{
			return _mapper.Map<TagDAL, TagDTO>(_unitOfWork.Tags.Read(idTag));
		}

		public IEnumerable<TagDTO> GetTags()
		{
			return _mapper.Map<IEnumerable<TagDAL>, IEnumerable<TagDTO>>(_unitOfWork.Tags.ReadAll());
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}
	}
}
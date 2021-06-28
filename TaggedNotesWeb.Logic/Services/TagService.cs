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

		IMapper _mapperDtoToDal { get; set; }

		IMapper _mapperDalToDto { get; set; }

		public TagService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_mapperDalToDto = new MapperConfiguration(cfg => cfg.CreateMap<TagDAL, TagDTO>()).CreateMapper();

			_mapperDtoToDal = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, TagDAL>()).CreateMapper();
		}

		public void AddTag(TagDTO Tag)
		{
			Tag.Id = 0;
			_unitOfWork.Tags.Create(_mapperDtoToDal.Map<TagDTO, TagDAL>(Tag));
		}

		public void UpdateTag(TagDTO Tag)
		{
			_unitOfWork.Tags.Update(_mapperDtoToDal.Map<TagDTO, TagDAL>(Tag));
		}

		public void DeleteTag(TagDTO Tag)
		{
			_unitOfWork.Tags.Delete(Tag?.Id);
		}

		public TagDTO GetTag(int? idTag)
		{
			return _mapperDalToDto.Map<TagDAL, TagDTO>(_unitOfWork.Tags.Read(idTag));
		}

		public IEnumerable<TagDTO> GetTags()
		{
			return _mapperDalToDto.Map<IEnumerable<TagDAL>, IEnumerable<TagDTO>>(_unitOfWork.Tags.ReadAll());
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}

		public void SaveChanges()
		{
			_unitOfWork.Save();
		}
	}
}
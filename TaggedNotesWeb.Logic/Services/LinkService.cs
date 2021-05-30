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
	public class LinkService : ILinkService
	{
		IUnitOfWork _unitOfWork { get; set; }

		IMapper _mapper { get; set; }

		public LinkService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_mapper = new MapperConfiguration(cfg => cfg.CreateMap<LinkDAL, LinkDTO>()).CreateMapper();
		}

		public void AddLink(LinkDTO Link)
		{
			_unitOfWork.Links.Create(_mapper.Map<LinkDTO, LinkDAL>(Link));
		}

		public void UpdateLink(LinkDTO Link)
		{
			_unitOfWork.Links.Update(_mapper.Map<LinkDTO, LinkDAL>(Link));
		}

		public void DeleteLink(LinkDTO Link)
		{
			_unitOfWork.Links.Delete(Link?.Id);
		}

		public LinkDTO GetLink(int? idLink)
		{
			return _mapper.Map<LinkDAL, LinkDTO>(_unitOfWork.Links.Read(idLink));
		}

		public IEnumerable<LinkDTO> GetLinks()
		{
			return _mapper.Map<IEnumerable<LinkDAL>, IEnumerable<LinkDTO>>(_unitOfWork.Links.ReadAll());
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}
	}
}
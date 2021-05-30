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
	public class NoteService : INoteService
	{
		IUnitOfWork _unitOfWork { get; set; }

		IMapper _mapper { get; set; }

		public NoteService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_mapper = new MapperConfiguration(cfg => cfg.CreateMap<NoteDAL, NoteDTO>()).CreateMapper();
		}

		public void AddNote(NoteDTO note)
		{
			_unitOfWork.Notes.Create(_mapper.Map<NoteDTO, NoteDAL>(note));
		}

		public void UpdateNote(NoteDTO note)
		{
			_unitOfWork.Notes.Update(_mapper.Map<NoteDTO, NoteDAL>(note));
		}

		public void DeleteNote(NoteDTO note)
		{
			_unitOfWork.Notes.Delete(note?.Id);
		}

		public NoteDTO GetNote(int? idNote)
		{
			return _mapper.Map<NoteDAL, NoteDTO>(_unitOfWork.Notes.Read(idNote));
		}

		public IEnumerable<NoteDTO> GetNotes()
		{
			return _mapper.Map<IEnumerable<NoteDAL>, IEnumerable<NoteDTO>>(_unitOfWork.Notes.ReadAll());
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}
	}
}
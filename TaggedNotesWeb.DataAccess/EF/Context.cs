using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using TaggedNotesWeb.DataAccess.Entities;
using TaggedNotesWeb.DataAccess.Interfaces;
using TaggedNotesWeb.DataAccess.Repositories;

namespace TaggedNotesWeb.DataAccess.EF
{
	public class Context : DbContext
	{
		private readonly IConfiguration _configuration;

		//private IDbConnection DbConnection { get; }

		public DbSet<NoteDAL> Notes { get; set; }

		public DbSet<TagDAL> Tags { get; set; }

		public DbSet<LinkDAL> Links { get; set; }

		public Context() : this(null)
		{ }

		public Context(IConfiguration configuration)
		{
			_configuration = configuration;

			if (!this.Database.GetService<IRelationalDatabaseCreator>().Exists())
			{
				Database.EnsureCreated();

				using (var uow = new UnitOfWork(configuration))
				{
					var note1 = new NoteDAL() { Text = "\"Auto\" value for RowDefinition Height or ColumnDefinition Width means row/column will take only space it needs" };
					uow.Notes.Create(note1);

					var note2 = new NoteDAL() { Text = "\"*\" value for RowDefinition Height/ColumnDefinition Width means row/column will stretch and can be used as a fraction: *, 2*, etc" };
					uow.Notes.Create(note2);

					var note3 = new NoteDAL() { Text = "Entity Framework Core for Sqlite requires to create classes for relation tables" };
					uow.Notes.Create(note3);

					var tag1 = new TagDAL() { Name = "WPF" };
					uow.Tags.Create(tag1);

					var tag2 = new TagDAL() { Name = "GUI" };
					uow.Tags.Create(tag2);

					var tag3 = new TagDAL() { Name = "ORM" };
					uow.Tags.Create(tag3);

					uow.Save();

					var link1 = new LinkDAL() { IdNote = note1.Id, IdTag = tag1.Id };
					uow.Links.Create(link1);

					var link2 = new LinkDAL() { IdNote = note1.Id, IdTag = tag2.Id };
					uow.Links.Create(link2);

					var link3 = new LinkDAL() { IdNote = note2.Id, IdTag = tag1.Id };
					uow.Links.Create(link3);

					var link4 = new LinkDAL() { IdNote = note2.Id, IdTag = tag2.Id };
					uow.Links.Create(link4);

					var link5 = new LinkDAL() { IdNote = note3.Id, IdTag = tag3.Id };
					uow.Links.Create(link5);

					uow.Save();
				}
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (_configuration != null)
				optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<LinkDAL>().HasKey(p => new { p.IdNote, p.IdTag });
		}
	}
}
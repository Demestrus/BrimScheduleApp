﻿using System;
using BrimSchedule.Domain.Models;
using BrimSchedule.Persistence.EF;
using BrimSchedule.Persistence.Interfaces;

namespace BrimSchedule.Persistence.Repositories
{
	public class EFUnitOfWork: IUnitOfWork
	{
		private bool _disposed;
		private readonly BrimScheduleContext _db;
		private Repository<User> _userRepository;
		private Repository<Profile> _profileRepository;
		private Repository<Role> _roleRepository;
		private Repository<Lesson> _lessonRepository;
		private Repository<Attendance> _attendanceRepository;
		private Repository<Audit> _auditRepository;
		private Repository<UserSuggestionList> _userSuggestionListRepository;

		public EFUnitOfWork(BrimScheduleContext dbContext)
		{
			_db = dbContext;
		}

		public IRepository<User> Users => _userRepository ??= new Repository<User>(_db);
		public IRepository<Profile> Profiles => _profileRepository ??= new Repository<Profile>(_db);
		public IRepository<Role> Roles => _roleRepository ??= new Repository<Role>(_db);
		public IRepository<Lesson> Lessons => _lessonRepository ??= new Repository<Lesson>(_db);
		public IRepository<Attendance> Attendance => _attendanceRepository ??= new Repository<Attendance>(_db);
		public IRepository<Audit> Audit => _auditRepository ??= new Repository<Audit>(_db);
		public IRepository<UserSuggestionList> UserSuggestionLists =>  _userSuggestionListRepository ??= new Repository<UserSuggestionList>(_db);

		public void Save()
		{
			_db.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_db.Dispose();
				}

				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

﻿using System;
using System.Collections.Generic;
using BrimSchedule.Domain.Models.Enum;

namespace BrimSchedule.Domain.Models
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartsOnUtc { get; set; }
		public LessonStatus Status { get; set; }
		public int? DurationMin { get; set; }
		public string Description { get; set; }
		public bool IsDeleted { get; set; }

		public virtual ICollection<Attendance> Attendance { get; set; }
	}
}
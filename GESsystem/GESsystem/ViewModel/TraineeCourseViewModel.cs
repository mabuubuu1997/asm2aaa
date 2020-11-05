using GESsystem.Models;
using System.Collections.Generic;

namespace GESsystem.ViewModel
{
	public class TraineeCourseViewModel
	{
		public TraineeCourse TraineeCourse { get; set; }
		
		public IEnumerable<ApplicationUser> Trainees { get; set; }
		public IEnumerable<Course> Courses { get; set; }
      
    }
}
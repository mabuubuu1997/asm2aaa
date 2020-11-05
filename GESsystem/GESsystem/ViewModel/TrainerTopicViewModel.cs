using GESsystem.Models;
using System.Collections.Generic;

namespace GESsystem.ViewModel
{
	public class TrainerTopicViewModel
	{

		public Topic Topic { get; set; }
		public TrainerTopic TrainerTopic { get; set; }
		public IEnumerable<ApplicationUser> Trainers { get; set; }
		public IEnumerable<Topic> Topics { get; set; }
       
    }
}
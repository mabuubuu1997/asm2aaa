using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GESsystem.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("Category Name")]
		public string Name { get; set; }

	}
}
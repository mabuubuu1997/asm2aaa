using GESsystem.Models;
using GESsystem.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GESsystem.Controllers
{
	public class CoursesController : Controller
	{
		private ApplicationDbContext _context;


		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}


		public ActionResult Index()
		{
			{
				var courses = _context.Courses
					.Include(p => p.Category)
					.Include(p => p.Topic)
					.ToList();
				return View(courses);
			}
		}
		[HttpGet]
		[Authorize(Roles = "TrainingStaff")]
		public ActionResult Create()
		{
			var viewModel = new CourseCategoryViewModel
			{
				Categories = _context.Categories.ToList(),
				Topics = _context.Topics.ToList(),
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (_context.Courses.Any(c => c.Name == course.Name &&
			c.TopicId == course.TopicId &&
											c.CategoryId == course.CategoryId))
			{
				return View("~/Views/Courses/CheckExists.cshtml");
			}

			var newCourse = new Course
			{
				Name = course.Name,
				TopicId = course.TopicId,
				CategoryId = course.CategoryId,
			};

			_context.Courses.Add(newCourse);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "TrainingStaff")]
		public ActionResult Delete(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == id);
			if (courseInDb == null)
			{
				return HttpNotFound();
			}
			_context.Courses.Remove(courseInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		[Authorize(Roles = "TrainingStaff")]
		public ActionResult Edit(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == id);
			if (courseInDb == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CourseCategoryViewModel
			{
				Course = courseInDb,
				Categories = _context.Categories,
				Topics = _context.Topics
				.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == course.Id);
			if (courseInDb == null)
			{
				return HttpNotFound();
			}

			courseInDb.Name = course.Name;
			courseInDb.Id = course.Id;
			courseInDb.TopicId = course.TopicId;
			courseInDb.CategoryId = course.CategoryId;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
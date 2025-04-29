using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab7_StudentRegistration.Data;
using Lab7_StudentRegistration.Models;

namespace Lab7_StudentRegistration.Pages
{
    public class StudentListModel : PageModel
    {
        private readonly StudentDbContext _context;

        public StudentListModel(StudentDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = new List<Student>();
        public IList<StuMajor> StudentMajors { get; set; } = new List<StuMajor>();
        
        public string IdSort { get; set; }
        public string NameSort { get; set; }
        public string ProgSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            Console.WriteLine("Loading student list with sort order: " + (sortOrder ?? "default"));
            
            // Set up sorting parameters
            CurrentSort = sortOrder;
            IdSort = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            NameSort = sortOrder == "name" ? "name_desc" : "name";
            ProgSort = sortOrder == "prog" ? "prog_desc" : "prog";

            try
            {
                // Get all student majors
                StudentMajors = await _context.StuMajors.ToListAsync();
                Console.WriteLine($"Loaded {StudentMajors.Count} student major records");
                
                // Get students with sorting
                IQueryable<Student> studentsIQ = from s in _context.Students
                                               select s;

                Console.WriteLine($"Found {await studentsIQ.CountAsync()} students before sorting");

                switch (sortOrder)
                {
                    case "id_desc":
                        studentsIQ = studentsIQ.OrderByDescending(s => s.Stu_ID);
                        break;
                    case "name":
                        studentsIQ = studentsIQ.OrderBy(s => s.Stu_Name);
                        break;
                    case "name_desc":
                        studentsIQ = studentsIQ.OrderByDescending(s => s.Stu_Name);
                        break;
                    case "prog":
                        studentsIQ = studentsIQ.OrderBy(s => s.Stu_Prog);
                        break;
                    case "prog_desc":
                        studentsIQ = studentsIQ.OrderByDescending(s => s.Stu_Prog);
                        break;
                    default:
                        studentsIQ = studentsIQ.OrderBy(s => s.Stu_ID);
                        break;
                }

                Students = await studentsIQ.AsNoTracking().ToListAsync();
                Console.WriteLine($"Loaded {Students.Count} students after sorting");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading student data: {ex.Message}");
            }
        }
    }
}
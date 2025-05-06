using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab7_StudentRegistration.Data;
using Lab7_StudentRegistration.Models;
using Lab7_StudentRegistration.Services;

namespace Lab7_StudentRegistration.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly StudentDbContext _context;
        private readonly XmlDataService _xmlDataService;

        public RegisterModel(StudentDbContext context, XmlDataService xmlDataService)
        {
            _context = context;
            _xmlDataService = xmlDataService;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        [BindProperty]
        public List<string> SelectedMajors { get; set; } = new List<string>();

        public List<Major> Majors { get; set; } = new List<Major>();
        
        public bool IsSuccess { get; set; }

        public void OnGet()
        {
            Console.WriteLine("OnGet method called");
            Majors = _xmlDataService.GetMajors();
            Console.WriteLine($"Loaded {Majors.Count} majors from XML file");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPost method called");
            Majors = _xmlDataService.GetMajors();
            
            // Custom validation for Student ID
            if (!Regex.IsMatch(Student.Stu_ID, @"^[Ss][0-9]{8}$"))
            {
                ModelState.AddModelError("Student.Stu_ID", "Student ID must start with 'S' followed by 8 digits");
            }
            
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                return Page();
            }

            try
            {
                Console.WriteLine($"Saving student: {Student.Stu_ID}, {Student.Stu_Name}");
                
                // Save student to database
                _context.Students.Add(Student);
                
                // Save selected majors
                if (SelectedMajors != null && SelectedMajors.Any())
                {
                    Console.WriteLine($"Selected majors: {string.Join(", ", SelectedMajors)}");
                    
                    foreach (var major in SelectedMajors)
                    {
                        var stuMajor = new StuMajor
                        {
                            Stu_ID = Student.Stu_ID,
                            Stu_Majors = major
                        };
                        _context.StuMajors.Add(stuMajor);
                    }
                }
                else
                {
                    Console.WriteLine("No majors selected");
                }
                
                await _context.SaveChangesAsync();
                Console.WriteLine("Successfully saved to database");
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to database: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the data.");
                return Page();
            }
            
            return Page();
        }
    }
}
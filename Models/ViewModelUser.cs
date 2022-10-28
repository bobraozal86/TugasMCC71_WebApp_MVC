using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tugas4MCC71.Models
{
    public class ViewModelUser
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; }
        public int Employee_Id { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> Employees { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tugas4MCC71.Models
{
    public class User
    {
        public User(int Id, string Password, int Role_Id, int Employee_Id)
        {
            this.Id = Id;
            this.Password = Password;
            this.Role_Id = Role_Id;
            this.Employee_Id = Employee_Id;
           
        }
        public User()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }

        [ForeignKey("Employee")]
        public int Employee_Id { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }

        
    }
}

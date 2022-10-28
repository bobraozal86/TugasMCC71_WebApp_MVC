using System.ComponentModel.DataAnnotations;

namespace Tugas4MCC71.Models
{
    public class Role
    {
        public Role(int Role_Id, string Name)
        {
            this.Role_Id = Role_Id;
            this.Name = Name;
        }
        public Role()
        {

        }
        [Key]
        public int Role_Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

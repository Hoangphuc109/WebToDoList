using System;
using System.ComponentModel.DataAnnotations;

namespace WebToDoList.Models
{
    public class ToDoList
    {
        [Key] // Định nghĩa Id_work là khóa chính
        public int Id_work { get; set; }
        public string Name_of_work { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace ToDoOnSteps
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public bool Checked { get; set; }
    }
}

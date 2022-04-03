using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo
{
    public class Task
    {

        public Task()
        {
        }

        public Task(long id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Description { get; set; }
    }
}

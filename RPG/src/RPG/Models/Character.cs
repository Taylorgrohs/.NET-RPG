using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Models
{
    [Table("Characters")]
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        private const int DefaultLevel = 1;
        private const int DefaultHealth = 100;

        public Character()
        {
            Level = DefaultLevel;
            Health = DefaultHealth;
        }
    }
}

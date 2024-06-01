using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spendit.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}

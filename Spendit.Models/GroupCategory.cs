using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spendit.Models
{
    public class GroupCategory
    {
        [Key]
        public int GroupCategoryId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        

        public string CreatorId { get; set; }


        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        public Group Group { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        [Column(TypeName = "nvarchar(15)")]
        public string Type { get; set; } = "Expense";

        public bool IsApproved { get; set; } = false;

        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return this.Icon + " " + this.Title;
            }
        }
    }
}

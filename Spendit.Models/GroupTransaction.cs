using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Spendit.Models
{
    public class GroupTransaction
    {
        [Key]
        public int GroupTransactionId { get; set; }

        
        public string CreatorId { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select a Category")]
        public int GroupCategoryId { get; set; }
        public GroupCategory? GroupCategory { get; set; } //navigational property for foreign key

        
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public int Amount { get; set; }

        
        [StringLength(150, ErrorMessage = "Note cannot exceed 150 characters.")]
        [Column(TypeName = "nvarchar(150)")]
        public string? Note { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;


        public bool IsApproved { get; set; } = false;


        [NotMapped]
        public string? GroupCategoryTitleWithIcon
        {
            get
            {
                return GroupCategory == null ? "" : GroupCategory.Icon + " " + GroupCategory.Title;
            }
        }

        
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((GroupCategory == null || GroupCategory.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}

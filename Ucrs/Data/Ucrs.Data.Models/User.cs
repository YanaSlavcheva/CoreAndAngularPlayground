namespace Ucrs.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using Ucrs.Data.Common.Models.Contracts;
    using Ucrs.Common;

    public class User : IdentityUser, IUser
    {
        // TODO: set index in model builder
        [Required]
        [MaxLength(GlobalConstants.EmailMaxLength)]
        [MinLength(GlobalConstants.EmailMinLength)]
        [RegularExpression(GlobalConstants.EmailRegEx)]
        public override string Email { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the CreatedOn property should be automatically set
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

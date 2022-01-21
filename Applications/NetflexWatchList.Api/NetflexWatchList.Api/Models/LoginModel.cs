using System.ComponentModel.DataAnnotations;

namespace NetflexWatchList.Api.Models
{
    /// <summary>
    /// The LoginModel.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

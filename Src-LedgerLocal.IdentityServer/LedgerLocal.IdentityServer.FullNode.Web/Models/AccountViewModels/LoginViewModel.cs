using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerLocal.IdentityServer.FullNode.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [EmailAddress]
        public string EmailForgot { get; set; }

        [EmailAddress]
        public string EmailRegister { get; set; }

        public string RealEmail()
        {
            if (!string.IsNullOrWhiteSpace(Email))
            {
                return Email;
            }

            if (!string.IsNullOrWhiteSpace(EmailForgot))
            {
                return EmailForgot;
            }

            if (!string.IsNullOrWhiteSpace(EmailRegister))
            {
                return EmailRegister;
            }

            return null;
        }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string PasswordRegister { get; set; }

        public string RealPassword()
        {
            if (!string.IsNullOrWhiteSpace(Password))
            {
                return Password;
            }

            if (!string.IsNullOrWhiteSpace(PasswordRegister))
            {
                return PasswordRegister;
            }
            
            return null;
        }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        
        [Display(Name = "GodFatherId")]
        public string GodFatherId { get; set; }

        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Terms and Conditions")]
        public bool IsAgree { get; set; }

        [Display(Name = "Terms and Conditions")]
        public bool IsAgree2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProfile.Models.SignUp
{
    public class SignUpFormViewModel
    {
        public SignUpFormViewModel()
        {
            SignUpFormModel = new SignUpFormModel();
        }

        public SignUpFormModel SignUpFormModel { get; set; }
    }
}

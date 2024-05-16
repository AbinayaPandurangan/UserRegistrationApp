using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podme.UserRegistrationApp.Api.Models.ValidationResultModels
{
    public class Result
    {
        public bool IsValid { get; set; }
        public string Errors { get; set; }
    }
}

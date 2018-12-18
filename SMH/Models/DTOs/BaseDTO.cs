using System.Collections.Generic;

namespace SMH.Models.DTOs
{
    public class BaseDTO
    {
        public int Status { get; set; }
        public string ValidationErrorMessage { get; set; }
        public List<string> ValidationErrorMessages { get; set; }
    }
}
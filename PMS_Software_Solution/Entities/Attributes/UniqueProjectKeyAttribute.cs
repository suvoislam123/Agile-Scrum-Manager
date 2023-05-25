using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Attributes
{
    public class UniqueProjectKeyAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var dbContext = (PMS_DBContext)validationContext.GetService(typeof(PMS_DBContext));
                var propertyName = validationContext.MemberName;
                var propertyValue = value.ToString();

                var exists = dbContext.Projects.Any(m => m.ProjectKey == propertyValue);

                if (exists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

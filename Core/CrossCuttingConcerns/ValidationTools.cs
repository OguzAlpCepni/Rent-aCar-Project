using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns
{
    public static class ValidationTools
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context =  new ValidationContext<object>(entity);              // entity için dogrulama işlemi yap
            var result = validator.Validate(context);
            if (result.IsValid)                                                // gecerli değilse hata fırlat 
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

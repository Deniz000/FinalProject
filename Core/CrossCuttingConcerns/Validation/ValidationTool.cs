using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool 
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); // context ilgili bi tred, Product için bir doğrulama yapacağım diyoruz. Ceneric de product
            var result = validator.Validate(context);// kurallar için ilgili context, 83 ü doğrular(bu 85)
            if (!result.IsValid) //doğru değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
            
        }
    }
}

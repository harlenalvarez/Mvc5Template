using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Template.App_Code.CustomValidations
{
    public class MaxWordsAttribute:ValidationAttribute, IClientValidatable
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords):base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var valueAsString = value.ToString();
              
                if(valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(name:validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        //This is for rendering client side error messages, requires jsquery unobtrusive and the js code
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(name: metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", _maxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}
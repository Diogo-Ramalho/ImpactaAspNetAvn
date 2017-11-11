using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Validacoes
{
    public class IdadeMinimaAttribute : ValidationAttribute, IClientValidatable
    {
        private int _idadeMinima;
        private string _mensagemErro;

        public IdadeMinimaAttribute(int idadeMinima)
        {
            _idadeMinima = idadeMinima;
            _mensagemErro = $"A idade mínima é de {_idadeMinima} anos.";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //throw new NotImplementedException();
            var regra = new ModelClientValidationRule
            {
                ErrorMessage = _mensagemErro,
                ValidationType = "regraidademinima"
            };

            regra.ValidationParameters.Add("valoridademinima", _idadeMinima);

            //return new List<ModelClientValidationRule> { regra };

            yield return regra;

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dataNascimento = (DateTime)value;

            if (dataNascimento.AddYears(_idadeMinima) > DateTime.Now)
            {
                return new ValidationResult(_mensagemErro);
            }

            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}
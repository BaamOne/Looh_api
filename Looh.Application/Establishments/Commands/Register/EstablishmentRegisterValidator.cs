using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Establishments.Commands.Register
{
    public class EstablishmentRegisterValidator: AbstractValidator<EstablishmentRegisterCommand>
    {
        public EstablishmentRegisterValidator() {
            RuleFor(x => x.FundationDate)
               .NotEmpty().WithMessage("Fundation Date is required")
               .LessThanOrEqualTo(DateTime.Now).WithMessage("Fundation Date cannot be in the future");

            RuleFor(x => x.Telephone)
                .NotEmpty().WithMessage("Telephone is required")
                .Matches(@"^\(\d{2}\) \d{4,5}-\d{4}$").WithMessage("Telephone is not valid");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("CNPJ is required")
                .Matches(@"^\d{14}$").WithMessage("CNPJ must have 14 digits")
                .Must(BeAValidCnpj).WithMessage("CNPJ is not valid");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF is required")
                .Matches(@"^\d{11}$").WithMessage("CPF must have 11 digits")
                .Must(BeAValidCpf).WithMessage("CPF is not valid");

            RuleFor(x => x.WorkingHours)
                .NotEmpty().WithMessage("Working Hours is required")
                .Matches(@"^\d{2}:\d{2}-\d{2}:\d{2}$").WithMessage("Working Hours format is invalid");

            RuleFor(x => x.IntervalHours)
                .NotEmpty().WithMessage("Interval Hours is required")
                .Matches(@"^\d{2}:\d{2}-\d{2}:\d{2}$").WithMessage("Interval Hours format is invalid");

            RuleFor(x => x.WorkingDays)
                .NotEmpty().WithMessage("At least one working day is required")
                .Must(list => list.Count > 0).WithMessage("You must specify at least one working day");

        }

        private bool BeAValidCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCnpj;
            string digito;
            int soma;
            int resto;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private bool BeAValidCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}

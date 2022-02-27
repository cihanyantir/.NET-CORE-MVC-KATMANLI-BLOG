using System;

using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Validation_Rules
{
   
    
        public class ProfileImageModelValidator : AbstractValidator<ProfileImageModell>
        {
            public ProfileImageModelValidator()
            {//password bir büyük bir küçük ekle, password confirmation ekle
          
                RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kullanıcı Adı Soyadı Boş Geçilemez");
                RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
                RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password Boş Geçilemez");
            RuleFor(x => x.WriterPassword).MinimumLength(5).WithMessage("Password En Az 5 Karakter Olmalıdır");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın");
                RuleFor(x => x.WriterName).MaximumLength(15).WithMessage("En çok 15 karakter girişi yapın");
            }
        }
    }


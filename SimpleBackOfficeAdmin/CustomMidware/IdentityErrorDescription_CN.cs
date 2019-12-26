using Microsoft.AspNetCore.Identity;

namespace SimpleBackOfficeAdmin.CustomMidware
{
    internal class IdentityErrorDescription_CN:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError {Code=nameof(PasswordRequiresDigit),Description="密码必须包含数字" };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "密码必须包含小写字母" };
        }
    }
}

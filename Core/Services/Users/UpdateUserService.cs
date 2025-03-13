using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            if (email != null)
            {
                user.SetEmail(email);
            }
            user.SetName(name);
            user.SetType(type);
            if (annualSalary != null)
            {
                user.SetMonthlySalary(annualSalary.Value / 12);
            }

            if (tags != null)
            {
                user.SetTags(tags);
            }
        }
    }
}
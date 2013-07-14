using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Data.RepositoryExtensions
{
    public static class AccountProfileRepositoryExtensions
    {
        private static readonly int BCRYPT_WORK_FACTOR = 11;

        public static string Encode(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCRYPT_WORK_FACTOR);
        }

        public static bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static AccountProfile GetByEmail(this IRepository<AccountProfile> repository, string email)
        {
            return repository.Find(acc => acc.Email == email);
        }

        public static bool VerifyUser(this IRepository<AccountProfile> repository, string email, string password)
        {
            var entity = repository.GetByEmail(email);
            return Verify(password, entity.Password);
        }

        public static string GetRoleForAccount(this IRepository<AccountProfile> repository, string email)
        {
            var entity = repository.GetByEmail(email);
            return entity.Role.ToString();
        }

        public static void RegisterAccount(this IRepository<AccountProfile> repository, AccountProfile accountData, string password)
        {
            accountData.Password = Encode(password);                
            repository.SaveOrUpdateAll(accountData);

        }

    }
}

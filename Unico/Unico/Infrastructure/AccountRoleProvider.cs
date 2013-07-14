using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Unico.Data.Entities;
using Unico.Data.Enum;
using Unico.Data.Interfaces;
using Unico.Data.RepositoryExtensions;

namespace Unico.Infrastructure
{
    public class AccountRoleProvider : RoleProvider
    {
        public IRepository<AccountProfile> AccountRepository { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        private string applicationName;
        public override string ApplicationName
        {
            get { return applicationName; }
            set { applicationName = value; }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return Enum.GetNames(typeof(AccountRole));
        }

        public override string[] GetRolesForUser(string username)
        {
            return new[] { AccountRepository.GetRoleForAccount(username) };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRole = AccountRepository.GetRoleForAccount(username);
            return username.Equals(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
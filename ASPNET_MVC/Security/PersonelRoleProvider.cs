﻿using ASPNET_MVC.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ASPNET_MVC.Security
{
    public class PersonelRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        
        public override string[] GetRolesForUser(string username)
        {
            ProjeMVCEntities db = new ProjeMVCEntities();
            // Kullanıcı ve şifre var mı
            try
            {
                var bkullanici = db.Kullanici.FirstOrDefault(x => x.Ad == username);
                return new string[] { bkullanici.Role };
            }
            catch (Exception)
            {
                var bkullanici2 = db.Gelismis.FirstOrDefault(x => x.KullaniciAdi == username);
                return new string[] { bkullanici2.Role };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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
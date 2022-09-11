using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SystemUser : User
    {
        public virtual ICollection<Social> Socials { get; set; }

        public SystemUser()
        {

        }

        public SystemUser(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}

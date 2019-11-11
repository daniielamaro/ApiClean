using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.User.Save
{
    public class UserSaveRequest
    {
        public Domain.User.User User { get; private set; }

        public UserSaveRequest(string name, string email, string password)
        {
            User = new Domain.User.User(Guid.NewGuid(), name, email, password);
        }

        public UserSaveRequest(Guid id, string name, string email, string password)
        {
            User = new Domain.User.User(id, name, email, password);
        }
    }
}

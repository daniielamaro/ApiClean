using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.User.Save
{
    public interface IUserSave
    {
        void Execute(UserSaveRequest request);
    }
}

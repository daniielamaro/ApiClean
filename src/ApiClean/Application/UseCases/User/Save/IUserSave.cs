﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.User.Save
{
    public interface IUserSave
    {
        void Execute(UserSaveRequest request);
    }
}

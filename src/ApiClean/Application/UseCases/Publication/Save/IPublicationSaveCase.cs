﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save
{
    public interface IPublicationSaveCase
    {
        void Execute(PublicationSaveRequest request);
    }
}
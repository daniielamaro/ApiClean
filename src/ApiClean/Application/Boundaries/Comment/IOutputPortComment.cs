﻿using Application.Boundaries.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.Comment
{
    public interface IOutputPortComment : IOutputPort<Domain.Comment.Comment>
    {
    }
}
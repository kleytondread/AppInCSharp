﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Exceptions
{
    public class ExceptionBadRequest : Exception
    {
        public ExceptionBadRequest(string message) : base(message)
        {
        }
    }
}


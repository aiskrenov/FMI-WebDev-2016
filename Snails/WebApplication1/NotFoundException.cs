﻿using System;

namespace WebApplication1
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) 
            : base(message)
        { }
    }
}
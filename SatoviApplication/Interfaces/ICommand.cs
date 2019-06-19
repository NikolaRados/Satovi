﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Interfaces
{
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request);
    }

    public interface ICommand<TRequest, TResponse> where TResponse : class
    {
        TResponse Execute(TRequest request);
    }
}

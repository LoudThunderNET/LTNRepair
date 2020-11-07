using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSR.Abstraction
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse: class
    {
    }
}

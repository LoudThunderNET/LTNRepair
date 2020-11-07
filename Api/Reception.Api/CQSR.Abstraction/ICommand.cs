using MediatR;
using System;

namespace CQSR.Abstraction
{
    public interface ICommand<TCommandResult> : IRequest<TCommandResult> 
        where TCommandResult : struct
    {
    }
}

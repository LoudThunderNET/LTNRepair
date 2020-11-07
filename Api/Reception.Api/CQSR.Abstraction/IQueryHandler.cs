﻿using MediatR;

namespace CQSR.Abstraction
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
        where TResponse: class
        where TQuery : IQuery<TResponse>
    {
    }
}

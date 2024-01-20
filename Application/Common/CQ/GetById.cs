namespace Application.Common.CQ;

public record GetById<TDto, TPK>(int? Id) : IRequest<TDto>;

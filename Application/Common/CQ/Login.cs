namespace Application.Common.CQ;

public record Login<TDto>(TDto dto) : IRequest<string>;

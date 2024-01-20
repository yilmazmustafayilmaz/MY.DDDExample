namespace Application.Common.CQ;

public record Register<TDto>(TDto dto) : IRequest<string>;

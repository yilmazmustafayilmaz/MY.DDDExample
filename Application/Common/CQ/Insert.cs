namespace Application.Common.CQ;

public record Insert<TDto>(TDto dto) : IRequest<bool>;

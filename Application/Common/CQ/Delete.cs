namespace Application.Common.CQ;

public record Delete<TViewModel, TPk>(TPk Id) : IRequest;
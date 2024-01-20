using Domain.Common;

namespace Application.Common.Intefaces;

public interface IUser : IDomainService { string? Id { get; } }
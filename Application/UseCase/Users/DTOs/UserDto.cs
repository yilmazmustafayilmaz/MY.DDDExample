﻿namespace Application.UseCase.Users.DTOs;

public record UserDto(
    int? Id,
    string? Name,
    string? Surname,
    string? Email,
    string? Password,
    string? Role);

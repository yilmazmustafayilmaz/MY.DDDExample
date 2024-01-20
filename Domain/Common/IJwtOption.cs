﻿namespace Domain.Common;

public interface IJwtOption
{
    string Secret { get; set; }
    string Issuer { get; set; }
    string Audience { get; set; }
    int Expires { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Users.Responses;

public sealed record UserResponseDto
{
    string FirstName { get; init; } = null!;
    string LastName { get; init; } = null!;
    string Email { get; init; } = null!;
    string UserName { get; init; } = null!;
}

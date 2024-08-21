using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Contracts.Authentication;


public record RegisterRequest(
    string Name,
    string Telephone,
    string Email,
    string Password);



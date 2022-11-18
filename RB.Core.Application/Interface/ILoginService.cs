using RB.Core.Application.DTO;
using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.Interface
{
    public interface ILoginService
    {
        string Login(LoginDTO loginDTO);
    }
}

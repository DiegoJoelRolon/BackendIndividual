using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Validations
{
    public interface IClientValidations
    {
        Task<bool> CheckCreatingClient(ClientRequest request);
    }
}

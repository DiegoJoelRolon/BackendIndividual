using Application.Exceptions;
using Application.Interfaces.Validations;
using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class ClientValidations : IClientValidations
    {

        public Task<bool> CheckCreatingClient(ClientRequest request)
        {
            if (!request.Email.ToLower().Contains("@") && !request.Email.ToLower().Contains(".com"))
            {
                throw new Conflict("The email format is incorrect");
            }
            if (request.Phone.Length < 8)
            {
                throw new Conflict("Phone must have at least 8 numbers");
            }
            return Task.FromResult(false);
        }
    }
}

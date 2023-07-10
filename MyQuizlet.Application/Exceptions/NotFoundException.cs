using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Xml.Linq;

namespace MyQuizlet.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base($"{message} was not found") { }

        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found") { }
    }
}

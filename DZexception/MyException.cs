using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DZexception
{
    internal class MyException : Exception
    {
        public MyException NoRootsException()
        {
            throw new NotImplementedException("Вещественных значений не найдено");
        }        
    }
}

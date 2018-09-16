using System;
using System.Collections.Generic;
using System.Text;

namespace Kartamulia.Accounting.BusinessRules
{
    public interface IValidator<T>
    {
        bool Validate(T data);
    }
}

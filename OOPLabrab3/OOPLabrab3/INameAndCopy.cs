using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}

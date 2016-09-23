using System;

namespace Pgmasst.Main
{
    public interface IFormOutput<in T>
    {
        Action<T> Output { get;}
    }
}
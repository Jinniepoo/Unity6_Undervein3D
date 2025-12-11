using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Undervein.Core
{
    public interface IModifier
    {
        void AddValue(ref int baseValue);
    }
}
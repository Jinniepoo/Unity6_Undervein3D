using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Undervein.Core
{
    public interface IDamageable
    {
        bool IsAlive
        {
            get;
        }

        void TakeDamage(int damage, GameObject hitEffect);
    }
}

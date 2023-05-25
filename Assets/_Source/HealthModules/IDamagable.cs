using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
    public interface IDamagable
    {
        public void Damage();
        public void Annihilate();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Fuel : WeaponScript
    {
        private new void Start()
        {
            base.Start();
            type = "fuel";
        }
    }
}
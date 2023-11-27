using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteScript : WeaponScript
{
    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        Type = "machete";
    }

    protected override void Use()
    {
        base.Use();
    }
}

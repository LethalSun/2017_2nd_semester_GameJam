using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProperty : MonoBehaviour {

    public float missileSpeed;

    public float missileAngularSpeed;

    public float missileDamage;

    public bool isUsed;

    public bool isLunched;

    public int index;

    public int missileID;

    void Start()
    {
        ResetProperty();
    }

    public bool ResetProperty()
    {
        isUsed = false;
        isLunched = false;
        return true;
    }
}

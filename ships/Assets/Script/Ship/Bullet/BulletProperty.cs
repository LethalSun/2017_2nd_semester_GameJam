using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperty : MonoBehaviour {

    public float bulletSpeed;

    public bool isUsed;

    public int index;

    public int bulletID;

    public Vector2 direction;

    void Start()
    {
        ResetProperty();
    }

    public bool ResetProperty()
    {
        isUsed = false;
        return true;
    }
}

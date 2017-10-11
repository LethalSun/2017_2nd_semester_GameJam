using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProperty : MonoBehaviour
{
    public bool isUsed;

    private void Start()
    {
        ResetProperty();
    }

    public bool ResetProperty()
    {
        isUsed = false;

        return true;
    }
}

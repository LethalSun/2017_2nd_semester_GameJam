using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour {
    ParticleSystem ps;
    public bool destroy = false;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void OnEnable()
    {
        StartCoroutine("ParticleProcess");
    }

    IEnumerator ParticleProcess()
    {
        yield return null;

        while (true)
        {
            if (ps.IsAlive(true) == false)
            {
                if (destroy)
                    Destroy(gameObject);
                else
                {
                    transform.parent = null;
                    this.gameObject.SetActive(false);
                    break;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnDisable()
    {
        GetComponent<ParticleProperty>().isUsed = false;
        
    }
}

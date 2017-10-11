using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public int maxParticleNum;

    public GameObject enemyParticle;
    public GameObject[] eParticlePool;

    public GameObject playerParticle;
    public GameObject[] pParticlePool;

    // Use this for initialization
    void Awake()
    {
        eParticlePool = new GameObject[maxParticleNum];
        pParticlePool = new GameObject[maxParticleNum];
        for (int i = 0; i < maxParticleNum; ++i)
        {
            eParticlePool[i] = Instantiate(enemyParticle) as GameObject;
            pParticlePool[i] = Instantiate(playerParticle) as GameObject;
            eParticlePool[i].GetComponent<ParticleProperty>().isUsed = false;
            eParticlePool[i].transform.position = this.transform.position;
            eParticlePool[i].SetActive(true);
            pParticlePool[i].GetComponent<ParticleProperty>().isUsed = false;
            pParticlePool[i].transform.position = this.transform.position;
            pParticlePool[i].SetActive(true);
        }
    }

    public GameObject GetEParticle(int particleID)
    {
        for (int i = 0;i< maxParticleNum;++i)
        {
            if (eParticlePool[i].GetComponent<ParticleProperty>().isUsed == false)
            {
                eParticlePool[i].GetComponent<ParticleProperty>().isUsed = true;

                return eParticlePool[i];
            }
        }
        return null;
    }

    public GameObject GetPParticle(int particleID)
    {
        foreach (var particle in pParticlePool)
        {
            if (particle.GetComponent<ParticleProperty>().isUsed == false)
            {
                particle.GetComponent<ParticleProperty>().isUsed = true;

                return particle;
            }
        }
        return null;
    }

    public bool FreeParticle(GameObject particle)
    {
        particle.transform.position = this.transform.position;
        particle.GetComponent<MissileProperty>().ResetProperty();
        return true;
    }

    private void OnEnable()
    {
        for (int i = 0; i < maxParticleNum; ++i)
        {
            eParticlePool[i].GetComponent<ParticleProperty>().isUsed = false;
            eParticlePool[i].transform.position = this.transform.position;
            eParticlePool[i].SetActive(true);

            pParticlePool[i].GetComponent<ParticleProperty>().isUsed = false;
            pParticlePool[i].transform.position = this.transform.position;
            pParticlePool[i].SetActive(true);
        }
    }
}

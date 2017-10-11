using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    public GameObject[] bullets;

    public int[] missileMaxNumbers;

    public List<GameObject[]> missilePool;

    // Use this for initialization
    void Awake()
    {
        missilePool = new List<GameObject[]>();

        int index = 0;

        foreach (var missile in bullets)
        {
            missilePool.Add(new GameObject[missileMaxNumbers[index]]);
            for (int i = 0; i < missileMaxNumbers[index]; ++i)
            {
                GameObject newMissile = Instantiate(missile) as GameObject;
                newMissile.transform.position = this.transform.position;
                newMissile.GetComponent<BulletProperty>().index = i;
                newMissile.GetComponent<BulletProperty>().bulletID = index;
                newMissile.GetComponent<BulletProperty>().isUsed = false;
                missilePool[index][i] = newMissile;
            }
            ++index;
        }
    }

    public GameObject GetBullet(int missileID)
    {
        foreach (var missile in missilePool[missileID])
        {
            if (missile.GetComponent<BulletProperty>().isUsed == false)
            {
                missile.GetComponent<BulletProperty>().isUsed = true;
                return missile;
            }
        }

        return null;
    }


    public bool FreeMissile(GameObject missile)
    {
        missile.transform.position = this.transform.position;
        missile.GetComponent<MissileProperty>().ResetProperty();
        return true;
    }

    private void OnEnable()
    {
        int index = 0;
        foreach (var missile in bullets)
        {

            for (int i = 0; i < missileMaxNumbers[index]; ++i)
            {
                missilePool[index][i].transform.position = this.transform.position;
                missilePool[index][i].GetComponent<BulletProperty>().isUsed = false;
            }

            ++index;
        }
    }
}

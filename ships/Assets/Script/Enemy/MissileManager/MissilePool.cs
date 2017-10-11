using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePool : MonoBehaviour {

    public GameObject[] missiles;

    public int[] missileMaxNumbers;

    public List<GameObject[]> missilePool;

    public Transform[] startPosition;
    // Use this for initialization
    void Awake()
    {
        missilePool = new List<GameObject[]>();

        int index = 0;

        foreach(var missile in missiles)
        {
            missilePool.Add(new GameObject[missileMaxNumbers[index]]);

            for(int i = 0;i< missileMaxNumbers[index];++i)
            {
                GameObject newMissile = Instantiate(missile) as GameObject;
                newMissile.transform.position = this.transform.position;
                newMissile.GetComponent<MissileProperty>().index = i;
                newMissile.GetComponent<MissileProperty>().missileID = index;

                missilePool[index][i] = newMissile;
            }

            ++index;
        }

        SetStartPosition();

    }

    public GameObject GetMissile(int missileID)
    {
        foreach (var missile in missilePool[missileID])
        {
            if (missile.GetComponent<MissileProperty>().isUsed == false)
            {
                missile.GetComponent<MissileProperty>().isUsed = true;
                missile.GetComponent<MissileProperty>().isLunched = true;
                missile.transform.position = GetRandomStartPosition();
                return missile;
            }
        }

        return null;
    }

    Vector3 GetRandomStartPosition()
    {
        int randomNum = Random.Range(0, 7);

        float randomRatio = Random.Range(0.0f,1.0f);
        Vector3 range = startPosition[randomNum].gameObject.GetComponent<MissileLunchRange>().range* randomRatio;

        return startPosition[randomNum].position + range;
    }

    public bool FreeMissile(GameObject missile)
    {
        missile.transform.position = this.transform.position;
        missile.GetComponent<MissileProperty>().ResetProperty();
        return true;
    }

    bool SetStartPosition()
    {
        startPosition = new Transform[8];


        startPosition[0] = transform.Find("MissilePointN");
        startPosition[1] = transform.Find("MissilePointNE");
        startPosition[2] = transform.Find("MissilePointE");
        startPosition[3] = transform.Find("MissilePointSE");
        startPosition[4] = transform.Find("MissilePointS");
        startPosition[5] = transform.Find("MissilePointSW");
        startPosition[6] = transform.Find("MissilePointW");
        startPosition[7] = transform.Find("MissilePointNW");

        return true;
    }

    private void OnDisable()
    {
        int index = 0;

        foreach (var missile in missiles)
        {
            missilePool.Add(new GameObject[missileMaxNumbers[index]]);

            for (int i = 0; i < missileMaxNumbers[index]; ++i)
            {
                missilePool[index][i].transform.position = this.transform.position;
                missilePool[index][i].GetComponent<MissileProperty>().isUsed = false;
                missilePool[index][i].GetComponent<MissileProperty>().isLunched = false;
            }

            ++index;
        }
    }

    private void OnEnable()
    {
        int index = 0;

        foreach (var missile in missiles)
        {
            missilePool.Add(new GameObject[missileMaxNumbers[index]]);

            for (int i = 0; i < missileMaxNumbers[index]; ++i)
            {
                missilePool[index][i].transform.position = this.transform.position;
                missilePool[index][i].GetComponent<MissileProperty>().isUsed = false;
                missilePool[index][i].GetComponent<MissileProperty>().isLunched = false;
            }

            ++index;
        }
    }
}

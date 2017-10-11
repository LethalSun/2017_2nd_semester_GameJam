using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchMissile : MonoBehaviour
{

    public GameObject missileManager;
    public float lunchInterval;
    public int missileCategoryNum;
    float accumulatedTime;
    MissilePool missilePool;
	// Use this for initialization
	void Start ()
    {
        accumulatedTime = 0.0f;
        missileManager = GameObject.Find("EnemyMissileManager");
        missilePool = missileManager.GetComponent<MissilePool>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float fluctuatedInterval = Random.Range(lunchInterval * 0.9f,lunchInterval*1.1f);

        int missileID = Random.Range(0, missileCategoryNum -1);

        if (accumulatedTime < fluctuatedInterval)
        {
            accumulatedTime += Time.deltaTime;
            return;
        }
        else
        {
            accumulatedTime = 0.0f;
        }

        missilePool.GetMissile(missileID);
    }
}

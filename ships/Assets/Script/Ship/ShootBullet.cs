using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject[] gunBase;

    public float shootinterval;
    public GameObject bulletManager;
    ShipProperty property;
    float accumulatedTime;

    BulletPool bulletPool;

    int dirIdx;
    private void Awake()
    {
        property = GetComponent<ShipProperty>();
        bulletManager = GameObject.Find("BulletManager");
        bulletPool = bulletManager.GetComponent<BulletPool>();
        dirIdx = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if(property.isPlaying ==false)
        {
            return;
        }

        if (accumulatedTime < shootinterval)
        {
            accumulatedTime += Time.deltaTime;
            return;
        }
        else
        {
            accumulatedTime = 0.0f;
        }

        GameObject bullet = bulletPool.GetBullet(0);
        bullet.transform.position = gunBase[dirIdx].transform.position;
        Vector3 dir = bullet.transform.position - transform.position;

        bullet.GetComponent<BulletProperty>().direction.x = dir.x;

        bullet.GetComponent<BulletProperty>().direction.y = dir.y;

        ++dirIdx;
        dirIdx %= 8;
    }
}

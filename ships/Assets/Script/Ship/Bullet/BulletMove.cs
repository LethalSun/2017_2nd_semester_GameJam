using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    BulletProperty property;
    public Vector3 bulletManagerPos;
    // Use this for initialization
    void Awake()
    {
        bulletManagerPos = GameObject.Find("BulletManager").transform.position; ;
        property = this.GetComponent<BulletProperty>();

    }

    // Update is called once per frame
    void Update()
    {

        if (property.isUsed == false)
        {
            return;
        }

        Vector2 delta = property.bulletSpeed * property.direction * Time.deltaTime;

        this.transform.position += new Vector3(delta.x, delta.y, 0);

        if (this.transform.position.magnitude >= 200)
        {
            property.isUsed = false;
            this.transform.position = bulletManagerPos;
        }
    }
}

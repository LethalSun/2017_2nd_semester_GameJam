using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public Vector3 missileManagerPos;

    GameObject ParticleManager;

    ParticlePool pool;

    MissileProperty missileProperty;

    private void Awake()
    {
        ParticleManager = GameObject.Find("ParticleManager");
        pool = ParticleManager.GetComponent<ParticlePool>();
        missileManagerPos = GameObject.Find("EnemyMissileManager").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 31)
        {
            this.GetComponent<MissileProperty>().isLunched = true;
        }
        else if (collision.gameObject.layer == 30)
        {
            this.GetComponent<MissileProperty>().isLunched = false;
            GameObject effect = pool.GetEParticle(0);



            effect.transform.position = new Vector3((transform.position.x + collision.transform.position.x)/2,
                                                     (transform.position.y + collision.transform.position.y) / 2, -20);
            //effect.transform.parent = this.gameObject.transform;
            effect.SetActive(true);
            this.transform.position = missileManagerPos;
            this.GetComponent<Rigidbody2D>().rotation = 0.0f;
            this.GetComponent<MissileProperty>().isUsed = false;
        }
        else if (collision.gameObject.layer == 28)
        {
            this.GetComponent<MissileProperty>().isLunched = false;
            this.transform.position = missileManagerPos;
           
            this.GetComponent<Rigidbody2D>().rotation = 0.0f;
            this.GetComponent<MissileProperty>().isUsed = false;
        }
    }
}

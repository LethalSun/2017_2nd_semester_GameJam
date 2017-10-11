using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour {

    public Vector3 bulletManagerPos;
    GameObject ParticleManager;
    BulletProperty property;
    ParticlePool pool;

    GameObject player;
    // Use this for initialization
    void Awake ()
    {
        bulletManagerPos = GameObject.Find("BulletManager").transform.position;
        player = GameObject.Find("Player");
        property = this.GetComponent<BulletProperty>();
        ParticleManager = GameObject.Find("ParticleManager");
        pool = ParticleManager.GetComponent<ParticlePool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 29)
        {
            player.GetComponent<ShipProperty>().score += 10;
            Vector3 effectPos = this.transform.position;

            GameObject effect = pool.GetPParticle(0);
            effect.transform.position = new Vector3(effectPos.x,effectPos.y, -20);
            effect.SetActive(true);
            property.isUsed = false;
            this.transform.position = bulletManagerPos;


        }
    }
}

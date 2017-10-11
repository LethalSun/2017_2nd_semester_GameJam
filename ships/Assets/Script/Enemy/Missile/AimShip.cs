using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShip : MonoBehaviour {

    public GameObject player;

    public MissileProperty property;

    Rigidbody2D rb2d;
	// Use this for initialization
	void Awake ()
    {
        player = GameObject.FindWithTag("Player");
        property = this.gameObject.GetComponent<MissileProperty>();
        rb2d = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (property.isLunched == false)
        {
            return;
        }

        var targetPositon = player.transform.position;

        var myPosition = this.transform.position;

        var direction = targetPositon - myPosition;

        direction.z = 0.0f;

        direction.Normalize();

        var moveVelocity = direction * property.missileSpeed;

        transform.position += moveVelocity * Time.deltaTime;

        var rot = Mathf.Atan2(direction.y , direction.x);

        var deg = Mathf.Rad2Deg*rot;

        rb2d.MoveRotation(deg);

    }
}

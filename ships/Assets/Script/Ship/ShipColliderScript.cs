using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipColliderScript : MonoBehaviour {
    ShipProperty shipProperty;
	// Use this for initialization
	void Start ()
    {
        shipProperty = GetComponent<ShipProperty>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 29)
        { 
            shipProperty.shipHp -= collision.GetComponent<MissileProperty>().missileDamage;
        }
    }
}
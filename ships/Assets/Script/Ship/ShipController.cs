using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    Vector3 curPosition;
    Vector3 beforePosition;

    ShipProperty shipProperty;
	// Use this for initialization
	void Start ()
    {
        curPosition = Vector3.zero;

        beforePosition = Vector3.zero;

        shipProperty = GetComponent<ShipProperty>();
    }
	
	// Update is called once per frame
	void Update () {

        //게임플레이가 시작 되었는지 확인하거나, 배 오브젝트를 껏다 켜 준다.
        if(shipProperty.isPlaying == false)
        {
            return;
        }


        if (Input.GetButton("Fire1"))
        {
            Vector3 deltaPos = GetDeltaPos();
            Vector3 pos = this.transform.position;

            this.transform.position = new Vector3(
                Mathf.Clamp(pos.x + deltaPos.x,-25.0f,25.0f),
                Mathf.Clamp(pos.y + deltaPos.y, -45.0f, 45.0f),
                0);
            

        }
        else if(Input.GetButtonUp("Fire1"))
        {
            curPosition = Vector3.zero;

            beforePosition = Vector3.zero;
        }


    }

    Vector3 GetDeltaPos()
    {
        //TODO:멀티 터치 대응은?? -> 무시하고 충돌체를 잘배치해서 해결한다. 혹은 플랫폼에 따라서 다르게 구현한다.

        Vector3 pos = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(90);

        curPosition = pos;

        Vector3 delta = curPosition - beforePosition;

        beforePosition = curPosition;

        return delta;
    }
}

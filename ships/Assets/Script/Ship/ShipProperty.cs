using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipProperty : MonoBehaviour {
    public float maxShipHp;

    public float shipHp;

    public Slider slider;
    public Text hpText;
    public int score;

    public bool isPlaying;

    void Start()
    {
        ResetProperty();
    }

    private void OnEnable()
    {
        ResetProperty();
    }

    public bool ResetProperty()
    {
        score = 0;
        shipHp = maxShipHp;
        transform.position = new Vector3(0.0f, 0.0f, transform.position.z);
        isPlaying = false;
        return true;
    }

    public void StartPlaying()
    {
        isPlaying = true;
    }

    private void Update()
    {
        slider.value = shipHp / maxShipHp;
        hpText.text = "HP" + shipHp + "/" + maxShipHp;
    }

}

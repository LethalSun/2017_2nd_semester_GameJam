using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppManager : MonoBehaviour {

    public Canvas idleCanvas;

    public Canvas playCanvas;

    public Text score;

    public Text scorePlay;

    public Text highScore;

    public int bestScore;

    public GameObject player;

    ShipProperty shipProperty;

    public GameObject enemy;

    public GameObject particle;

    public GameObject bullet;

    private void Awake()
    {
        Screen.SetResolution(576 , 1024, false);
        //Camera.main.transform.position = new Vector3(0.0f,0.0f,0.0f);
    }

    void Start ()
    {
        shipProperty = player.GetComponent<ShipProperty>();
        idleCanvas.gameObject.SetActive(true);
        LoadBestScore();
        highScore.text = "Best Score:" + bestScore;

        playCanvas.gameObject.SetActive(false);
        //player.SetActive(false);
        enemy.SetActive(false);
        particle.SetActive(false);
        bullet.SetActive(false);

        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(player.activeInHierarchy == false )
        {
            return;
        }

        scorePlay.text ="Score:"+ shipProperty.score;

        if(shipProperty.shipHp <0)
        {
            if(shipProperty.score >bestScore)
            {
                bestScore = shipProperty.score;
                SetBestScore();
            }

            OnGameReset();
        }

    }

    void OnGameReset()
    {
        idleCanvas.gameObject.SetActive(true);
        score.text = scorePlay.text;
        highScore.text = "Best Score:" + bestScore;
        playCanvas.gameObject.SetActive(false);
        player.GetComponent<ShipProperty>().ResetProperty();
        enemy.SetActive(false);
        particle.SetActive(false);
        bullet.SetActive(false);
    }

    public void OnGameStartButtonPushed()
    {
        idleCanvas.gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
        player.GetComponent<ShipProperty>().StartPlaying();
        enemy.SetActive(true);
        particle.SetActive(true);
        bullet.SetActive(true);
    }

    void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void SetBestScore()
    {
        Debug.Log("BestScore Set to"+ bestScore);
        PlayerPrefs.SetInt("BestScore", bestScore);
    }
}

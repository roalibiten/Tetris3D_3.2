using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOver : MonoBehaviour
{
    public GameObject objectCreator;
    public GameObject GameOverAnim;
    public Animator myAnimator;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI CoinPusherText;

    public static GameObject[] gameOverObjects;
    public static GameObject[] gameObject1;
    int i ;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GameOverAnim.GetComponent<Animator>();
        //Debug.Log(myAnimator);
        Time.timeScale = 1;
        gameOverObjects = GameObject.FindGameObjectsWithTag("gameOver");
        gameObject1 = GameObject.FindGameObjectsWithTag("gameMenu");
        foreach(GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }

        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.SetText("High Score:" + PlayerPrefs.GetInt("highScore"));

        int score = objectCreator.GetComponent<ObjectCreator>().score;
        
            scoreText.SetText("Score:" + score);
        
       
        

           

    }
    public void showGameOver()
    {
        coinPusher();
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            MainCamera.GetComponent<AudioSource>().Stop();
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/GameOver");
            transform.GetComponent<AudioSource>().Play();
        }
        if (Time.timeScale == 1)
        {
            //Debug.Log(gameOverObjects.Length);

            //Time.timeScale = 0;
            foreach (GameObject g in gameOverObjects)
            {
                g.SetActive(true);
               

            }
            foreach (GameObject g in gameObject1)
            {
                g.SetActive(false);
            }


        }
        myAnimator.Play("GameOver");

    }
    public void restartGame()
    {

        SceneManager.LoadScene("1");
        Physics.gravity = new Vector3(0, -9.81F, 0);
    }
    public void goMM()
    {
        SceneManager.LoadScene("0");
    }
    public void coinPusher()
    {
        int a = Convert.ToInt32(Mathf.Floor(objectCreator.GetComponent<ObjectCreator>().coin));

        PlayerPrefs.SetInt("CoinCount",PlayerPrefs.GetInt("CoinCount")+(a*1));
        CoinPusherText.SetText("+"+a);

    }
}

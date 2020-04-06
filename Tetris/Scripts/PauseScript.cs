using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject GameOver;
    public static GameObject[] myObject ;

    public static GameObject[] gameObject2;

    //public static GameObject[] gameobjectJoker;

    public GameObject jokerbutton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        myObject = GameObject.FindGameObjectsWithTag("pauseMenu");
        gameObject2 = GameObject.FindGameObjectsWithTag("gameMenu");
        //gameobjectJoker = GameObject.FindGameObjectsWithTag("jokerMenu");
        hidePause();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PlayerPrefs.GetInt("Effects") == 0)
            {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
                transform.GetComponent<AudioSource>().Play();
            }
            if (Time.timeScale==1)
            {
                Time.timeScale = 0;
                showPause();
            }else if (Time.timeScale==0)
            {
                Time.timeScale = 1;
                hidePause();
            }
        }
    }
    public  void hidePause()
    {
        
        foreach (GameObject g in myObject )
        {
            g.SetActive(false);
            
        }
        foreach (GameObject g in gameObject2)
        {
            g.SetActive(true);
        }
        //foreach (GameObject z in gameobjectJoker)
        //{
        //    z.SetActive(true);
        //}
        //jokerbutton.gameObject.active = true;
        jokerbutton.gameObject.SetActive(true);
    }
    public  void showPause()
    {
       // Debug.Log(myObject.Length);
        foreach(GameObject g in myObject)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in gameObject2)
        {
            g.SetActive(false);
        }
        //foreach (GameObject z in gameobjectJoker)
        //{
        //    z.SetActive(false);
        //}
        jokerbutton.gameObject.SetActive(false);
        
    }
    public  void goMM()
    {
        Time.timeScale = 1;
        GameOver.GetComponent<GameOver>().goMM();
        //if (PlayerPrefs.GetInt("Effects") == 0)
        //{
        //    transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
        //    transform.GetComponent<AudioSource>().Play();
        //}
        //SceneManager.LoadScene("0");
    }
    public  void continueGame()
    {
        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
            transform.GetComponent<AudioSource>().Play();
        }
        //Debug.Log("Continue");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPause();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePause();
        }
    }
    public  void restartGame()
    {
        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
            transform.GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("1");
        Physics.gravity = new Vector3(0, -9.81F, 0);
    }
 
}

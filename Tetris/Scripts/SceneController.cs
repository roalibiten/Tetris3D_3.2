using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    public GameObject turkish;
    public GameObject english;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScoreTurkish;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            coinText.SetText(PlayerPrefs.GetInt("CoinCount").ToString());
            highScore.SetText("High Score: " + PlayerPrefs.GetInt("highScore"));
            highScoreTurkish.SetText("En Yüksek Puan: " + PlayerPrefs.GetInt("highScore"));
        }

        //if (PlayerPrefs.GetString("Language") == "English")
        //{
        //    turkish.SetActive(false);
        //    english.SetActive(true);

        //}
        //else if (PlayerPrefs.GetString("Language") == "Turkish")
        //{
        //    turkish.SetActive(true);
        //    english.SetActive(false);
        //}

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        //Debug.Log(PlayerPrefs.GetInt("GameMusic"));

        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
            transform.GetComponent<AudioSource>().Play();
        }
        
        SceneManager.LoadScene("1");
        Physics.gravity =  new Vector3(0, -9.81F, 0);
    }
    public void MainMenu()
    {
        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/click");
            transform.GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("0");
    }
    public void goMM()
    {
        SceneManager.LoadScene("0");
    }
    public void goCubeShop()
    {
        SceneManager.LoadScene("3");
    }
    public void goOptionsM()
    {
        SceneManager.LoadScene("2");
    }
  
    public void changeGameMusic()
    {
        if (PlayerPrefs.GetInt("GameMusic") == 0)
        {
            PlayerPrefs.SetInt("GameMusic", 1);
           // Debug.Log(PlayerPrefs.GetInt("GameMusic"));
        }
        else if (PlayerPrefs.GetInt("GameMusic") == 1)
        {
            PlayerPrefs.SetInt("GameMusic", 0);
            //Debug.Log(PlayerPrefs.GetInt("GameMusic"));
        }

    }

    public void changeEffectsOn()
    {
        if (PlayerPrefs.GetInt("Effects") == 0)
        {
            PlayerPrefs.SetInt("Effects", 1);
           // Debug.Log(PlayerPrefs.GetInt("Effects"));
        }
        else if (PlayerPrefs.GetInt("Effects") == 1)
        {
            PlayerPrefs.SetInt("Effects", 0);
            //Debug.Log(PlayerPrefs.GetInt("Effects"));
        }
      
    }
    public void beEnglish()
    {
        PlayerPrefs.SetString("Language", "English");
       // Debug.Log(PlayerPrefs.GetString("Language"));
        turkish.SetActive(false);
        english.SetActive(true);
        
    }
    public void beTurkish()
    {
        PlayerPrefs.SetString("Language", "Turkish");
        //Debug.Log(PlayerPrefs.GetString("Language"));
        turkish.SetActive(true);
        english.SetActive(false);


    }
    public void goTutorial()
    {
        SceneManager.LoadScene("4");
    }
}

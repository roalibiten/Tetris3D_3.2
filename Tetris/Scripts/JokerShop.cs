using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class JokerShop : MonoBehaviour
{
    public Color cubeColor = new Color32(255, 149, 0, 255);
    public GameObject OneCubeJokerCountShow;
    public GameObject RowJokerCountShow;
    public GameObject SideJokerCountShow;


    public TextMeshProUGUI coinCount;
    // Start is called before the first frame update
    void Start()
    {
       
        //PlayerPrefs.SetInt("CoinCount", 100000);
        //PlayerPrefs.SetInt("OneCubeJokerCount",1);
        //PlayerPrefs.SetInt("SideJokerCount", 1);
        //PlayerPrefs.SetInt("RowJokerCount", 1);
        coinCount.SetText(PlayerPrefs.GetInt("CoinCount").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.SetText(PlayerPrefs.GetInt("CoinCount").ToString());
        if (PlayerPrefs.GetInt("OneCubeJokerCount") == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                OneCubeJokerCountShow.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }else if (PlayerPrefs.GetInt("OneCubeJokerCount") == 1)
        {
           
                OneCubeJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            OneCubeJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.white;

            OneCubeJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;

            
        }
        else if (PlayerPrefs.GetInt("OneCubeJokerCount") == 2)
        {

            OneCubeJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            OneCubeJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            OneCubeJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;

        }
        else if (PlayerPrefs.GetInt("OneCubeJokerCount") == 3)
        {

            OneCubeJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            OneCubeJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            OneCubeJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = cubeColor;

        }

        if (PlayerPrefs.GetInt("RowJokerCount") == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                RowJokerCountShow.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        else if (PlayerPrefs.GetInt("RowJokerCount") == 1)
        {

            RowJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            RowJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.white;

            RowJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;


        }
        else if (PlayerPrefs.GetInt("RowJokerCount") == 2)
        {

            RowJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            RowJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            RowJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;

        }
        else if (PlayerPrefs.GetInt("RowJokerCount") == 3)
        {

            RowJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            RowJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            RowJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = cubeColor;

        }

        if (PlayerPrefs.GetInt("SideJokerCount") == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                SideJokerCountShow.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        else if (PlayerPrefs.GetInt("SideJokerCount") == 1)
        {

            SideJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            SideJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.white;

            SideJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;


        }
        else if (PlayerPrefs.GetInt("SideJokerCount") == 2)
        {

            SideJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            SideJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            SideJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.white;

        }
        else if (PlayerPrefs.GetInt("SideJokerCount") == 3)
        {
            
            SideJokerCountShow.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = cubeColor;
            SideJokerCountShow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = cubeColor;

            SideJokerCountShow.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = cubeColor;

        }

    }
    public void BuyOneCubeJoker()
    {
        //Debug.Log("fonk cagridli");
        if (PlayerPrefs.GetInt("CoinCount") >= 100)
        {
            //Debug.Log("para yeterli");

            if (PlayerPrefs.GetInt("OneCubeJokerCount") < 3)
            {
                //Debug.Log("joker alınıyooo");


                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount")-100);
            PlayerPrefs.SetInt("OneCubeJokerCount", PlayerPrefs.GetInt("OneCubeJokerCount") + 1);
            }
        }
        //Debug.Log(PlayerPrefs.GetInt("OneCubeJokerCount") +"----------"+ PlayerPrefs.GetInt("CoinCount"));
    }
    public void BuyRowJoker()
    {
       // Debug.Log("fonk cagridli");
        if (PlayerPrefs.GetInt("CoinCount") >= 1000)
        {
           // Debug.Log("para yeterli");

            if (PlayerPrefs.GetInt("RowJokerCount") < 3)
            {
                //Debug.Log("joker alınıyooo");


                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - 1000);
                PlayerPrefs.SetInt("RowJokerCount", PlayerPrefs.GetInt("RowJokerCount") + 1);
            }
        }
        //Debug.Log(PlayerPrefs.GetInt("RowJokerCount") + "----------" + PlayerPrefs.GetInt("CoinCount"));
    }
    public void BuySideJoker()
    {
        //Debug.Log("fonk cagridli");
        if (PlayerPrefs.GetInt("CoinCount") >= 10000)
        {
            //Debug.Log("para yeterli");

            if (PlayerPrefs.GetInt("SideJokerCount") < 3)
            {
                //Debug.Log("joker alınıyooo");


                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - 10000);
                PlayerPrefs.SetInt("SideJokerCount", PlayerPrefs.GetInt("SideJokerCount") + 1);
            }
        }
        //Debug.Log(PlayerPrefs.GetInt("SideJokerCount") + "----------" + PlayerPrefs.GetInt("CoinCount"));
    }
    public void WatchAdFor100()
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") +100);
    }
}

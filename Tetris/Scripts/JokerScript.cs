using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Net;
using UnityEngine.Networking;
using System;

public class JokerScript : MonoBehaviour
{
    public GameObject Cuber;
    public bool rowExplode = false;
    public bool frontSideExplode = false;
    public int swipeController = 1;
    public int openPanelTrigger;
    public GameObject Cube;
    public GameObject objectCreator;
    public static GameObject[] jokerMenuItems;
    public static GameObject[] gameMenuItems;
    int getPosition = 0;
    float mousex;
    float mousey;
    float mousez;

    float xMatris;
    float yMatris;

    public GameObject plane;

    int stp;
    int OneCubeJokerCount;
    int RowJokerCount;

    int FrontSideJokerCount;

    public GameObject kure1;
    public GameObject kure2;
    public GameObject kure3;

    public GameObject kure4;
    public GameObject kure5;
    public GameObject kure6;

    public GameObject kure7;
    public GameObject kure8;
    public GameObject kure9;


    public Color32 cubeColor;
    public bool jokerBool = false;

    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        

        openPanelTrigger = 0;
        jokerMenuItems = GameObject.FindGameObjectsWithTag("JokerMenu");
        gameMenuItems = GameObject.FindGameObjectsWithTag("gameMenu");
        foreach (GameObject g in jokerMenuItems)
        {
            g.SetActive(false);

        }
       // StartCoroutine(GetInternetTime());


        plane = GameObject.FindGameObjectWithTag("plane");

        stp = 0;
        OneCubeJokerCount = PlayerPrefs.GetInt("OneCubeJokerCount");
        RowJokerCount = PlayerPrefs.GetInt("RowJokerCount");
        FrontSideJokerCount = PlayerPrefs.GetInt("FrontSideJokerCount");

        cubeColor = new Color32(255, 149, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        OneCubeJokerCount = PlayerPrefs.GetInt("OneCubeJokerCount");
        RowJokerCount = PlayerPrefs.GetInt("RowJokerCount");
        FrontSideJokerCount = PlayerPrefs.GetInt("SideJokerCount");

        float planeRotation = plane.transform.eulerAngles.y;
        if ((openPanelTrigger == 1) && ((planeRotation > 89 && planeRotation < 91) || (planeRotation > 179 && planeRotation < 181) || (planeRotation > 269 && planeRotation < 271) || (planeRotation > -1 && planeRotation < 1)))
        {
            swipeController = 0;

            foreach (GameObject g in jokerMenuItems)
            {
                g.SetActive(true);
                Time.timeScale = 0;
            }
            openPanelTrigger = 0;

        }


        if (OneCubeJokerCount == 3)
        {

            kure3.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure2.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure1.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
        }
        if (OneCubeJokerCount == 2)
        {

            kure3.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure2.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (OneCubeJokerCount == 1)
        {

            kure3.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (OneCubeJokerCount == 0)
        {

            kure3.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }

        if (RowJokerCount == 3)
        {

            kure6.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure5.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure4.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
        }
        if (RowJokerCount == 2)
        {

            kure6.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure5.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure4.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (RowJokerCount == 1)
        {

            kure6.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure5.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure4.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (RowJokerCount == 0)
        {

            kure6.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure5.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure4.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }


        if (FrontSideJokerCount == 3)
        {

            kure9.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure8.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure7.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
        }
        if (FrontSideJokerCount == 2)
        {

            kure9.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure8.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure7.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (FrontSideJokerCount == 1)
        {

            kure9.GetComponent<MeshRenderer>().material.SetColor("_Color", cubeColor);
            kure8.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure7.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
        if (FrontSideJokerCount == 0)
        {

            kure9.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure8.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            kure7.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }


        if (OneCubeJokerCount > 0)
        {

            if (jokerBool == true)
            {
                Destroy(objectCreator.GetComponent<ObjectCreator>().ghostObject.gameObject);







                if (Input.GetMouseButtonDown(0) && getPosition == 1 /*&& ((plane.transform.rotation.y>89 && plane.transform.rotation.y < 91 )|| (plane.transform.rotation.y > 179 && plane.transform.rotation.y < 181) || (plane.transform.rotation.y > -91 && plane.transform.rotation.y < -89) || (plane.transform.rotation.y > -1 && plane.transform.rotation.y < 1))*/)
                {
                    Vector3 mousedata = Input.mousePosition;
                    mousex = Input.mousePosition.x;
                    mousey = Input.mousePosition.y;
                    mousez = Input.mousePosition.z;
                    Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousex, mousey));
                    if (Physics.Raycast(ray))
                    {

                        //float desiredValueForZ = 0; //this depends on your project stuff, I don't know.
                        Vector3 localPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, +23.5f));


                        GameObject Cuber = Instantiate(Cube.gameObject, localPosition, Quaternion.identity);
                        Cuber.transform.SetParent(plane.transform);

                        this.Cuber = Cuber;

                        //eklenen
                        for (int l = -5; l < 5; l++)
                        {
                            if (Cuber.transform.position.x > l && Cuber.transform.position.x < l + 1)
                            {
                                float a = l + 0.5f;
                                Cuber.transform.position = new Vector3(a, Cuber.transform.position.y, Cuber.transform.position.z);
                                
                                
                            }


                        }
                        if (Cuber.transform.position.x > -6 && Cuber.transform.position.x < -5)
                        {
                            Cuber.transform.position = new Vector3(-4.5f, Cuber.transform.position.y, Cuber.transform.position.z);
                        }
                        else if (Cuber.transform.position.x > 5 && Cuber.transform.position.x < 6)
                        {
                            Cuber.transform.position = new Vector3(4.5f, Cuber.transform.position.y, Cuber.transform.position.z);
                        }

                        for (int l = 0; l < 20; l++)
                        {
                            if (Cuber.transform.position.y > l && Cuber.transform.position.y < l + 1)
                            {
                                float a = l + 0.5f;
                                Cuber.transform.position = new Vector3(Cuber.transform.position.x, a, Cuber.transform.position.z);
                            }
                            if (Cuber.transform.position.y > -1 && Cuber.transform.position.y < 0)
                            {
                                Cuber.transform.position = new Vector3(Cuber.transform.position.x, 0.5f, Cuber.transform.position.z);

                               
                            }
                            else if (Cuber.transform.position.y > 19)
                            {
                                Destroy(Cuber.gameObject);
                            }

                            //eklenen
                        }
                        float x = Cuber.transform.position.x;
                        int xRounded = (int)Math.Ceiling(x);
                        float y = Cuber.transform.position.y;
                        int yRounded = (int)Math.Ceiling(y);
                        xRounded = xRounded + 5;

                        int connectX = 20 - yRounded;
                        int connectY = xRounded - 1;
                        //Debug.Log(Cuber.transform.position);
                        //Debug.Log(connectX + "     " + connectY);
                        int yuz = objectCreator.GetComponent<ObjectCreator>().control;
                        if (objectCreator.GetComponent<ObjectCreator>().jokerIsFull(yuz, connectX, connectY) == false)
                        {
                            //Debug.Log(connectX + "---------" + connectY);
                            if (connectX == 19)
                            {
                                objectCreator.GetComponent<ObjectCreator>().fill(yuz, connectX, connectY, Cuber);
                                objectCreator.GetComponent<ObjectCreator>().objectList.Add(Cuber.gameObject);
                                objectCreator.GetComponent<ObjectCreator>().blowControl(connectX);
                                makeOneColor(yRounded);
                               // Debug.LogWarning(20-yRounded);
                                objectCreator.GetComponent<ObjectCreator>().myObject.GetComponent<Rigidbody>().useGravity = true;
                                objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().drag = 5;
                                objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().useGravity = true;
                                objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ;
                                objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().freezeRotation = true;
                                objectCreator.GetComponent<ObjectCreator>().score = objectCreator.GetComponent<ObjectCreator>().score + 40;
                                objectCreator.GetComponent<ObjectCreator>().scoreText.SetText("Score: " + objectCreator.GetComponent<ObjectCreator>().score);
                               // Debug.Log("JOKERERERERERR" + yuz);
                               
                                PlayerPrefs.SetInt("OneCubeJokerCount", PlayerPrefs.GetInt("OneCubeJokerCount")-1);

                                stp++;
                            }
                            else if (objectCreator.GetComponent<ObjectCreator>().jokerIsFull(yuz, connectX + 1, connectY) == true)
                            {
                                objectCreator.GetComponent<ObjectCreator>().objectList.Add(Cuber.gameObject);
                               // Debug.Log((connectX + 1) + "-----" + connectY + "dolu");
                                objectCreator.GetComponent<ObjectCreator>().fill(yuz, connectX, connectY, Cuber);
                               // Debug.Log("JOKERERERERERR" + yuz);
                                PlayerPrefs.SetInt("OneCubeJokerCount", PlayerPrefs.GetInt("OneCubeJokerCount") - 1);
                                objectCreator.GetComponent<ObjectCreator>().score = objectCreator.GetComponent<ObjectCreator>().score + 40;
                                objectCreator.GetComponent<ObjectCreator>().scoreText.SetText("Score: " + objectCreator.GetComponent<ObjectCreator>().score);

                                stp++;
                            }
                            else
                            {
                                
                                   
                                
                                Destroy(Cuber.gameObject);
                            }
                        }
                        else
                        {
                               
                            
                            Destroy(Cuber.gameObject);
                        }
                    }
                    Time.timeScale = 1;
                    jokerBool = false;
                    foreach (GameObject g in gameMenuItems)
                    {
                        g.SetActive(true);
                    }
                    swipeController = 1;
                    pauseButton.SetActive(true); 
                }
            }
        }

        if (RowJokerCount > 0)
        {


        if (rowExplode == true)
        {
                Destroy(objectCreator.GetComponent<ObjectCreator>().ghostObject.gameObject);
                if (Input.GetMouseButtonDown(0) && getPosition == 1 /*&& ((plane.transform.rotation.y>89 && plane.transform.rotation.y < 91 )|| (plane.transform.rotation.y > 179 && plane.transform.rotation.y < 181) || (plane.transform.rotation.y > -91 && plane.transform.rotation.y < -89) || (plane.transform.rotation.y > -1 && plane.transform.rotation.y < 1))*/)
            {
                Vector3 mousedata = Input.mousePosition;
                mousex = Input.mousePosition.x;
                mousey = Input.mousePosition.y;
                mousez = Input.mousePosition.z;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousex, mousey));
                if (Physics.Raycast(ray))
                {

                    //float desiredValueForZ = 0; //this depends on your project stuff, I don't know.
                    Vector3 localPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, +23.5f));
                    int a = (int)Math.Ceiling(localPosition.y);
                   // Debug.LogWarning(a);
                    bool notEmpty = false;
                    for (int k=0;k<9;k++)
                    {
                        if (objectCreator.GetComponent<ObjectCreator>().side1[20 - a, k].isFull == true || objectCreator.GetComponent<ObjectCreator>().side2[20 - a, k].isFull == true || objectCreator.GetComponent<ObjectCreator>().side3[20 - a, k].isFull == true || objectCreator.GetComponent<ObjectCreator>().side4[20 - a, k].isFull == true)
                        {
                            notEmpty = true;
                        }

                    }

                    if (notEmpty == true)
                    {
                        
                        int childC=objectCreator.GetComponent<ObjectCreator>().LoopDestroyer(a);
                            objectCreator.GetComponent<ObjectCreator>().score = objectCreator.GetComponent<ObjectCreator>().score + (childC*30);
                            objectCreator.GetComponent<ObjectCreator>().scoreText.SetText("Score: " + objectCreator.GetComponent<ObjectCreator>().score);
                            objectCreator.GetComponent<ObjectCreator>().downgrade(20 - a);
                        objectCreator.GetComponent<ObjectCreator>().downgradeView(a, 1);
                            objectCreator.GetComponent<ObjectCreator>().myObject.transform.position = objectCreator.GetComponent<ObjectCreator>().myObject.transform.position+ new Vector3(0,1,0);
                        Time.timeScale = 1;
                        objectCreator.GetComponent<ObjectCreator>().myObject.GetComponent<Rigidbody>().useGravity = true;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().drag = 5;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().useGravity = true;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().freezeRotation = true;
                        rowExplode = false;
                        foreach (GameObject g in gameMenuItems)
                        {
                            g.SetActive(true);
                        }
                        swipeController = 1;
                        pauseButton.SetActive(true);
                            PlayerPrefs.SetInt("RowJokerCount", PlayerPrefs.GetInt("RowJokerCount") - 1);


                        }
                        else
                    {
                        Time.timeScale = 1;

                        objectCreator.GetComponent<ObjectCreator>().myObject.GetComponent<Rigidbody>().useGravity = true;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().drag = 5;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().useGravity = true;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ;
                        objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().freezeRotation = true;
                        rowExplode = false;
                        rowExplode = false;
                        foreach (GameObject g in gameMenuItems)
                        {
                            g.SetActive(true);
                        }
                        swipeController = 1;
                        pauseButton.SetActive(true);
                            PlayerPrefs.SetInt("RowJokerCount", PlayerPrefs.GetInt("RowJokerCount") - 1);


                        }


                    }

            }
        }

        }
        if (FrontSideJokerCount > 0)
        {


            if (frontSideExplode == true)
        {
                Time.timeScale = 0;
                Destroy(objectCreator.GetComponent<ObjectCreator>().ghostObject.gameObject);

                int childC =objectCreator.GetComponent<ObjectCreator>().SideDestroyer();
                objectCreator.GetComponent<ObjectCreator>().score = objectCreator.GetComponent<ObjectCreator>().score + (childC*30);
                objectCreator.GetComponent<ObjectCreator>().scoreText.SetText("Score: " + objectCreator.GetComponent<ObjectCreator>().score);
            objectCreator.GetComponent<ObjectCreator>().myObject.GetComponent<Rigidbody>().useGravity = true;
            objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().drag = 5;
            objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().useGravity = true;
            objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ;
            objectCreator.GetComponent<ObjectCreator>().myObject.transform.GetComponent<Rigidbody>().freezeRotation = true;
            rowExplode = false;
            foreach (GameObject g in gameMenuItems)
            {
                g.SetActive(true);
            }
            swipeController = 1;
            frontSideExplode = false;
            pauseButton.SetActive(true);
                PlayerPrefs.SetInt("SideJokerCount", PlayerPrefs.GetInt("SideJokerCount") - 1);

                Time.timeScale = 1;

            }

        }
    }

    public void openPanel()
    {

        if (jokerMenuItems[0].activeSelf == false)
        {
            //foreach (GameObject g in jokerMenuItems)
            //{
            //    g.SetActive(true);
            //    Time.timeScale = 0;
            //}
            openPanelTrigger = 1;
            foreach (GameObject z in gameMenuItems)
            {
                z.SetActive(false);
            }
            pauseButton.gameObject.SetActive(false);
        }
        else
        {
            swipeController = 1;
            foreach (GameObject g in jokerMenuItems)
            {
                g.SetActive(false);
                Time.timeScale = 1;
            }
            foreach (GameObject z in gameMenuItems)
            {
                z.SetActive(true);
            }
            pauseButton.gameObject.SetActive(true);
        }

    }
    public void oneCubeJoker()
    {
        if (OneCubeJokerCount > 0)
        {


            closeButtons();

            foreach (GameObject g in jokerMenuItems)
            {
                g.SetActive(false);
            }
            //Debug.Log("bekleniyor");
            getPosition = 1;
            jokerBool = true;
        }
        else if (OneCubeJokerCount == 0)
        {
            //Debug.LogWarning("Joker hakkı kalmadı reklam izle");
        }

    }
    public void closeButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("gameMenu");
        foreach (GameObject g in buttons)
        {
            g.SetActive(false);
        }
    }

    //public IEnumerator GetInternetTime()
    //{
    //    UnityWebRequest myHttpWebRequest = UnityWebRequest.Get("http://worldtimeapi.org/api/ip");
    //    Debug.Log(myHttpWebRequest);
    //    Debug.Log(myHttpWebRequest.ToString());
    //    yield return myHttpWebRequest.Send();
    //    string netTime = myHttpWebRequest.GetResponseHeader("date");
    //    Debug.Log(netTime + " was response");

    //    string[] saatbakalim = netTime.Split();
    //    Debug.Log(saatbakalim[4]);
    //}

    public void RowExplode()
    {
        if (RowJokerCount > 0)
        {

       
       // Debug.LogWarning("Row Explode");

        closeButtons();

        foreach (GameObject g in jokerMenuItems)
        {
            g.SetActive(false);
        }
      //  Debug.Log("bekleniyor");
        getPosition = 1;
        rowExplode = true;
        }


    }
    public void FrontSideExplode()
    {
        if (FrontSideJokerCount > 0)
        {

        
       // Debug.LogWarning("Side Explode");

        closeButtons();

        foreach (GameObject g in jokerMenuItems)
        {
            g.SetActive(false);
        }
       // Debug.Log("bekleniyor");
        getPosition = 1;
        frontSideExplode = true;

        }
    }
    void makeOneColor(int x)
    {

        int renkSayaci1 = 0;
        int renkSayaci2 = 0;
        int renkSayaci3 = 0;
        int renkSayaci4 = 0;
        //GameObject colorChanged = new GameObject();

        for (int i = 0; i < 10; i++)
        {
            if (objectCreator.GetComponent<ObjectCreator>().side1[x, i].isFull == true)
            {
                renkSayaci1++;
            }
            if (objectCreator.GetComponent<ObjectCreator>().side2[x, i].isFull == true)
            {
                renkSayaci2++;
            }
            if (objectCreator.GetComponent<ObjectCreator>().side3[x, i].isFull == true)
            {
                renkSayaci3++;
            }
            if (objectCreator.GetComponent<ObjectCreator>().side4[x, i].isFull == true)
            {
                renkSayaci4++;
            }

            if (renkSayaci1 == 10)
            {
                objectCreator.GetComponent<ObjectCreator>().colorList.Add(Cuber);
                objectCreator.GetComponent<ObjectCreator>().colorChanging = true;
                renkSayaci1 = 0;

            }
            if (renkSayaci2 == 10)
            {
                objectCreator.GetComponent<ObjectCreator>().colorList2.Add(Cuber);
                objectCreator.GetComponent<ObjectCreator>().colorChanging2 = true;
                renkSayaci2 = 0;
            }
            if (renkSayaci3 == 10)
            {
                
                    objectCreator.GetComponent<ObjectCreator>().colorList3.Add(Cuber);
                
                objectCreator.GetComponent<ObjectCreator>().colorChanging3 = true;
                renkSayaci3 = 0;
            }
            if (renkSayaci4 == 10)
            {
                objectCreator.GetComponent<ObjectCreator>().colorList4.Add(Cuber);
                objectCreator.GetComponent<ObjectCreator>().colorChanging4 = true;
                renkSayaci4 = 0;
            }


        }
    }
}
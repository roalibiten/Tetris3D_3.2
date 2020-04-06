using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ObjectCreator : MonoBehaviour
{
    public int coin;
    public GameObject pauseButton;
    public GameObject jokerButton;

    GameObject[] GameMenuItems;
    bool watchAccept = false;
    public GameObject watchAddMenu;

    public GameObject ghostObject;
    int gameOverCheck = 0;
    public GameObject myCamera;
    Animator cameraAnimator;
    public int globalRowCounter = 0;
    public SwipeScript swipeControls;
    private bool rotating = false;
    private bool rotateLot = false;
    public float rotdegree;

    int stp = 0;
    bool isDown;

    int sayBakalim = 0;


    //float time = 0f;
    int loop = 0;
    int gravityController = 200;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    int highScore;
    public Cube[,] side1 = new Cube[20, 10];       // creating the arrays with cubes
    public Cube[,] side2 = new Cube[20, 10];
    public Cube[,] side3 = new Cube[20, 10];
    public Cube[,] side4 = new Cube[20, 10];
    public int control = 1;
    public GameObject plane;
    public GameObject L1Object;
    public GameObject L2Object;
    public GameObject SquareObject;
    public GameObject TObject;
    public GameObject IObject;
    public GameObject Z1Object;
    public GameObject Z2Object;
    public GameObject myObject;
    public static int objectType;
    public static int oldType;
    //bool objectIsStopped = false;
    public List<GameObject> objectList = new List<GameObject>();
    public int effectCounter = 0;
    public int hiz = 10;
    public int degree = 90;
    public int revdegree = -90;
    public bool destroy = false;
    // Start is called before the first frame update

    public KeyCode myKey1;
    public KeyCode myKey2;

    public float cubeSize = 0.1f;
    public float cubesInRow = 1;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 500f;
    public float explosionRadius = 10;
    public float explosionUpward = 0.2f;


    int[] rdmarray = new int[3];

    public GameObject gorsel_1;
    public GameObject gorsel_2;
    public List<GameObject> downEffect = new List<GameObject>();
    public int[] effectList = new int[10];

    public bool colorChanging;
    public bool colorChanging2;
    public bool colorChanging3;
    public bool colorChanging4;

    //Color32 Red1 = new Color32(227, 77, 42, 170);

    Color colorStart = new Color32(236, 86, 42, 250);
    Color colorEnd = new Color32(236, 172, 42, 250);
    float duration = 1.0f;
    public List<GameObject> colorList = new List<GameObject>();
    public List<GameObject> colorList2 = new List<GameObject>();
    public List<GameObject> colorList3 = new List<GameObject>();
    public List<GameObject> colorList4 = new List<GameObject>();

    public List<int> new_List = new List<int>();

    public ParticleSystem EfektoTouch;

    public GameObject Wall;

    void Start()
    {


        GameMenuItems = GameObject.FindGameObjectsWithTag("gameMenu");

        cameraAnimator = myCamera.gameObject.GetComponent<Animator>();

        colorList.Clear();
        colorList2.Clear();
        colorList3.Clear();
        colorList4.Clear();

        colorChanging = true;
        colorChanging2 = true;
        colorChanging3 = true;
        colorChanging4 = true;

        if (PlayerPrefs.GetInt("GameMusic") == 1)
        {
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.transform.GetComponent<AudioSource>().Play();
        }


        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

        highScore = PlayerPrefs.GetInt("highScore");
        scoreText.SetText("Score: " + score);



        fillArrays(side1);      // filling the arrays
        fillArrays(side2);
        fillArrays(side3);
        fillArrays(side4);

        Console.WriteLine(side1[0, 1].isFull);



        //Debug.Log("Su anki yuz: " + control);
        //objectType = UnityEngine.Random.Range(0, 8);
        //objectType = 3;

        fillArray();


        objectType = rdmarray[2];
        oldType = objectType;
        gorselfonk(rdmarray[1], rdmarray[0]);
        if (objectType == 1)
        {
            myObject = Instantiate(L1Object);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);

            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);
            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 2)
        {
            myObject = Instantiate(TObject);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 3)
        {
            myObject = Instantiate(IObject);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 4)
        {
            myObject = Instantiate(Z1Object);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 5)
        {
            myObject = Instantiate(Z2Object);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 6)
        {
            myObject = Instantiate(L2Object);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        else if (objectType == 7)
        {
            myObject = Instantiate(SquareObject);
            objectList.Add(myObject.transform.GetChild(0).gameObject);
            objectList.Add(myObject.transform.GetChild(1).gameObject);
            objectList.Add(myObject.transform.GetChild(2).gameObject);
            objectList.Add(myObject.transform.GetChild(3).gameObject);
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

            oldType = objectType;
            objectType = rdmarrayfonk();

        }
        // else { objectType = rdmarrayfonk(); }
    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);


        Color pieceColor = myObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.GetColor("_Color");



        int[,] kord = new int[4, 2];
        for (int i = 0; i <= myObject.transform.childCount - 1; i++)
        {
            //if (myObject.transform.childCount > i) { 
            if (myObject.transform.GetChild(i).gameObject != null)
            {
                float a = myObject.transform.GetChild(i).position.x;
                int xRounded = (int)Math.Ceiling(a);
                float b = myObject.transform.GetChild(i).position.y;
                int yRounded = (int)Math.Ceiling(b);



                kord[i, 0] = xRounded;
                kord[i, 1] = yRounded;


            }


        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                if (kord[j, 1] > kord[i, 1])
                {
                    int a = kord[i, 1];
                    kord[i, 1] = kord[j, 1];
                    kord[j, 1] = a;
                }

            }
        }
        List<int> upper = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            if (kord[0, 1] == kord[i, 1])
            {
                upper.Add(kord[i, 0]);

            }
        }
        int toplamX = 0;
        for (int i = 0; i < upper.Count; i++)
        {
            toplamX = toplamX + upper[i];
        }
        if (objectType == 4 || objectType == 5)
        {
            if (myObject.transform.rotation.eulerAngles.z > 89 && myObject.transform.rotation.eulerAngles.z < 91)
            {
                if (objectType == 4)
                {
                    float random = UnityEngine.Random.Range(-0.5f, 0.5f);
                    piece.transform.position = new Vector3(toplamX + random, kord[0, 1], myObject.transform.position.z);
                } else if (objectType == 5)
                {
                    float random = UnityEngine.Random.Range(-0.5f, 0.5f);
                    piece.transform.position = new Vector3(toplamX - 1.0f + random, kord[0, 1], myObject.transform.position.z);
                }

            }
            else if (upper.Count == 1)
            {
                float random = UnityEngine.Random.Range(-0.5f, 0.5f);
                piece.transform.position = new Vector3(toplamX - 0.5f + random, kord[0, 1], myObject.transform.position.z);
            }


            else
            {
                float random = UnityEngine.Random.Range(-0.5f, 0.5f);
                piece.transform.position = new Vector3(toplamX / upper.Count + random, kord[0, 1], myObject.transform.position.z);
            }
        }

        else if (objectType == 2 && (myObject.transform.rotation.eulerAngles.z > -2 && myObject.transform.rotation.eulerAngles.z < 2))
        {

            float random = UnityEngine.Random.Range(-0.5f, 0.5f);
            piece.transform.position = new Vector3(toplamX + 0.7f + random, kord[0, 1], myObject.transform.position.z);



        }
        else if (upper.Count == 1)
        {
            float random = UnityEngine.Random.Range(-0.5f, 0.5f);
            piece.transform.position = new Vector3(toplamX - 0.5f + random, kord[0, 1], myObject.transform.position.z);
        }


        else
        {
            float random = UnityEngine.Random.Range(-0.5f, 0.5f);
            piece.transform.position = new Vector3(toplamX / upper.Count + random, kord[0, 1], myObject.transform.position.z);
        }


        //Debug.Log("----------" + kord[0, 1]);

        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.GetComponent<MeshRenderer>().material.SetColor("_Color", pieceColor);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<Rigidbody>().drag = 30;
        //piece.GetComponent<BoxCollider>().enabled = false;
        downEffect.Add(piece);
    }

    public void explode()
    {
        //make object disappear

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                for (int z = 0; z < 1; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position

        Vector3 explosionPos = myObject.transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, myObject.transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void Update()
    {

       // Debug.Log("TİMESCALEEEE " + Time.timeScale);
        if (ghostObject.gameObject != null && Time.timeScale==1 && myObject.gameObject!=null)
        {
            ghostObject.transform.localEulerAngles = myObject.transform.localEulerAngles;
            ghostObject.GetComponent<Rigidbody>().useGravity = false;
            int comfortOfGhost = 0;


            for (int i = 0; i < 4; i++)
            {
                Destroy(ghostObject.GetComponent<MeshCollider>());
                Destroy(ghostObject.transform.GetChild(i).GetComponent<BoxCollider>());
                ghostObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(236, 86, 42, 50));
                ghostObject.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(236, 86, 42, 0));
                ghostObject.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }


            float x = myObject.transform.GetChild(0).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(0).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;
            int connectX0 = 20 - yRounded;
            int connectY0 = xRounded - 1;

            x = myObject.transform.GetChild(1).position.x;
            xRounded = (int)Math.Ceiling(x);
            y = myObject.transform.GetChild(1).position.y;
            yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;
            int connectX1 = 20 - yRounded;
            int connectY1 = xRounded - 1;

            x = myObject.transform.GetChild(2).position.x;
            xRounded = (int)Math.Ceiling(x);
            y = myObject.transform.GetChild(2).position.y;
            yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;
            int connectX2 = 20 - yRounded;
            int connectY2 = xRounded - 1;

            x = myObject.transform.GetChild(3).position.x;
            xRounded = (int)Math.Ceiling(x);
            y = myObject.transform.GetChild(3).position.y;
            yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;
            int connectX3 = 20 - yRounded;
            int connectY3 = xRounded - 1;

            int siralaBakalim = connectX0;
            if (connectX1 > siralaBakalim)
            {
                siralaBakalim = connectX1;
            }
            if (connectX2 > siralaBakalim)
            {
                siralaBakalim = connectX1;
            }
            if (connectX3 > siralaBakalim)
            {
                siralaBakalim = connectX1;
            }


            if (siralaBakalim < 19 && siralaBakalim >= 0 && ((jokerIsFull(control, siralaBakalim + 1, connectY3) == true && connectY3 < 20 && connectY3 > 0) || (jokerIsFull(control, siralaBakalim + 1, connectY2) == true && connectY2 < 20 && connectY2 > 0) || (jokerIsFull(control, siralaBakalim + 1, connectY1) == true && connectY1 < 20 && connectY1 > 0) || (jokerIsFull(control, siralaBakalim + 1, connectY0) == true && connectY0 < 20 && connectY0 > 0)))
            {
                //if (siralaBakalim < 19 && siralaBakalim >= 0) { 
                //    ghostObject.transform.position = new Vector3(myObject.transform.position.x, 20 - siralaBakalim, myObject.transform.position.z);
                //}
                ghostObject.SetActive(false);
            }
            else
            {



                //Debug.Log(siralaBakalim);
                if (siralaBakalim < 19)
                {
                    ghostObject.SetActive(true);
                    //Debug.Log("Konum 2 den büyük");
                    for (int k = siralaBakalim; k < 19; k++)
                    {
                        if (k > 0)
                        {
                            ghostObject.SetActive(true);


                            if (jokerIsFull(control, k + 1, connectY0) == true || jokerIsFull(control, k + 1, connectY1) == true || jokerIsFull(control, k + 1, connectY2) == true || jokerIsFull(control, k + 1, connectY3) == true)
                            {
                                if (k < comfortOfGhost)
                                {
                                    //Debug.Log((k + 1) + "dolu yeri");
                                    comfortOfGhost = k;
                                    break;
                                }




                            }
                            else
                            {
                                //Debug.Log("FUL BOŞ");
                                comfortOfGhost = 19;
                            }
                        }

                    }
                }
                else
                {

                    ghostObject.SetActive(false);

                }



                ghostObject.transform.position = new Vector3(myObject.transform.position.x, (20 - comfortOfGhost), myObject.transform.position.z);
                int sayac = 0;
                for (int i = 0; i < 4; i++)
                {

                    x = ghostObject.transform.GetChild(i).transform.position.x;
                    xRounded = (int)Math.Ceiling(x);
                    y = ghostObject.transform.GetChild(i).transform.position.y;
                    yRounded = (int)Math.Ceiling(y);
                    xRounded = xRounded + 5;
                    int connectX = 20 - yRounded;
                    int connectY = xRounded - 1;

                    if (connectY < 0)
                    {
                        ghostObject.transform.position = ghostObject.transform.position + new Vector3(1, 0, 0);
                    }
                    else if (connectY > 9)
                    {
                        ghostObject.transform.position = ghostObject.transform.position + new Vector3(-1, 0, 0);

                    }
                    //Debug.Log("Her bir kubun matris y koord" + connectX);

                    if (connectX > 19)
                    {

                        ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);
                    }
                    else if (connectX < 19)
                    {

                        sayac++;


                    }


                }
                if (sayac == 4)
                {
                    ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, -1, 0);
                    int wrongMove = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        x = ghostObject.transform.GetChild(k).transform.position.x;
                        xRounded = (int)Math.Ceiling(x);
                        y = ghostObject.transform.GetChild(k).transform.position.y;
                        yRounded = (int)Math.Ceiling(y);
                        xRounded = xRounded + 5;
                        int connectXc = 20 - yRounded;
                        int connectYc = xRounded - 1;
                        if (connectXc > 19 || connectYc > 19 || connectXc < 1 || connectYc < 1)
                        {
                            ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, -1, 0);
                        }
                        else if (jokerIsFull(control, connectXc, connectYc) == true || connectXc > 19)
                        {
                            wrongMove = 1;
                        }

                    }
                    if (wrongMove == 1)
                    {
                        ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);

                    }
                }

                int full = 0;
                for (int k = 0; k < 4; k++)
                {
                    x = ghostObject.transform.GetChild(k).transform.position.x;
                    xRounded = (int)Math.Ceiling(x);
                    y = ghostObject.transform.GetChild(k).transform.position.y;
                    yRounded = (int)Math.Ceiling(y);
                    xRounded = xRounded + 5;
                    int connectXc = 20 - yRounded;
                    int connectYc = xRounded - 1;
                    if (connectXc <= 19)
                    {


                        if (jokerIsFull(control, connectXc, connectYc) == true)
                        {
                            full = 1;
                        }
                    }
                    else
                    {
                        full = 1;
                    }

                }
                if (full == 1)
                {
                    ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);

                }


                comfortOfGhost = 0;




            }
            for (int i = 0; i < 4; i++)
            {

                x = ghostObject.transform.GetChild(i).transform.position.x;
                xRounded = (int)Math.Ceiling(x);
                y = ghostObject.transform.GetChild(i).transform.position.y;
                yRounded = (int)Math.Ceiling(y);
                xRounded = xRounded + 5;
                int connectX = 20 - yRounded;
                int connectY = xRounded - 1;

                if (connectX > 19)
                {
                    ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);
                }
                else if (jokerIsFull(control, connectX, connectY) == true)
                {
                    ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);

                }
            }
            for (int i = 0; i < 4; i++)
            {

                x = ghostObject.transform.GetChild(i).transform.position.x;
                xRounded = (int)Math.Ceiling(x);
                y = ghostObject.transform.GetChild(i).transform.position.y;
                yRounded = (int)Math.Ceiling(y);
                xRounded = xRounded + 5;
                int connectX = 20 - yRounded;
                int connectY = xRounded - 1;

                if (jokerIsFull(control, connectX, connectY) == true || connectX > 19)
                {
                    ghostObject.transform.position = ghostObject.transform.position + new Vector3(0, 1, 0);
                }
            }

        }
        else if(Time.timeScale==1 && ghostObject.gameObject==null )
        {
            ghostObject = Instantiate(myObject);
            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);
            ghostObject.transform.localEulerAngles = myObject.transform.localEulerAngles;
            ghostObject.GetComponent<Rigidbody>().useGravity = false;
            for (int i=0;i<ghostObject.transform.childCount;i++)
            {
                
                ghostObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(236, 86, 42, 50));
                ghostObject.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(236, 86, 42, 0));
            }
            

        }

        switch (globalRowCounter)
        {
            case 1:
                score = score + 1000;
                scoreText.SetText("Score: " + score);
               // Debug.Log("1 SATIR PATLADI +1000PUAN");
                cameraAnimator.Play("DestroyCamera");
                break;
            case 2:
                score = score + 3000;
                scoreText.SetText("Score: " + score);
              //  Debug.Log("2 SATIR PATLADI +3000PUAN");
                cameraAnimator.Play("DestroyCamera");


                break;
            case 3:
                score = score + 5000;
                scoreText.SetText("Score: " + score);
               // Debug.Log("3 SATIR PATLADI +5000PUAN");
                cameraAnimator.Play("DestroyCamera");


                break;
            case 4:
                score = score + 8000;
                scoreText.SetText("Score: " + score);
                //Debug.Log("4 SATIR PATLADI +8000PUAN");
                cameraAnimator.Play("DestroyCamera");


                break;
        }
        globalRowCounter = 0;


        if (rotating)
        {
            Wall.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            Wall.gameObject.GetComponent<Renderer>().enabled = true;
        }

        //Debug.Log(Convert.ToSingle(System.Math.Round(2.482214156614, 1, MidpointRounding.AwayFromZero)));

        //Basılan yeri gosteren kod
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousedata = Input.mousePosition;
            float mousex = Input.mousePosition.x;
            float mousey = Input.mousePosition.y;
            float mousez = Input.mousePosition.z;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(mousex, mousey));
            //if (Physics.Raycast(ray))
            //{
            //float desiredValueForZ = 0; //this depends on your project stuff, I don't know.
            Destroy(Instantiate(EfektoTouch.gameObject, Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 30f)), Quaternion.identity) as GameObject, EfektoTouch.main.startLifetimeMultiplier);
            //}
        }


        if (colorChanging && Time.timeScale == 1)
        {
            for (int i = 0; i < colorList.Count; i++)
            {
                //if (colorChanged.transform.GetChild(i) != null)
                if (colorList[i].gameObject != null)
                {
                    float lerp = Mathf.PingPong(Time.time, duration) / duration;
                    ////colorChanged.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
                    colorList[i].gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);

                }
            }
            if (colorChanging2 && Time.timeScale == 1)
            {
                for (int i = 0; i < colorList2.Count; i++)
                {
                    //if (colorChanged.transform.GetChild(i) != null)
                    if (colorList2[i].gameObject != null)
                    {
                        float lerp = Mathf.PingPong(Time.time, duration) / duration;
                        ////colorChanged.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
                        colorList2[i].gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);

                    }
                }
            }
            if (colorChanging3 && Time.timeScale == 1)
            {
                for (int i = 0; i < colorList3.Count; i++)
                {
                    //if (colorChanged.transform.GetChild(i) != null)
                    if (colorList3[i].gameObject != null)
                    {
                        float lerp = Mathf.PingPong(Time.time, duration) / duration;
                        ////colorChanged.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
                        colorList3[i].gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);

                    }
                }
            }
            if (colorChanging4 && Time.timeScale == 1)
            {
                for (int i = 0; i < colorList4.Count; i++)
                {
                    //if (colorChanged.transform.GetChild(i) != null)
                    if (colorList4[i].gameObject != null)
                    {
                        float lerp = Mathf.PingPong(Time.time, duration) / duration;
                        ////colorChanged.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
                        colorList4[i].gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);

                    }
                }
            }

        }


        effectCounter++;
        if (effectCounter == 10)
        {
            effectCounter = 0;
            for (int i = 0; i < 9; i++)
            {
                if (downEffect.Count > 0)
                {
                    int silinecek = UnityEngine.Random.Range(0, downEffect.Count);
                    if (downEffect[silinecek] != null)
                    {
                        Destroy(downEffect[silinecek]);
                        downEffect.RemoveAt(silinecek);
                    }
                }


            }

        }

        if (isDown == true && rotating == false)
        {
            //Debug.Log("isDown true");
            Rigidbody myRigid = myObject.GetComponent<Rigidbody>();
            explode();


            myRigid.MovePosition(myRigid.position + Vector3.down * myObject.GetComponent<HitScript>().check * 10 * Time.deltaTime);


        }

        if (swipeControls.SwipeLeft)
        {

            //Debug.Log("Left Swipe");
        }
        if (swipeControls.SwipeRight)
        {

            //Debug.Log("Right Swipe");
        }
        if (swipeControls.SwipeDown)
        {
            // Debug.Log("Down Swipe");
        }
        if (swipeControls.SwipeUp)
        {
            //Debug.Log("Up Swipe");
        }


        //Debug.Log("Su anki yuz: " + control);

        GameObject plane = GameObject.FindGameObjectWithTag("plane");
        for (int i = 0; i < plane.transform.childCount; i++)
        {
            if (plane.transform.GetChild(i).childCount == 0)
            {
                Destroy(plane.transform.GetChild(i).gameObject);
            }
        }


        //if (score >= gravityController) /////// GRAVITY ARTIRMA KISMI///////
        //{
        //    Vector3 gravity = new Vector3(0, -30.0F, 0);
        //    if (Physics.gravity.y >gravity.y)
        //    {
        //        Physics.gravity = Physics.gravity + new Vector3(0, -1.0F, 0);
        //    }

        //    gravityController = gravityController + 1000;
        //}

        if (myObject.gameObject != null)
        {
            Rigidbody myRigidbody = myObject.GetComponent<Rigidbody>();
            float speed = myRigidbody.velocity.magnitude;
        }



        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }



        if (myObject.gameObject != null)
        {


            if (myObject.GetComponent<HitScript>().check == 0 && Time.timeScale == 1)
            {
                Destroy(ghostObject.gameObject);
                score = score + 40;
                scoreText.SetText("Score: " + score);


                if (myObject.transform.childCount > 0)
                {
                    int[] kord = new int[4];
                    for (int i = 0; i <= myObject.transform.childCount - 1; i++)
                    {
                        //if (myObject.transform.childCount > i) { 
                        if (myObject.transform.GetChild(i).gameObject != null)
                        {
                            float x = myObject.transform.GetChild(i).position.x;
                            int xRounded = (int)Math.Ceiling(x);
                            float y = myObject.transform.GetChild(i).position.y;
                            int yRounded = (int)Math.Ceiling(y);
                            xRounded = xRounded + 5;

                            int connectX = 20 - yRounded;
                            int connectY = xRounded - 1;
                            kord[i] = connectX;
                            if (connectX <= 1)
                            {
                                Time.timeScale = 0;
                                watchAddMenu.SetActive(true);
                                pauseButton.SetActive(false);
                                jokerButton.SetActive(false);

                                for (int j = 0; j < GameMenuItems.Length; j++)
                                {
                                    GameMenuItems[j].SetActive(false);
                                }

                                //if (PlayerPrefs.GetInt("score")>PlayerPrefs.GetInt("highScore"))
                                //    {
                                //        PlayerPrefs.SetInt("highScore", score);
                                //    }
                                //    PlayerPrefs.SetInt("score",score);
                                //    GameObject.FindGameObjectWithTag("gameOverScript").GetComponent<GameOver>().showGameOver();
                                //for (int k=1;k<22;k++)
                                //{
                                //    LoopDestroyer(k);
                                //}
                                //Destroy(myObject);
                                //gameOverCheck = 1;    

                            }
                            else
                            {
                                fill(control, connectX, connectY, myObject.transform.GetChild(i).gameObject);

                                // Debug.Log(connectX);

                            }


                        }

                        // }

                    }

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = i + 1; j < 4; j++)
                        {
                            if (kord[j] < kord[i])
                            {
                                int x = kord[i];
                                kord[i] = kord[j];
                                kord[j] = x;
                            }

                        }

                        //blowControl(kord[i]);
                    }
                    // Debug.Log(kord[0] + "-" + kord[1] + "-" + kord[2] + "-" + kord[3]);
                    int[] kordc = new int[4];


                    for (int i = 0; i < 4; i++)
                    {
                        blowControl(kord[i]);

                        //Debug.Log(kord[i]);
                        /////////////////////BURDAN SONRASI YOK BURADA makeOneColor() cagiriliyor//////////
                        if (new_List.Contains(kord[i]) == false)
                        {
                            new_List.Add(kord[i]);
                            //Debug.Log(new_List.Count);

                            //new_List.ToArray();
                        }
                        //kordc = new_List.ToArray();   //önemli**


                        //var sNew = sList.ToArray();
                        //for (int j = 0; j < sNew.Length; j++)
                        //{
                        //    Debug.Log(sNew[i]);
                        //}

                        //makeOneColor(new_List[i]);
                    }


                    for (int i = 0; i < new_List.Count; i++)
                    {
                        //Debug.Log("FONk ICIN: " + new_List[i]);
                        makeOneColor(new_List[i]);

                    }

                    //for(int i =0; i< kordc.Length; i++)
                    //{
                    //    makeOneColor(kordc[i]);
                    //    Debug.Log("FONk ICIN: " + kordc[i]);
                    //}
                    ////////////////////BURAYA KADARKI KISIM YOK///////////////////////////////

                }

                printArray();




                objectType = rdmarray[2];
                if (gameOverCheck == 0) {
                    switch (objectType)
                    {
                        case 1:
                            myObject = Instantiate(L1Object);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            oldType = objectType;
                            objectType = rdmarrayfonk();


                            break;
                        case 2:
                            myObject = Instantiate(TObject);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        case 3:
                            myObject = Instantiate(IObject);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        case 4:
                            myObject = Instantiate(Z1Object);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        case 5:
                            myObject = Instantiate(Z2Object);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        case 6:
                            myObject = Instantiate(L2Object);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        case 7:
                            myObject = Instantiate(SquareObject);
                            objectList.Add(myObject.transform.GetChild(0).gameObject);
                            objectList.Add(myObject.transform.GetChild(1).gameObject);
                            objectList.Add(myObject.transform.GetChild(2).gameObject);
                            objectList.Add(myObject.transform.GetChild(3).gameObject);
                            oldType = objectType;
                            ghostObject = Instantiate(myObject);
                            ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

                            objectType = rdmarrayfonk();

                            break;
                        default:
                            break;
                    }
                }
                gorselfonk(rdmarray[2], rdmarray[1]);


            }
            else
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow) && rotating == false)
                {
                    Left();
                    //Vector3 position = myObject.transform.position;
                    //position.x = position.x - myObject.GetComponent<HitScript>().check;
                    //myObject.transform.position = position;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && rotating == false)
                {
                    Right();
                    //Vector3 position = myObject.transform.position;
                    //position.x=position.x+ myObject.GetComponent<HitScript>().check;
                    //myObject.transform.position = position;
                }

                if (Input.GetKey(KeyCode.DownArrow) && rotating == false)
                {
                    explode();
                    Rigidbody myRigid = myObject.GetComponent<Rigidbody>();
                    myRigid.MovePosition(myRigid.position + Vector3.down * myObject.GetComponent<HitScript>().check * 10 * Time.deltaTime);
                    // Down();

                    //Rigidbody myRigid = myObject.GetComponent<Rigidbody>();
                    //myRigid.MovePosition(myRigid.position + Vector3.down * myObject.GetComponent<HitScript>().check*10 * Time.deltaTime);



                }
                if ((swipeControls.SwipeLeft && !rotating) || (Input.GetKey(KeyCode.Space) && !rotating))
                {
                    check_isFull();


                }
                if ((swipeControls.SwipeRight && !rotating) || (Input.GetKey(KeyCode.LeftShift) && !rotating))
                {
                    check_isFullLeft();


                }


                if (rotating == true && rotateLot == false)
                {

                    //transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0f, 90, 0f), speed * Time.deltaTime);
                    myObject.transform.GetComponent<Rigidbody>().drag = 1000000;
                    myObject.transform.GetComponent<Collider>().enabled = false;
                    myObject.transform.GetComponent<HitScript>().enabled = false;
                    for (int i = 0; i <= 3; i++)
                    {
                        myObject.transform.GetChild(i).GetComponent<Collider>().enabled = false;

                    }
                    dondurbakalim();
                    //dondurbakalimLeft();
                    stp++;

                } else if (rotating == true && rotateLot == true)
                {
                    // Debug.Log("Yan Dolu");
                    //transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0f, 90, 0f), speed * Time.deltaTime);
                    myObject.transform.GetComponent<Rigidbody>().drag = 1000000;
                    myObject.transform.GetComponent<Collider>().enabled = false;
                    myObject.transform.GetComponent<HitScript>().enabled = false;
                    for (int i = 0; i <= 3; i++)
                    {
                        myObject.transform.GetChild(i).GetComponent<Collider>().enabled = false;

                    }
                    dondurbakalim();
                    //dondurbakalimLeft();

                    stp++;

                }
                if (rotateLot == true && rotating == false)
                {
                    check_isFull();
                }

                if (rotating == false)
                {
                    //if (rotateLot == true)
                    //{
                    //    check_isFull();
                    //}
                    //else
                    //{
                    myObject.transform.GetComponent<Rigidbody>().drag = 5;
                    myObject.transform.GetComponent<Collider>().enabled = true;
                    myObject.transform.GetComponent<HitScript>().enabled = true;

                    for (int i = 0; i <= 3; i++)
                    {
                        myObject.transform.GetChild(i).GetComponent<Collider>().enabled = true;

                    }
                    //}

                }
                if (Input.GetKeyDown(myKey2))
                {
                    RotateObject();


                }

            }



        }
    }
    public void check_isFull()
    {

        int isFull = 0;
        for (int i = 0; i <= 3; i++)
        {

            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;
            if (connectX<0)
            {
                break;
            }
            switch (control)
            {
                case 1:
                    if (side2[connectX, connectY].isFull == true)
                    {

                        isFull++;

                    }

                    break;
                case 2:
                    if (side3[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }

                    break;
                case 3:
                    if (side4[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }

                    break;
                case 4:
                    if (side1[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }
                    break;
            }
        }
        if (isFull != 0)
        {
            if ((control) == 4)
            {

                control = 1;

            }

            else
            {

                control = control + 1;

            }
            if (PlayerPrefs.GetInt("Effects") == 1) {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_classic_1_up_001_41737");
                transform.GetComponent<AudioSource>().Play();
            }


            rotdegree = (rotdegree + 90) % 360;
            rotating = true;
            jokerButton.SetActive(false);
            rotateLot = true;

        }
        else
        {
            if ((control) == 4)
            {

                control = 1;

            }

            else
            {

                control = control + 1;

            }
            if (PlayerPrefs.GetInt("Effects") == 1)
            {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_classic_1_up_001_41737");
                transform.GetComponent<AudioSource>().Play();
            }
            rotdegree = (rotdegree + 90) % 360;
            rotating = true;
            jokerButton.SetActive(false);

            rotateLot = false;
        }

    }

    /// ////////////////////
    public void check_isFullLeft()
    {

        int isFull = 0;
        for (int i = 0; i <= 3; i++)
        {

            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;
            if (connectX < 0)
            {
                break;
            }
            switch (control)
            {
                case 1:
                    if (side4[connectX, connectY].isFull == true)
                    {

                        isFull++;

                    }

                    break;
                case 2:
                    if (side1[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }

                    break;
                case 3:
                    if (side2[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }

                    break;
                case 4:
                    if (side3[connectX, connectY].isFull == true)
                    {
                        isFull++;

                    }
                    break;
            }
        }
        if (isFull != 0)
        {
            if ((control) == 1)
            {

                control = 4;

            }

            else
            {

                control = control - 1;

            }
            if (PlayerPrefs.GetInt("Effects") == 1)
            {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_classic_1_up_001_41737");
                transform.GetComponent<AudioSource>().Play();
            }


            rotdegree = (rotdegree - 90) % 360;

            rotating = true;
            rotateLot = true;

        }
        else
        {
            if ((control) == 1)
            {

                control = 4;

            }

            else
            {

                control = control - 1;

            }
            if (PlayerPrefs.GetInt("Effects") == 1)
            {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_classic_1_up_001_41737");
                transform.GetComponent<AudioSource>().Play();
            }

            rotdegree = (rotdegree - 90) % 360;
            rotating = true;
            rotateLot = false;
        }

    }

    /// ///////////




    public void Right()
    {

        int four = 0;

        for (int i = 0; i <= 3; i++)
        {
            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;
            if (connectY + 1 > 9 )
            {
                break;
            }else if (connectX<0)
            {
                while (connectX < 19)
                {
                    connectX += 1;

                }
            }

            switch (control)
            {
                case 1:
                    //Debug.LogWarning(connectX + "  -----------   "+connectY);
                    if (side1[connectX, connectY + 1].isFull == false)
                    {
                        four++;


                    }
                    break;
                case 2:
                    if (side2[connectX, connectY + 1].isFull == false)
                    {
                        four++;

                    }
                    break;
                case 3:
                    if (side3[connectX, connectY + 1].isFull == false)
                    {
                        four++;

                    }
                    break;
                case 4:
                    if (side4[connectX, connectY + 1].isFull == false)
                    {
                        four++;

                    }
                    break;
            }
        }
        if (four == 4)
        {
            if (myObject.transform.GetChild(0).position.x < 4 && myObject.transform.GetChild(1).position.x < 4 && myObject.transform.GetChild(2).position.x < 4 && myObject.transform.GetChild(3).position.x < 4)
            {

                Vector3 position = myObject.transform.position;
                position.x = position.x + myObject.GetComponent<HitScript>().check;
                myObject.transform.position = position;
            }
        }


    }

    public void Down()
    {
        // Debug.Log("Down fonk cagrıldı");
        isDown = true;
        //Debug.Log(isDown);


    }
    public void dontDown()
    {
        //   Debug.Log("Down false edildi");
        isDown = false;
    }
    public void Left()
    {
        int four = 0;

        for (int i = 0; i <= 3; i++)
        {
            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;

            if (connectY - 1 < 0)
            {
                break;
            }
            else if (connectX < 0)
            {
                while (connectX < 19)
                {
                    connectX += 1;

                }
            }
            switch (control)
            {
                case 1:
                    if (side1[connectX, connectY - 1].isFull == false)
                    {

                        four++;
                    }
                    break;
                case 2:
                    if (side2[connectX, connectY - 1].isFull == false)
                    {

                        four++;
                    }
                    break;
                case 3:
                    if (side3[connectX, connectY - 1].isFull == false)
                    {

                        four++;
                    }
                    break;
                case 4:
                    if (side4[connectX, connectY - 1].isFull == false)
                    {

                        four++;
                    }
                    break;
            }
        }
        if (four == 4)
        {
            if (myObject.transform.GetChild(0).position.x > -4 && myObject.transform.GetChild(1).position.x > -4 && myObject.transform.GetChild(2).position.x > -4 && myObject.transform.GetChild(3).position.x > -4)
            {
                Vector3 position = myObject.transform.position;
                position.x = position.x - myObject.GetComponent<HitScript>().check;
                myObject.transform.position = position;
            }
            ////////// YANLIŞLIKLA BİŞİ BULDUM LEEN //// LEFT RİGHT YAPINCA EKRANA GELIYORLAR
            //Destroy(Instantiate(efektoL.gameObject, myObject.transform.position, Quaternion.FromToRotation(Vector3.left, Vector3.right)) as GameObject, efekto.main.startLifetimeMultiplier);
            //if (objectType == 3 && myObject.transform.rotation.z == 0 || myObject.transform.rotation.z == 180)
            //{
            //    Destroy(Instantiate(efektoL.gameObject, new Vector3(myObject.transform.position.x, myObject.transform.position.y - 1, myObject.transform.position.z), Quaternion.FromToRotation(Vector3.left, Vector3.right)) as GameObject, efektoL.main.startLifetimeMultiplier);
            //}
            //else
            //{
            //    Destroy(Instantiate(efektoL.gameObject, myObject.transform.position, Quaternion.FromToRotation(Vector3.left, Vector3.right)) as GameObject, efektoL.main.startLifetimeMultiplier);
            //}


        }


    }
    public void RotateObject()
    {


        //int four = 0;

        //for (int i = 0; i <= 3; i++)
        //{
        //    float x = myObject.transform.GetChild(i).position.x;
        //    int xRounded = (int)Math.Ceiling(x);
        //    float y = myObject.transform.GetChild(i).position.y;
        //    int yRounded = (int)Math.Ceiling(y);
        //    xRounded = xRounded + 5;

        //    int connectX = 20 - yRounded;
        //    int connectY = xRounded - 1;
        //    switch (control)
        //    {
        //        case 1:
        //            if (side1[connectX, connectY].isFull == false && side1[connectX, connectY].isFull == false && side1[connectX + 1, connectY].isFull == false)
        //            {

        //                four++;
        //            }
        //            break;
        //        case 2:
        //            if (side2[connectX, connectY].isFull == false && side2[connectX, connectY].isFull == false && side2[connectX + 1, connectY].isFull == false)
        //            {

        //                four++;
        //            }
        //            break;
        //        case 3:
        //            if (side3[connectX, connectY].isFull == false && side3[connectX, connectY].isFull == false && side3[connectX + 1, connectY].isFull == false)
        //            {

        //                four++;
        //            }
        //            break;
        //        case 4:
        //            if (side4[connectX, connectY].isFull == false && side4[connectX, connectY].isFull == false && side4[connectX + 1, connectY].isFull == false)
        //            {


        //                four++;
        //            }
        //            break;
        //    }
        //}


        //if (four == 4 && myObject.transform.position.y <= 20 && myObject.transform.position.y > 1)
        //{

        Vector3 oldLoc = myObject.transform.localEulerAngles;
        myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        degree = degree + 90;

        if (WrongMove() == true)
        {
            //Debug.LogWarning("wrongMove true jansdkfjnasjkdfna");
            myObject.transform.position += new Vector3(1, 0, 0);
            if (WrongMove() == true)
            {
                //Debug.LogWarning("wrongMove true jansdkfjnasjkdfna");
                myObject.transform.position += new Vector3(-2, 0, 0);
                if (WrongMove() == true)
                {
                    //Debug.LogWarning("wrongMove true jansdkfjnasjkdfna");
                    myObject.transform.position += new Vector3(+1, +1, 0);
                    if (WrongMove() == true)
                    {
                       // Debug.LogWarning("wrongMove true jansdkfjnasjkdfna");
                        myObject.transform.position += new Vector3(0, -2, 0);
                        if (WrongMove() == true)
                        {
                           // Debug.LogWarning("wrongMove true jansdkfjnasjkdfna");
                            myObject.transform.position += new Vector3(0, +1, 0);
                            degree = degree - 90;
                            myObject.transform.localEulerAngles = oldLoc;
                        }
                        else
                        {
                            if (PlayerPrefs.GetInt("Effects") == 1)
                            {
                                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_menu_item_select_002_40877");
                                transform.GetComponent<AudioSource>().Play();
                            }
                        }
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("Effects") == 1)
                        {
                            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_menu_item_select_002_40877");
                            transform.GetComponent<AudioSource>().Play();
                        }
                    }
                }
                else
                {
                    if (PlayerPrefs.GetInt("Effects") == 1)
                    {
                        transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_menu_item_select_002_40877");
                        transform.GetComponent<AudioSource>().Play();
                    }
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Effects") == 1)
                {
                    transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_menu_item_select_002_40877");
                    transform.GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Effects") == 1)
            {
                transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_menu_item_select_002_40877");
                transform.GetComponent<AudioSource>().Play();
            }
        }




        //switch (oldType)
        //{

        //    case 1:
        //        if (myObject.transform.position.x < 3.5 && myObject.transform.position.x > -4)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //           // Debug.Log("ELSE GIRDI");
        //            if (myObject.transform.position.x > 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                  //  Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + -1, myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //            }
        //            else if (myObject.transform.position.x < 0)
        //            {

        //                if (myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //                  //  Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + 1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //            }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //        }
        //        break;


        //    case 2:
        //        if (myObject.transform.position.x < 3.5 && myObject.transform.position.x > -3)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //         //   Debug.Log("ELSE GIRDI");
        //            if (myObject.transform.position.x > 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //              //      Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x -1 , myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //                else
        //                {
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x , myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //            }
        //            else if (myObject.transform.position.x < 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                //    Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x +1 , myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //                else
        //                {
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x , myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //            }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //        }
        //      //  Debug.Log("EULERRR" + myObject.transform.localEulerAngles);
        //        break;


        //    case 3:
        //        if (myObject.transform.position.x <= 3.5 && myObject.transform.position.x >= -3.5)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //             //   Debug.Log("ELSE GIRDI");
        //                if (myObject.transform.position.x > 0)
        //                {
        //                if(myObject.transform.rotation.eulerAngles.z <91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //                 //   Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x - 1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //                else if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x - 2, myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //                }
        //                else if (myObject.transform.position.x < 0)
        //                {
        //                if(myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //             //       Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + 2, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //                else if(myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + 1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //                }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //            }
        //      //  Debug.Log("EULERRR" + myObject.transform.localEulerAngles);

        //        break;


        //    case 4:
        //        if (myObject.transform.position.x < 3.5 && myObject.transform.position.x > -3.5)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //          //  Debug.Log("ELSE GIRDI");
        //            if (myObject.transform.position.x > 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //              //      Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x -1, myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //            }
        //            else if (myObject.transform.position.x < 0)
        //            {

        //                if (myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //                 //   Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x +1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //            }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //        }
        //        break;


        //    case 5:
        //        if (myObject.transform.position.x < 3.5 && myObject.transform.position.x > -3.5)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //            //Debug.Log("ELSE GIRDI");
        //            if (myObject.transform.position.x > 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //                //    Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + -1, myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //            }
        //            else if (myObject.transform.position.x < 0)
        //            {

        //                if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                   // Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + 1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //            }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //        }
        //        break;


        //    case 6:
        //        if (myObject.transform.position.x < 4 && myObject.transform.position.x > -3.5)
        //        {
        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;
        //        }
        //        else
        //        {
        //           // Debug.Log("ELSE GIRDI");
        //            if (myObject.transform.position.x > 0)
        //            {
        //                if (myObject.transform.rotation.eulerAngles.z < 91 && myObject.transform.rotation.eulerAngles.z > 89)
        //                {
        //                   // Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + -1, myObject.transform.position.y, myObject.transform.position.z);
        //                }

        //            }
        //            else if (myObject.transform.position.x < 0)
        //            {

        //                if (myObject.transform.rotation.eulerAngles.z < 271 && myObject.transform.rotation.eulerAngles.z > 269)
        //                {
        //                  //  Debug.Log("SONUNDA GIRDI");
        //                    myObject.transform.position = new Vector3(myObject.transform.position.x + 1, myObject.transform.position.y, myObject.transform.position.z);
        //                }
        //            }

        //            myObject.transform.localEulerAngles = new Vector3(0, 0, degree);
        //            degree = degree + 90;

        //        }
        //        break;
        //    default:
        //        myObject.transform.eulerAngles = new Vector3(0, 0, degree);
        //        degree = degree + 90;
        //        break;
        //}






    }

    public bool WrongMove()
    {

        bool wrongMove = false;
        for (int i = 0; i <= 3; i++)
        {
            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;

            if (jokerIsFull(control, connectX, connectY) == true)
            {
                wrongMove = true;
            }
            if (connectX < 0 || connectX > 19 || connectY < 0 || connectY > 9)
            {
                return wrongMove;
            }
        }
        return wrongMove;
    }

    public void makeOneColor(int x)
    {

        int renkSayaci1 = 0;
        int renkSayaci2 = 0;
        int renkSayaci3 = 0;
        int renkSayaci4 = 0;
        //GameObject colorChanged = new GameObject();

        for (int i = 0; i < 10; i++)
        {
            if (side1[x, i].isFull == true)
            {
                renkSayaci1++;
            }
            if (side2[x, i].isFull == true)
            {
                renkSayaci2++;
            }
            if (side3[x, i].isFull == true)
            {
                renkSayaci3++;
            }
            if (side4[x, i].isFull == true)
            {
                renkSayaci4++;
            }

            if (renkSayaci1 == 10)
            {
                for (int k = 0; k < 10; k++)
                {
                    colorList.Add(side1[x, k].myCube);
                }
                colorChanging = true;
                renkSayaci1 = 0;

            }
            if (renkSayaci2 == 10)
            {
                for (int k = 0; k < 10; k++)
                {
                    colorList2.Add(side2[x, k].myCube);
                }
                colorChanging2 = true;
                renkSayaci2 = 0;
            }
            if (renkSayaci3 == 10)
            {
                for (int k = 0; k < 10; k++)
                {
                    colorList3.Add(side3[x, k].myCube);
                }
                colorChanging3 = true;
                renkSayaci3 = 0;
            }
            if (renkSayaci4 == 10)
            {
                for (int k = 0; k < 10; k++)
                {
                    colorList4.Add(side4[x, k].myCube);
                }
                colorChanging4 = true;
                renkSayaci4 = 0;
            }


        }
        //        switch (control)
        //{
        //    case 1:

        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (side1[x, i].isFull == true)
        //            {
        //                renkSayaci1++;
        //                //Debug.Log("RENKSAYACI1: " + renkSayaci1);



        //                if (renkSayaci1 == 10)
        //                {
        //                    for (int j = 0; j < objectList.Count; j++)
        //                    {
        //                        if (objectList[j].gameObject != null)
        //                        {


        //                            //if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1))// && objectList[j].transform.localPosition.z < -4.4 && objectList[j].transform.localPosition.z > -4.6 && objectList[j].transform.localPosition.x > -5.05 && objectList[j].transform.localPosition.x < 5.05)
        //                            if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1) && objectList[j].transform.position.z < -4.3 && objectList[j].transform.position.z > -4.7)
        //                            {
        //                                //objectList[j].gameObject.transform.SetParent(colorChanged.transform);
        //                                colorList.Add(objectList[j]);
        //                                //Debug.Log("1++" + colorList.Count);

        //                            }
        //                        }

        //                    }
        //                    colorChanging = true;
        //                    renkSayaci1 = 0;


        //                }
        //                else
        //                {
        //                    // colorChanging = false;
        //                }
        //            }
        //            else
        //            {

        //            }
        //        }

        //        break;
        //    case 2:

        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (side2[x, i].isFull == true)
        //            {
        //                renkSayaci2++;
        //                //Debug.Log("RENKSAYACI2: " + renkSayaci2);


        //                if (renkSayaci2 == 10)
        //                {
        //                    for (int j = 0; j < objectList.Count; j++)
        //                    {
        //                        if (objectList[j].gameObject != null)
        //                        {


        //                            // if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1))// && objectList[j].transform.localPosition.z < 5.05 && objectList[j].transform.localPosition.z > -5.05 && objectList[j].transform.localPosition.x > 4.4 && objectList[j].transform.localPosition.x < 4.6)
        //                            if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1) && objectList[j].transform.position.z < -4.3 && objectList[j].transform.position.z > -4.7)
        //                            {
        //                                //objectList[j].gameObject.transform.SetParent(colorChanged.transform);
        //                                colorList2.Add(objectList[j]);
        //                              //  Debug.Log("2++" + colorList2.Count);
        //                            }
        //                        }

        //                    }
        //                    colorChanging2 = true;
        //                    renkSayaci2 = 0;


        //                }
        //                else
        //                {
        //                    // colorChanging = false;
        //                }
        //            }
        //        }

        //        break;
        //    case 3:

        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (side3[x, i].isFull == true)
        //            {
        //                renkSayaci3++;
        //                //Debug.Log("RENKSAYACI3: " + renkSayaci3);



        //                if (renkSayaci3 == 10)
        //                {
        //                    for (int j = 0; j < objectList.Count; j++)
        //                    {
        //                        if (objectList[j].gameObject != null)
        //                        {


        //                            //if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1))//&& objectList[j].transform.localPosition.z > 4.4 && objectList[j].transform.localPosition.z < 4.6 && objectList[j].transform.localPosition.x > -5.05 && objectList[j].transform.localPosition.x < 5.05)
        //                            if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1) && objectList[j].transform.position.z < -4.3 && objectList[j].transform.position.z > -4.7)
        //                            {
        //                                //objectList[j].gameObject.transform.SetParent(colorChanged.transform);
        //                                colorList3.Add(objectList[j]);
        //                             //   Debug.Log("3++" + colorList3.Count);
        //                            }
        //                        }

        //                    }
        //                    colorChanging3 = true;
        //                    renkSayaci3 = 0;


        //                }
        //                else
        //                {
        //                    // colorChanging = false;
        //                }
        //            }
        //        }

        //        break;
        //    case 4:

        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (side4[x, i].isFull == true)
        //            {
        //                renkSayaci4++;
        //                //Debug.Log("RENKSAYACI4: " + renkSayaci4);


        //                if (renkSayaci4 == 10)
        //                {
        //                    for (int j = 0; j < objectList.Count; j++)
        //                    {
        //                        if (objectList[j].gameObject != null)
        //                        {


        //                            // if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1))//&& objectList[j].transform.localPosition.z < 5.05 && objectList[j].transform.localPosition.z > -5.05 && objectList[j].transform.localPosition.x > -4.6 && objectList[j].transform.localPosition.x < -4.4)
        //                            if (objectList[j].transform.position.y < (20 - x) && objectList[j].transform.position.y > (20 - x - 1) && objectList[j].transform.position.z < -4.3 && objectList[j].transform.position.z > -4.7)
        //                            {
        //                                //objectList[j].gameObject.transform.SetParent(colorChanged.transform);
        //                                colorList4.Add(objectList[j]);
        //                                //Debug.Log("4 için4" + colorList[j]);
        //                              //  Debug.Log("4++" + colorList4.Count);
        //                            }
        //                        }

        //                    }
        //                    colorChanging4 = true;
        //                    renkSayaci4 = 0;


        //                }
        //                else
        //                {
        //                    //colorChanging = false;
        //                }
        //            }
        //        }

        //        break;
        //    default:
        //        break;
        //}
    }

    public void blowControl(int x)  // for checking rows if they are filled
    {
        int completedColumns = 0;

        for (int i = 0; i < 10; i++)
        {

            if (side1[x, i].isFull == true && side2[x, i].isFull == true && side3[x, i].isFull == true && side4[x, i].isFull == true)
            {
                completedColumns++;
                Console.WriteLine("Sutun " + (i + 1) + " tamam");
                if (completedColumns == 10)
                {
                    sayBakalim++;
                    Console.WriteLine("Satir " + (x + 1) + "tamam");
                    LoopDestroyer(20 - x);
                    //downgradeView(20 - x);
                    downgrade(x);
                    globalRowCounter++;


                    //score = score + 1000;
                    //scoreText.SetText("Score: " + score);

                }
            }
            else
            {
                Console.WriteLine("Hata");
                break;
            }
        }
        if (sayBakalim != 0)
        {
            downgradeView(20 - x, sayBakalim);

        }

    }
    public int SideDestroyer()
    {
        GameObject TempParent = new GameObject();
        ////////////////
        for (int i = 0; i < objectList.Count; i++)
        {

            if (objectList[i].gameObject != null)
            {

                if (objectList[i].transform.position.z > -5 && objectList[i].transform.position.z < -4 && (objectList[i].transform.position.y != myObject.transform.GetChild(0).transform.position.y && objectList[i].transform.position.x != myObject.transform.GetChild(0).transform.position.x) && (objectList[i].transform.position.y != myObject.transform.GetChild(1).transform.position.y && objectList[i].transform.position.x != myObject.transform.GetChild(1).transform.position.x) && (objectList[i].transform.position.y != myObject.transform.GetChild(2).transform.position.y && objectList[i].transform.position.x != myObject.transform.GetChild(2).transform.position.x) && (objectList[i].transform.position.y != myObject.transform.GetChild(3).transform.position.y && objectList[i].transform.position.x != myObject.transform.GetChild(3).transform.position.x))
                {

                    objectList[i].transform.SetParent(TempParent.transform);
                }
            }


        }
        ExplosionScript explosion = new ExplosionScript();
        for (int i = 0; i < TempParent.transform.childCount; i++)
        {

            explosion.explode(TempParent.transform.GetChild(i).gameObject);
        }
        int childC= TempParent.transform.childCount;
        Destroy(TempParent.gameObject);


        switch (control)
        {
            case 1:
                for (int k = 0; k < 20; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        side1[k, j].isFull = false;
                    }

                }
                break;

            case 2:
                for (int k = 0; k < 20; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        side2[k, j].isFull = false;
                    }

                }
                break;


            case 3:
                for (int k = 0; k < 20; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        side3[k, j].isFull = false;
                    }

                }
                break;


            case 4:
                for (int k = 0; k < 20; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        side4[k, j].isFull = false;
                    }

                }
                break;

        }
        return childC;
    }

    public int LoopDestroyer(int row)
    {

        if (PlayerPrefs.GetInt("Effects") == 1)
        {
            transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_mallet_climb_ascend_004_40836");
            transform.GetComponent<AudioSource>().Play();
        }
        // Debug.Log(objectList.Count);
        GameObject TempParent = new GameObject();
        ////////////////
        List<GameObject> UpperParent = new List<GameObject>();
        for (int i = 0; i < objectList.Count; i++)
        {

            if (objectList[i].gameObject != null)
            {

                if (objectList[i].transform.position.y > row && objectList[i].transform.position.y < 20)
                {

                    UpperParent.Add(objectList[i]);
                }
            }


        }

        for (int i = 0; i < UpperParent.Count; i++)
        {

            if (UpperParent[i].transform.parent.tag != "plane")
            {
                if (UpperParent[i].gameObject != null && UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>()!=null)
                {

                
                if (UpperParent[i].gameObject != null && UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().useGravity != false)
                {


                    UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().useGravity = false;
                    UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                    UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().freezeRotation = true;

                }
                }
            }
            else
            {

            }

        }
        ////////////////
        for (int i = 0; i < objectList.Count; i++)
        {

            //Debug.Log(i);
            if (objectList[i].gameObject != null)
            {
                if (objectList[i].transform.position.y < row && objectList[i].transform.position.y > row - 1)
                {

                    objectList[i].transform.SetParent(TempParent.transform);

                    //objectList.RemoveAt(i);

                }
                else if (objectList[i].transform.position.y > row)
                {



                }

            }

        }
        ExplosionScript explosion = new ExplosionScript();
        for (int i = 0; i < TempParent.transform.childCount; i++)
        {

            explosion.explode(TempParent.transform.GetChild(i).gameObject);
        }
        int childC = TempParent.transform.childCount;
        Destroy(TempParent.gameObject);
        return childC;
    }


    public void downgradeView(int row, int rowCount)
    {

        List<GameObject> UpperParent = new List<GameObject>();
        for (int i = 0; i < objectList.Count; i++)
        {

            if (objectList[i].gameObject != null)
            {

                if (objectList[i].transform.position.y > row && objectList[i].transform.position.y < 20)
                {

                    UpperParent.Add(objectList[i]);
                }
            }


        }

        for (int i = 0; i < UpperParent.Count; i++)
        {

            //if (UpperParent[i].gameObject !=null && UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().useGravity != false)
            //{


            //UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().useGravity = false;
            //UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            //UpperParent[i].transform.parent.transform.GetComponent<Rigidbody>().freezeRotation = true;

            //}
            UpperParent[i].transform.position = new Vector3(UpperParent[i].transform.position.x, UpperParent[i].transform.position.y - rowCount, UpperParent[i].transform.position.z);
            float xPosition = UpperParent[i].transform.position.x;
            float yPosition = UpperParent[i].transform.position.y;
            float zPosition = UpperParent[i].transform.position.z;
            float xPositionx = Convert.ToSingle(System.Math.Round(xPosition, 1, MidpointRounding.AwayFromZero));
            float yPositiony = Convert.ToSingle(System.Math.Round(yPosition, 1, MidpointRounding.AwayFromZero));
            float zPositionz = Convert.ToSingle(System.Math.Round(zPosition, 1, MidpointRounding.AwayFromZero));
            //Debug.Log(xPositionx+"----"+yPositiony);
            UpperParent[i].transform.position = new Vector3(xPositionx, yPositiony, zPositionz);


        }
        sayBakalim = 0;


        Vector3 gravity = new Vector3(0, -30.0F, 0);
        if (Physics.gravity.y > gravity.y)
        {
            Physics.gravity = Physics.gravity + new Vector3(0, -1F, 0);
        }
    }

    //Matris Kodları
    public class Cube   // tetris cubes class
    {
        public GameObject myCube;
        public Boolean isFull = false;
        public string type = "standart";

        public void fill()
        {
            this.isFull = true;
        }

        public void typeChange(string type)
        {
            this.type = type;
        }

    }
    public void fillArrays(Cube[,] side)  // for filling the cubes arrays
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                side[i, j] = new Cube();
            }
        }
    }

    public void fill(int yuz, int x, int y, GameObject myCube)       // for filling the exact cube
    {
        switch (yuz)
        {
            case 1:
                side1[x, y].isFull = true;
                side1[x, y].myCube = myCube;
                if (y == 0)
                {
                    side4[x, 9].isFull = true;
                    side4[x, 9].myCube = myCube;
                }
                if (y == 9)
                {
                    side2[x, 0].isFull = true;
                    side2[x, 0].myCube = myCube;

                }
                break;
            case 2:
                side2[x, y].isFull = true;
                side2[x, y].myCube = myCube;
                if (y == 0)
                {
                    side1[x, 9].isFull = true;
                    side1[x, 9].myCube = myCube;

                }
                if (y == 9)
                {
                    side3[x, 0].isFull = true;
                    side3[x, 0].myCube = myCube;

                }
                // printArray(side2);
                break;
            case 3:
                side3[x, y].isFull = true;
                side3[x, y].myCube = myCube;
                if (y == 0)
                {
                    side2[x, 9].isFull = true;
                    side2[x, 9].myCube = myCube;

                }
                if (y == 9)
                {
                    side4[x, 0].isFull = true;
                    side4[x, 0].myCube = myCube;

                }
                //  printArray(side3);
                break;
            case 4:
                side4[x, y].isFull = true;
                side4[x, y].myCube = myCube;
                if (y == 0)
                {
                    side3[x, 9].isFull = true;
                    side3[x, 9].myCube = myCube;

                }
                if (y == 9)
                {
                    side1[x, 0].isFull = true;
                    side1[x, 0].myCube = myCube;


                }
                //   printArray(side4);
                break;
            default:
                Console.WriteLine("error");
                break;
        }
    }
    void printArray()
    {
        for (int i = 0; i < 20; i++)
        {
            switch (control)
            {
                case 1:
                    Debug.Log("1.Yüz:");




                    Debug.Log(side1[i, 0].isFull + "-" +
                        side1[i, 1].isFull + "-" +
                        side1[i, 2].isFull + "-" +
                        side1[i, 3].isFull + "-" +
                        side1[i, 4].isFull + "-" +
                        side1[i, 5].isFull + "-" +
                        side1[i, 6].isFull + "-" +
                        side1[i, 7].isFull + "-" +
                        side1[i, 8].isFull + "-" +
                        side1[i, 9].isFull);


                    break;
                case 2:
                    Debug.Log("2.Yüz:");


                    Debug.Log(side2[i, 0].isFull + "-" +
                        side2[i, 1].isFull + "-" +
                        side2[i, 2].isFull + "-" +
                        side2[i, 3].isFull + "-" +
                        side2[i, 4].isFull + "-" +
                        side2[i, 5].isFull + "-" +
                        side2[i, 6].isFull + "-" +
                        side2[i, 7].isFull + "-" +
                        side2[i, 8].isFull + "-" +
                        side2[i, 9].isFull);

                    break;
                case 3:
                    Debug.Log("3.Yüz:");


                    Debug.Log(side3[i, 0].isFull + "-" +
                        side3[i, 1].isFull + "-" +
                        side3[i, 2].isFull + "-" +
                        side3[i, 3].isFull + "-" +
                        side3[i, 4].isFull + "-" +
                        side3[i, 5].isFull + "-" +
                        side3[i, 6].isFull + "-" +
                        side3[i, 7].isFull + "-" +
                        side3[i, 8].isFull + "-" +
                        side3[i, 9].isFull);

                    break;
                case 4:
                    Debug.Log("4.Yüz:");


                    Debug.Log(side4[i, 0].isFull + "-" +
                        side4[i, 1].isFull + "-" +
                        side4[i, 2].isFull + "-" +
                        side4[i, 3].isFull + "-" +
                        side4[i, 4].isFull + "-" +
                        side4[i, 5].isFull + "-" +
                        side4[i, 6].isFull + "-" +
                        side4[i, 7].isFull + "-" +
                        side4[i, 8].isFull + "-" +
                        side4[i, 9].isFull);

                    break;

            }
        }
    }


    public void downgrade(int x)
    {

        Console.WriteLine("Downgrading " + (x + 1));
        for (int i = x; i > 0; i--)
        {
            for (int j = 0; j < 10; j++)
            {
                side1[i, j] = side1[(i - 1), j];
                side2[i, j] = side2[(i - 1), j];
                side3[i, j] = side3[(i - 1), j];
                side4[i, j] = side4[(i - 1), j];
            }

        }
        for (int i = 0; i < 10; i++)
        {
            side1[1, i] = side1[0, i];
            side1[0, i].isFull = false;
            side1[0, i].type = "standart";
            side2[1, i] = side1[0, i];
            side2[0, i].isFull = false;
            side2[0, i].type = "standart";
            side3[1, i] = side1[0, i];
            side3[0, i].isFull = false;
            side3[0, i].type = "standart";
            side4[1, i] = side1[0, i];
            side4[0, i].isFull = false;
            side4[0, i].type = "standart";
        }



    }
    public void fillArray()
    {
        int newInt;
        int oldInt = 0;
        for (int i = 0; i < 3; i++)
        {
            newInt = UnityEngine.Random.Range(1, 8);
            if (newInt == oldInt)
            {
                newInt = UnityEngine.Random.Range(1, 8);
                rdmarray[i] = newInt;
                oldInt = newInt;
            }
            else
            {
                rdmarray[i] = newInt;
                oldInt = newInt;

            }

        }
        // Debug.Log(rdmarray[2] + "-" + rdmarray[1] + "-" + rdmarray[0]);
    }
    public int rdmarrayfonk()
    {
        int randomTry;
        int obj = rdmarray[2];
        rdmarray[2] = rdmarray[1];
        rdmarray[1] = rdmarray[0];
        randomTry = UnityEngine.Random.Range(1, 8);
        if (randomTry == rdmarray[1])
        {
            randomTry = UnityEngine.Random.Range(1, 8);
            rdmarray[0] = randomTry;
        }
        else
        {
            rdmarray[0] = randomTry;

        }
        // Debug.Log(rdmarray[2] + "-" + rdmarray[1] + "-" + rdmarray[0]);
        return obj;
    }

    public void gorselfonk(int a, int b)
    {


        GameObject firstOT = null;
        GameObject secondOT = null;
        switch (a) {
            case 1:
                firstOT = L1Object;
                break;
            case 2:
                firstOT = TObject;
                break;
            case 3:
                firstOT = IObject;
                break;
            case 4:
                firstOT = Z1Object;
                break;
            case 5:
                firstOT = Z2Object;
                break;
            case 6:
                firstOT = L2Object;
                break;
            case 7:
                firstOT = SquareObject;
                break;
            default:
                break;
        }
        switch (b)
        {
            case 1:
                secondOT = L1Object;
                break;
            case 2:
                secondOT = TObject;
                break;
            case 3:
                secondOT = IObject;
                break;
            case 4:
                secondOT = Z1Object;
                break;
            case 5:
                secondOT = Z2Object;
                break;
            case 6:
                secondOT = L2Object;
                break;
            case 7:
                secondOT = SquareObject;
                break;
            default:
                break;
        }

        if (gorsel_1.transform.childCount > 0)
        {

            //Debug.Log(gorsel_1.transform.childCount);
            Destroy(gorsel_1.transform.GetChild(0).gameObject);


        }
        GameObject showObject = Instantiate(firstOT, new Vector3(-2, 25, 0), Quaternion.identity) as GameObject;
        Destroy(showObject.GetComponent<HitScript>());
        showObject.GetComponent<Rigidbody>().drag = 1000000;
        showObject.transform.SetParent(gorsel_1.transform);

        if (gorsel_2.transform.childCount > 0)
        {

            // Debug.Log(gorsel_2.transform.childCount);
            Destroy(gorsel_2.transform.GetChild(0).gameObject);


        }
        GameObject show2Object = Instantiate(secondOT, new Vector3(-6, 25, 0), Quaternion.identity) as GameObject;
        Destroy(show2Object.GetComponent<HitScript>());
        show2Object.GetComponent<Rigidbody>().drag = 1000000;
        show2Object.transform.SetParent(gorsel_2.transform);




    }
    void dondurbakalim()
    {
        //Debug.Log("Dondurme Basladı");
        //transform.Rotate(Vector3.up * (speed * Time.deltaTime));

        Vector3 direction = new Vector3(transform.rotation.eulerAngles.x, rotdegree, transform.rotation.eulerAngles.z);
        Quaternion targetRotation = Quaternion.Euler(direction);
        plane.transform.rotation = Quaternion.Lerp(plane.transform.rotation, targetRotation, Time.deltaTime * 3);
        //Debug.Log("Sonraki Aci" + transform.eulerAngles.y);


        if (stp > 55)
        {

            plane.transform.rotation = Quaternion.Lerp(plane.transform.rotation, targetRotation, Time.deltaTime * 60);
        }

        long angleY = (long)plane.transform.rotation.eulerAngles.y;

        if (rotdegree >= (angleY - 1) && rotdegree <= (angleY + 1) || (rotdegree == 180 && (angleY == 0 || angleY == -180)))
        {
            //Debug.Log(control);
            rotating = false;


            stp = 0;
        } else if (360 + rotdegree >= (angleY - 1) && 360 + rotdegree <= (angleY + 1) || (360 + rotdegree == 180 && (angleY == 0 || angleY == -180)))
        {
            // Debug.Log(control);
            rotating = false;


            stp = 0;
        }
        //  Debug.Log(angleY+" ++++ "+rotdegree);


        //Debug.LogWarning(plane.transform.rotation.eulerAngles.y);

        jokerButton.SetActive(true);

    }

    public bool jokerIsFull(int yuz, int x, int y)
    {
        if (x > 19 || y < 0 || y > 9 || x < 0)
        {
            return true;
        }
        switch (yuz)
        {
            case 1:
                return side1[x, y].isFull;

            case 2:
                return side2[x, y].isFull;

            case 3:
                return side3[x, y].isFull;

            case 4:
                return side4[x, y].isFull;

            default:
                return false;
        }
    }
    public bool matrisControl()
    {
        int four = 0;
        for (int i = 0; i <= 3; i++)
        {
            float x = myObject.transform.GetChild(i).position.x;
            int xRounded = (int)Math.Ceiling(x);
            float y = myObject.transform.GetChild(i).position.y;
            int yRounded = (int)Math.Ceiling(y);
            xRounded = xRounded + 5;

            int connectX = 20 - yRounded;
            int connectY = xRounded - 1;

            if (connectX + 1 < 19)
            {


                switch (control)
                {
                    case 1:
                        if (side1[connectX + 1, connectY].isFull == true)
                        {
                            four++;


                        }
                        break;
                    case 2:
                        if (side2[connectX + 1, connectY].isFull == true)
                        {

                            four++;


                        }
                        break;
                    case 3:
                        if (side3[connectX + 1, connectY].isFull == true)
                        {

                            four++;


                        }
                        break;
                    case 4:
                        if (side4[connectX + 1, connectY].isFull == true)
                        {

                            four++;


                        }
                        break;
                    default:
                        break;

                }
            }
            else
            {
                four++;
            }
        }
        if (four != 0)
        {
            return true;

        }
        else {
            return false;

        }

    }
    public void touchPoint()
    {
        //float touchx;
        //float touchy;
        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Vector3 touchData = Input.GetTouch(0).position;

        //    touchx = touchData.x;
        //    touchy = touchData.y ;
        //    // Construct a ray from the current touch coordinates
        //    Ray ray = Camera.main.ScreenPointToRay(new Vector2(touchData.x, touchData.y));
        //    if (Physics.Raycast(ray))
        //    {
        //        float desiredValueForZ = 0; //this depends on your project stuff, I don't know.
        //        Instantiate(EfektoTouch, Camera.main.ScreenToWorldPoint(new Vector3(touchx, touchy, desiredValueForZ)), Quaternion.identity);
        //    }
        //}


        //else if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousedata = Input.mousePosition;
        //    float mousex = Input.mousePosition.x;
        //    float mousey = Input.mousePosition.y;
        //    Debug.Log("mouseclicKOOO" + mousex + "----" + mousey);
        //    Instantiate(EfektoTouch,new Vector3(mousex, mousey, 0), Quaternion.identity);
        //}


        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousedata = Input.mousePosition;
        //    float mousex = Input.mousePosition.x;
        //    float mousey = Input.mousePosition.y;
        //    float mousez = Input.mousePosition.z;
        //    Ray ray = Camera.main.ScreenPointToRay(new Vector2(mousex, mousey));
        //    //if (Physics.Raycast(ray))
        //    //{
        //    //float desiredValueForZ = 0; //this depends on your project stuff, I don't know.
        //    Destroy(Instantiate(EfektoTouch.gameObject, Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 30f)), Quaternion.identity) as GameObject, efekto.main.startLifetimeMultiplier);
        //    //}
        //}


        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began)
        //    {
        //        // Construct a ray from the current touch coordinates
        //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

        //        // Create a particle if hit
        //        if (Physics.Raycast(ray))
        //        {
        //            Instantiate(particle, transform.position, transform.rotation);
        //        }
        //    }
        //}
    }
    public void acceptAd()
    {
        coin = (score * 2) / 100;
        //declineAd();
        //for (int j = 0; j < GameMenuItems.Length; j++)
        //{
        //    GameMenuItems[j].SetActive(true);
        //}
        //watchAddMenu.SetActive(false);
        //watchAccept = true;
        //for (int k = 11; k < 22; k++)
        //{
        //    LoopDestroyer(k);
        //}
        //for (int k = 19; k > 10; k--)
        //{
        //    downgrade(20 - k);

        //}
        //Destroy(ghostObject);
        //Destroy(myObject);
        //switch (objectType)
        //{
        //    case 1:
        //        myObject = Instantiate(L1Object);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        oldType = objectType;
        //        objectType = rdmarrayfonk();


        //        break;
        //    case 2:
        //        myObject = Instantiate(TObject);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    case 3:
        //        myObject = Instantiate(IObject);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    case 4:
        //        myObject = Instantiate(Z1Object);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    case 5:
        //        myObject = Instantiate(Z2Object);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    case 6:
        //        myObject = Instantiate(L2Object);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    case 7:
        //        myObject = Instantiate(SquareObject);
        //        objectList.Add(myObject.transform.GetChild(0).gameObject);
        //        objectList.Add(myObject.transform.GetChild(1).gameObject);
        //        objectList.Add(myObject.transform.GetChild(2).gameObject);
        //        objectList.Add(myObject.transform.GetChild(3).gameObject);
        //        oldType = objectType;
        //        ghostObject = Instantiate(myObject);
        //        ghostObject.transform.position = myObject.transform.position + new Vector3(0, -5, 0);

        //        objectType = rdmarrayfonk();

        //        break;
        //    default:
        //        break;
        //}
        //pauseButton.SetActive(true);
        //jokerButton.SetActive(true);
        //Time.timeScale = 1;

        watchAddMenu.SetActive(false);
        Time.timeScale = 1;
        watchAccept = false;
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        PlayerPrefs.SetInt("score", score);
        GameObject.FindGameObjectWithTag("gameOverScript").GetComponent<GameOver>().showGameOver();
        for (int k = 1; k < 22; k++)
        {
            LoopDestroyer(k);
        }
        Destroy(myObject);
        
        gameOverCheck = 1;
    }

    public void declineAd()
    {
        coin = score / 100;
        watchAddMenu.SetActive(false);
        Time.timeScale = 1;
        watchAccept = false;
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        PlayerPrefs.SetInt("score", score);
        GameObject.FindGameObjectWithTag("gameOverScript").GetComponent<GameOver>().showGameOver();
        for (int k = 1; k < 22; k++)
        {
            LoopDestroyer(k);
        }
        Destroy(myObject);
        gameOverCheck = 1;

    }
}
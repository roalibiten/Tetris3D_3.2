using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitScript : MonoBehaviour
{
    //GameObject a=new GameObject();
    public GameObject objectCreator;
    public GameObject plane;
    public int check = 1;
    float hotTime;

    float firstTime;
    private void Start()
    {
        objectCreator = GameObject.FindGameObjectWithTag("GameController");
        plane = GameObject.FindGameObjectWithTag("plane");
        check = 1;

    }
    private void Update()
    {



    }
    private void OnCollisionEnter(Collision collision)
    {
        int stopChecker = 0;
        if (collision.collider.name == "Plane" || collision.collider.tag == "Cube")
        {

            //Debug.Log("temas var ");
            int connectX = 0, connectY = 0;
            for (int i = 0; i <= transform.childCount - 1; i++)
            {

                if (transform.GetChild(i).gameObject != null)
                {
                    float x = transform.GetChild(i).position.x;
                    int xRounded = (int)Math.Ceiling(x);
                    float y = transform.GetChild(i).position.y;
                    int yRounded = (int)Math.Ceiling(y);
                    xRounded = xRounded + 5;

                    connectX = 20 - yRounded;
                    connectY = xRounded - 1;
                    //Debug.Log(connectX + " + " + connectY);
                    if (collision.collider.name == "Plane")
                    {
                        stopChecker = 4;
                        break;
                    }

                }
                
                switch (objectCreator.GetComponent<ObjectCreator>().control)
                {
                    case 1:
                        if (connectX + 1 >= 20)
                        {
                            stopChecker++;
                        }
                        else if (objectCreator.GetComponent<ObjectCreator>().side1[connectX + 1, connectY].isFull)
                        {
                            stopChecker++;
                        }
                        break;
                    case 2:
                        if (connectX + 1 >= 20)
                        {
                            stopChecker++;
                        }
                        else if (objectCreator.GetComponent<ObjectCreator>().side2[connectX + 1, connectY].isFull)
                        {
                            stopChecker++;
                        }
                        break;
                    case 3:
                        if (connectX + 1 >= 20)
                        {
                            stopChecker++;
                        }
                        else if (objectCreator.GetComponent<ObjectCreator>().side3[connectX + 1, connectY].isFull)
                        {
                            stopChecker++;
                        }
                        break;
                    case 4:
                        if (connectX + 1 >= 20)
                        {
                            stopChecker++;
                        }
                        else if (objectCreator.GetComponent<ObjectCreator>().side4[connectX + 1, connectY].isFull)
                        {
                            stopChecker++;
                        }
                        break;

                }
            }



            if (stopChecker > 0)
            {
                if (PlayerPrefs.GetInt("GameMusic") == 1)
                {
                    transform.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/zapsplat_multimedia_game_sound_tuned_percussion_detuned_tone_generic_012_40764");
                    transform.GetComponent<AudioSource>().Play();
                }

                transform.GetComponent<Rigidbody>().useGravity = false;
                transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                transform.GetComponent<Rigidbody>().freezeRotation = true;


                //Debug.Log("temas var ve altı dolu");

                check = 0;
                for(int k = 0; k < transform.childCount; k++)
                {
                    //eklenen
                    for(int l = 0; l < 20; l++)
                    {
                        if (transform.GetChild(k).transform.position.y > l && transform.GetChild(k).transform.position.y < l+1)
                        {
                            float a = l + 0.5f;
                            transform.GetChild(k).transform.position =new Vector3(transform.GetChild(k).transform.position.x, a, transform.GetChild(k).transform.position.z);
                        }
                    }
                    //eklenen
                    

                }


                transform.SetParent(plane.transform);


            }


        }
    }
}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject RightJPG, LeftJPG, DownJPG, RotateJPG, SwipeJPG;
    int a = 0;
    // Start is called before the first frame update1
    void Start()
    {
        RightJPG.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (a <= 5)
            {
                a = a + 1;

            }
        }
        if (a == 0)
        {
            RightJPG.SetActive(true);

        }else if(a==1){
            RightJPG.SetActive(false);
            LeftJPG.SetActive(true);
        }
        else if (a == 2)
        {
            LeftJPG.SetActive(false);
            DownJPG.SetActive(true);
        }
        else if (a == 3)
        {
            DownJPG.SetActive(false);
            RotateJPG.SetActive(true);
        }
        else if (a == 4)
        {
            RotateJPG.SetActive(false);
            SwipeJPG.SetActive(true);
        }
        else if (a == 5)
        {
            SceneManager.LoadScene("0");

        }
    }
}

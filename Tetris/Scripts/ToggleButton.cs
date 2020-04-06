using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject GMToggleBGO;
    public GameObject GMToggleBGC;
    public GameObject GMToggleButton;

    public GameObject SEToggleBGO;
    public GameObject SEToggleBGC;
    public GameObject SEToggleButton;

    int GM;
    int SE;

    int GMO;
    int SEO;
    // Start is called before the first frame update
    void Start()
    {
        GM = PlayerPrefs.GetInt("GameMusic");
        SE = PlayerPrefs.GetInt("Effects");


        if (GM == 1)
        {

            GMToggleButton.GetComponent<Animator>().Play("ToggleOpen");
            GMToggleBGO.SetActive(true);
            GMToggleBGC.SetActive(false);

        }
        else
        {
            GMToggleButton.GetComponent<Animator>().Play("ToggleClose");
            GMToggleBGO.SetActive(false);
            GMToggleBGC.SetActive(true);

        }

        if (SE == 1)
        {

            SEToggleButton.GetComponent<Animator>().Play("ToggleOpen");
            SEToggleBGO.SetActive(true);
            SEToggleBGC.SetActive(false);

        }
        else
        {
            SEToggleButton.GetComponent<Animator>().Play("ToggleClose");
            SEToggleBGO.SetActive(false);
            SEToggleBGC.SetActive(true);

        }



    }

    // Update is called once per frame
    void Update()
    {
        GMO = PlayerPrefs.GetInt("GameMusic");
        SEO = PlayerPrefs.GetInt("Effects");


        if (GMO != GM)
        {
            if (GMO == 1)
            {

                GMToggleButton.GetComponent<Animator>().Play("ToggleOpen");
                GMToggleBGO.SetActive(true);
                GMToggleBGC.SetActive(false);

            }
            else
            {
                GMToggleButton.GetComponent<Animator>().Play("ToggleClose");
                GMToggleBGO.SetActive(false);
                GMToggleBGC.SetActive(true);

            }
        }

        if (SEO != SE)
        {
            if (SEO == 1)
            {

                SEToggleButton.GetComponent<Animator>().Play("ToggleOpen");
                SEToggleBGO.SetActive(true);
                SEToggleBGC.SetActive(false);

            }
            else
            {
                SEToggleButton.GetComponent<Animator>().Play("ToggleClose");
                SEToggleBGO.SetActive(false);
                SEToggleBGC.SetActive(true);

            }
        }

        GM = GMO;
        SE = SEO;
    }
}

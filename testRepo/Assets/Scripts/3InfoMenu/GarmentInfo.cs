using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarmentInfo : MonoBehaviour
{
    public GameObject firstLaunchMenu;
    public GameObject secondLaunchMenu;

    void Start()
    {
        // check if the info menu was opened before
        int thisMenuOpenedBefore = PlayerPrefs.GetInt("infoMenuOpenedBefore");
        print("checking if the app was launched before");
        if (thisMenuOpenedBefore == 0)
        {
            // First Time - set the "infoMenuOpenedBefore" to true
            PlayerPrefs.SetInt("infoMenuOpenedBefore", 1);
            print("app launched for the first time - go to Scan Menu");
            //Open the first launch menu
            firstLaunchMenu.SetActive(true);
        }
        else if (thisMenuOpenedBefore == 1)
        {
            //open the second launch menu
            secondLaunchMenu.SetActive(true);
        }

    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScanNFC : MonoBehaviour
{
    //#if UNITY_ANDROID && !UNITY_EDITOR
    //#endif
    //#if UNITY_EDITOR
    //#endif
    public Button FakeScan;
    

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        //Turn on the NFC scanning functionality --------
        // *****
        //turn off the fake button
        print("android mode");
        FakeScan.gameObject.SetActive(false);
#endif
    }

    public void ScanGarment()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        //do it this way --------
#endif

#if UNITY_EDITOR
        //pretend a garment was scanned by rolling a random number --------
        int garment = Random.Range(1, 4);
        if (garment == 1)
        {
            print("Garmnet 1 was scanned");
            PlayerPrefs.SetInt("GarmentType1", 1); //record garment type
            StartCoroutine(LoadInfoMenu()); // load garment info menu
        }
        else if (garment == 2)
        {
            print("Garment 2 was scanned");
            PlayerPrefs.SetInt("GarmentType2", 1); //record garment type
            StartCoroutine(LoadInfoMenu()); // load garment info menu
        }
        else if (garment == 3)
        {
            print("Garment 3 was scanned");
            PlayerPrefs.SetInt("GarmentType3", 1); //record garment type
            StartCoroutine(LoadInfoMenu()); // load garment info menu
        }
        else if (garment == 4)
        {
            print("Garment 4 was scanned");
            PlayerPrefs.SetInt("GarmentType4", 1); //record garment type
            StartCoroutine(LoadInfoMenu()); // load garment info menu
        }
        else print("Failed to scan garment. Try again.");
        
#endif
    }

    IEnumerator LoadInfoMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(3);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // Do something while the scene is loading
            print("Garment Info Menu is Loading...");
            yield return null;
        }
    }

}

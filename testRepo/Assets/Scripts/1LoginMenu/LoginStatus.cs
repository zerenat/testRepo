using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginStatus : MonoBehaviour
{   
    void Start()
    {
        // Check if the app launched for the first time --------
        int hasPlayed = PlayerPrefs.GetInt("HasPlayed");
        print("checking if the app was launched before");
        if (hasPlayed == 0) 
        {
            // First Time - set the "HasPlayed" to true
            PlayerPrefs.SetInt("HasPlayed", 1);
            print("app launched for the first time - go to Scan Menu");
            //Open "Scan Menu" scene
            StartCoroutine(LoadScanMenu());
        }
        else 
        {
            // Not First Time
            // Check if player is logged in --------
            int loggedIn = PlayerPrefs.GetInt("LoggedIn");
            print("app was launched before - check if user logged in");
            if (loggedIn == 0) 
            {
                //Not Logged in - open "Login Menu" scene
                print("user not logged in - go to Login Menu");
                StartCoroutine(LoadLoginMenu());
            }
            else
            {
                //Logged in - open "Main Menu" scene
                print("user is logged in - go to Main Menu");
                StartCoroutine(LoadMainMenu());
            }
        }
    }

    IEnumerator LoadScanMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) 
        {
            // Do something while the scene is loading
            print("Scan Menu is Loading...");
            yield return null;
        }
    }

    IEnumerator LoadLoginMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // Do something while the scene is loading
            print("Login Menu is Loading...");
            yield return null;
        }
    }

    IEnumerator LoadMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(4);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) 
        {
            // Do something while the scene is loading
            print("Main Menu is Loading...");
            yield return null;
        }
    }
}
    
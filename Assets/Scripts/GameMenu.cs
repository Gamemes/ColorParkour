using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public InputField inputObject;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game is Quit!");
        Application.Quit();
    }

    public void GetName()
    {
        MyGameManager.instance.currentUserInfo.name = inputObject.text;
        Debug.Log(inputObject.text);
        Debug.Log(MyGameManager.instance.currentUserInfo.name);
    }
}

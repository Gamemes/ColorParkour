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
        if (!GetName())
            return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game is Quit!");
        Application.Quit();
    }

    public bool GetName()
    {
        if (inputObject.text.Length < 3)
            return false;
        MyGameManager.instance.currentUserInfo.name = inputObject.text;
        Debug.Log($"name:{inputObject.text} uniqueName: {MyGameManager.instance.currentUserInfo.uniqueName}");
        return true;
    }
}

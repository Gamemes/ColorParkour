using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearanceMenu : MonoBehaviour
{
    [SerializeField] private GameObject thisGameObject;
    [SerializeField] private GameObject clearanceUICavans;
    public static Action onGameFinished;
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AgainGame()
    {
        SceneManager.LoadScene(1);
    }

    public void IsClearance()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        clearanceUICavans.SetActive(true);
        onGameFinished?.Invoke();
    }
}

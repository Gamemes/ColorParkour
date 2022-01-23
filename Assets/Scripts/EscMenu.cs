using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    [SerializeField] private bool esc = false;
    public GameObject EscObject = null;         //需要手动测试
    public bool gameIsOver = false;
    [SerializeField] private GameObject clearanceMenu;
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        IsEnterEsc();
        GameIsOver();
    }

    private void IsEnterEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsOver == false)
        {
            if (esc == false)
            {
                EscObject.SetActive(true);
                esc = true;
            }
            else
            {
                EscObject.SetActive(false);
                esc = false;
            }
        }
    }

    public void QuXiao()
    {
        if (esc == true)
        {
            esc = false;
        }
    }

    private void GameIsOver()
    {
        if (clearanceMenu.activeInHierarchy)
        {
            gameIsOver = true;
        }
    }
}

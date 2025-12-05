using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}

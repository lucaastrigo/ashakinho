using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuDeInicio : MonoBehaviour
{
    public string gameScene;

    public void Jogar()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Sair()
    {
        Application.Quit();
    }
}

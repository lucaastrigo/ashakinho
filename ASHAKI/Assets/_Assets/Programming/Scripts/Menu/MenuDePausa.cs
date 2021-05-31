using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool paused;

    private void Update()
    {
        if (!paused && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (paused)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Resumir()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuPrincipal(string menuName)
    {
        Resumir();

        SceneManager.LoadScene(menuName);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}

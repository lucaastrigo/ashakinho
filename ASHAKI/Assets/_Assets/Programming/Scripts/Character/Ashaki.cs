using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ashaki : MonoBehaviour
{
    GameMaster gm;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Instakill"))
        {
            print("kill");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

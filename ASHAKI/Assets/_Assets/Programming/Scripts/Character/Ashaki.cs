using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ashaki : MonoBehaviour
{
    public Collider fxCollider;

    GameMaster gm;
    public GameObject[] vfxs;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;

        vfxs = GameObject.FindGameObjectsWithTag("VFX");
    }

    private void Update()
    {
        //
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < vfxs.Length; i++)
        {
            if (vfxs[i].gameObject.CompareTag("VFX"))
            {
                print(vfxs[i].name);
                vfxs[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < vfxs.Length; i++)
        {
            if (vfxs[i].gameObject.CompareTag("VFX"))
            {
                print(vfxs[i].name);
                vfxs[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}

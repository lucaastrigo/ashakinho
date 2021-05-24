using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ashaki : MonoBehaviour
{
    public float vfxRange;

    GameMaster gm;
    GameObject[] vfxs;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;

        vfxs = GameObject.FindGameObjectsWithTag("VFX");
    }

    private void Update()
    {
        for (int i = 0; i < vfxs.Length; i++)
        {
            vfxs[i].transform.GetChild(0).gameObject.SetActive(Vector3.Distance(transform.position, vfxs[i].transform.position) <= vfxRange);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, vfxRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameMaster gm;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
        }
    }
}

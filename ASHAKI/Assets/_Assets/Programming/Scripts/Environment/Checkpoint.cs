using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject lightw;

    GameMaster gm;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
    }

    private void Update()
    {
        lightw.SetActive(gm.lastCheckpointPos == transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
            lightw.SetActive(true);
            //play checkpoint sound
        }
    }
}

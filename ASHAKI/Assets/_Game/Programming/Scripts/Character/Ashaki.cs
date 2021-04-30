using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashaki : MonoBehaviour
{
    GameMaster gm;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
    }
}

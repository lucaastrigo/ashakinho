using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animorto : MonoBehaviour
{
    public GameObject lightw, vfx;

    bool rescued;

    private void Update()
    {
        lightw.SetActive(!rescued);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!rescued)
            {
                Instantiate(vfx, transform.position, Quaternion.identity);
                ContadorAlmas.almas++;
                //play rescue sound
                rescued = true;
            }
        }
    }
}

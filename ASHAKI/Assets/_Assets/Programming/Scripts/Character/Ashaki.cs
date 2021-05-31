using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class Ashaki : MonoBehaviour
{
    //
    public float vfxRange;
    public Volume v;

    public bool canDrink, perigo;

    GameMaster gm;
    GameObject[] vfxs;
    Vignette vg;

    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;

        vfxs = GameObject.FindGameObjectsWithTag("VFX");

        v.profile.TryGet(out vg);
    }

    private void Update()
    {
        for (int i = 0; i < vfxs.Length; i++)
        {
            vfxs[i].transform.GetChild(0).gameObject.SetActive(Vector3.Distance(transform.position, vfxs[i].transform.position) <= vfxRange);
        }

        if(canDrink && Input.GetKeyDown(KeyCode.E))
        {
            //set animation trigger for drink


            //more health

            vg.intensity.value = 0;
        }

        if (perigo)
        {
            vg.intensity.value += 0.075f * Time.deltaTime;
        }

        if (vg.intensity.value >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            canDrink = true;
        }

        if (other.gameObject.CompareTag("Perigo"))
        {
            perigo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            canDrink = false;
        }

        if (other.gameObject.CompareTag("Perigo"))
        {
            perigo = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, vfxRange);
    }
}

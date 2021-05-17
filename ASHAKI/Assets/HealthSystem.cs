using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    Volume v;
    Vignette vg;

    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out vg);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            vg.intensity.value += 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            vg.intensity.value -= 0.01f;
        }
    }
}

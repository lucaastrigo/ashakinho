using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ContadorAlmas : MonoBehaviour
{
    public int almas;
    public TextMeshProUGUI tmp;

    void Start()
    {
        //
    }

    void Update()
    {
        //tmp.enabled = (almas > 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            almas++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            almas--;
        }

        if(almas < 0)
        {
            almas = 0;
        }else if(almas > 5)
        {
            almas = 5;
        }

        tmp.GetComponent<TMP_Text>().text = almas.ToString() + "/5";
    }
}

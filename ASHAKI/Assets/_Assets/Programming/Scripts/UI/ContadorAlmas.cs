using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ContadorAlmas : MonoBehaviour
{
    public static int almas;
    public TextMeshProUGUI tmp;

    void Start()
    {
        //
    }

    void Update()
    {
        //tmp.enabled = (almas > 0);
        tmp.transform.parent.parent.gameObject.SetActive(almas > 0);

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

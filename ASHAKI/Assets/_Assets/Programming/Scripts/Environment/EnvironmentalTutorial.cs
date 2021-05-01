using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnvironmentalTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string text;

    bool onTrigger;

    void Update()
    {
        if (onTrigger)
        {
            tutorialText.text = text;
        }
        else
        {
            tutorialText.text = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }
}

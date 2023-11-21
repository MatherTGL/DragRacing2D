using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI printedText;
    [SerializeField] private string startString;
    private void Start()
    {
        printedText.text = ""; 

        StartCoroutine(PrintText(startString));
    }

    private IEnumerator PrintText(string str)
    {
        foreach (char letter in str)
        {
            printedText.text +=  letter;
            yield return new WaitForSeconds(0.05f); 
        }
    }

 
}
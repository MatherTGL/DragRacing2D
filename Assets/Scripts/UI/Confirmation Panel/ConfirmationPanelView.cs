using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class ConfirmationPanelView : MonoBehaviour
{
    [SerializeField, Required]
    private Canvas _canvasConfirmationPanel;


    public void ShowCanvas()
    {
        _canvasConfirmationPanel.enabled = true;
    }

    public void CloseCanvas()
    {
        _canvasConfirmationPanel.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] Text displayNameText = null;
    [SerializeField] Renderer displayColorRenderer = null;
    
    [SyncVar(hook = nameof(HandleDisplayNameUpdated))] 
    [SerializeField] string displayName = "Missing Name";
    
    [SyncVar(hook = nameof(HandleDisplayColorUpdated))]
    [SerializeField] Color displayColor = Color.white;

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        displayColor = newDisplayColor;
    }

    private void HandleDisplayColorUpdated(Color oldColor, Color newColor)
    {
        displayColorRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displayNameText.text = newName;
    }
}


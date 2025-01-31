using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

public class ClientNetworkTransform : NetworkTransform
{
    // Removed the override keyword as there is no method to override in the base class
    protected override bool OnIsServerAuthoritative()
    {
        
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class NewBehaviourScript : NetworkBehaviour
{
    [SerializeField] private TextMeshPro playerName;

    NetworkVariable<networkString> networkPlayername =  new NetworkVariable<networkString>("unknonw" , NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            networkPlayername.Value = GameObject.Find("UIManger").GetComponent<UIManger>().usernameField.text;
        }
        playerName.text = networkPlayername.Value.ToString();
        networkPlayername.OnValueChanged += networkPlayername_OnValueChanged;
    }
    void networkPlayername_OnValueChanged(networkString previousValue , networkString newValue )
    {
        playerName.text = newValue;
    }






    }
    public struct networkString : INetworkSerializeByMemcpy
    {
        private ForceNetworkSerializeByMemcpy<FixedString32Bytes> _info;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _info);
        }
    
    public override string ToString()
    {
        return _info.Value.ToString();

    }
    public static implicit operator string(networkString s) => s.ToString();
    public static implicit operator networkString(string s) => new networkString() { _info = new FixedString32Bytes(s) };

}

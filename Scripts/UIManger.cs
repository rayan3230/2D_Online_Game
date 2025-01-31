using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    [SerializeField] public TMP_InputField usernameField;
    [SerializeField] public Button joinButton;
    [SerializeField] public Button hostButton;


    private void Start()
    {

        hostButton.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        joinButton.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }




}


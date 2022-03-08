using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMsgCenter : MonoBehaviour 
{
    private void Awake()
    {
        ClientPeer client = new ClientPeer();
        client.Connect("127.0.0.1", 6666);
    }
}

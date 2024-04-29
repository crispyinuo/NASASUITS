using System.Collections;
using WebSocketSharp;
using System.Collections.Generic;
using UnityEngine;

public class UserCommand
{
    public string user_input;
}

public class NetworkManager : MonoBehaviour
{
    WebSocket webSocket;
    // Start is called before the first frame update
    void Start()
    {
        webSocket = new WebSocket("ws://localhost:8080");
        webSocket.Connect();
        webSocket.OnMessage += (sender, e) => 
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (webSocket == null || !webSocket.IsAlive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UserCommand command = new UserCommand();
            command.user_input = "do task one a";
            webSocket.Send(JsonUtility.ToJson(command));
        }
    }
}

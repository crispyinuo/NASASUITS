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
        webSocket = new WebSocket("ws://f4e8-2600-387-f-6118-00-3.ngrok-free.app");
        Debug.Log("Hey");
        webSocket.OnOpen += (sender, e) => {Debug.Log("Opened connection!");};
        webSocket.OnError += (sender, e) => {Debug.Log("Error: " + e.Message);};
        webSocket.OnMessage += (sender, e) => 
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
        webSocket.Connect();
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
            Debug.Log("Sent!");
        }
    }
}

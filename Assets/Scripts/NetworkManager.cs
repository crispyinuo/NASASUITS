using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
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
        webSocket = new WebSocket("wss://free-square-garfish.ngrok-free.app");
        webSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        webSocket.SslConfiguration.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        webSocket.OnOpen += (sender, e) => {Debug.Log("Opened connection!");};
        webSocket.OnError += (sender, e) => {Debug.Log("Error: " + e.Message);};
        webSocket.OnMessage += (sender, e) => 
        {
            Debug.Log($"Message Received, Data : {e.Data}");
        };
        webSocket.OnClose += (sender, e) =>
        {
            Debug.Log("Connection Closed.");
        };
        webSocket.Connect();
        Debug.Log(webSocket.ReadyState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sendCommand("ur sah, do task one a");
        }
    }

    void OnDestroy()
    {
        if (webSocket != null)
        {
            webSocket.Close();
        }
    }

    public void sendCommand(string message)
    {
        if (webSocket == null || !webSocket.IsAlive)
        {
            Debug.Log("Command is not sent!!! The websocket is not alive:(");
            return;
        }
        UserCommand command = new UserCommand();
        command.user_input = message;
        webSocket.Send(JsonUtility.ToJson(command));
        Debug.Log($"Command sent: {message}");
    }
}

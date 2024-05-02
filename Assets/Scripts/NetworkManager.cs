using System.Collections;
using System;
using WebSocketSharp;
using WebSocketSharp.Net;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserCommand
{
    public string user_input;
}

[Serializable]
public class NetworkResponseParameter
{
    public string display_string;
}

[Serializable]
public class NetworkResponse
{
    public string function;
    public NetworkResponseParameter parameter;
}

public class NetworkManager : MonoBehaviour
{
    public GameObject egressTaskManager;
    private NetworkResponse response;
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
            response = JsonUtility.FromJson<NetworkResponse>(e.Data);     
        };
        webSocket.OnClose += (sender, e) =>
        {
            Debug.Log("Connection Closed.");
        };
        webSocket.Connect();
        webSocket.WaitTime = System.TimeSpan.MaxValue;
        Debug.Log(webSocket.ReadyState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           sendCommand("ur sah, do task one b");
        }
        if (response != null)
        {
            EgressTaskManager manager = egressTaskManager.GetComponent<EgressTaskManager>();
            manager.ExecuteTask(response.function, response.parameter.display_string);
            response = null;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogToScreen : MonoBehaviour
{
    uint gsize = 15; //number of messages to keep
    Queue myLogQueue = new Queue();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started up logging.");
    }

    vois OnEnable(){
    	Application.logMessageReceived += HandleLog;
    }

    void OnDisable(){
    	Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type){
    	myLogQueue.Enqueue("[" + type + "] : " + logString);
    	if(type == LogType.Execption){
    		myLogQueue.Enqueue(stackTrace);
    	}
    	while (myLogQueue.Count > qsize){
    		myLogQueue.Dequeue();
    	}
    }

    void OnGUI() {
    	GUILayout.BeginArea(new Rect(Screen.width - 400, 0, 400, Screen.height));
    	GUILayout.Label("\n" + string.Join("\n", myLogQueue.ToArray()));
    	GUILayout.EndArea();
    }
   
}

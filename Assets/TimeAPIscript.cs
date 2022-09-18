using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class TimeAPIscript : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "http://worldtimeapi.org/api/timezone/America/Chicago";

   
    void Start()
    {
       InvokeRepeating("GetDataFromWeb", 2f, 900f);
    }

    void GetDataFromWeb()
    {
       StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                int startTemp = webRequest.downloadHandler.text.IndexOf("datetime",0);
            	int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);

                timeTextObject.GetComponent<TextMeshPro>().text = "" + webRequest.downloadHandler.text.Substring(startTemp+22, (endTemp-startTemp-39)).ToString() + "";
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.Video;

public static class DataFetcher
{
    public static Action<Agents> OnAgentsDataReceived = null;
    public static Action<string, Texture2D> OnAgentPictureDataReceived = null;
    public static Action<string, Texture2D> OnChangePictureAgent = null;
    public static Action<string, Texture2D> OnChangePictureBackground = null;
    public static Action<Maps> OnMapsDataReceived = null;
    public static Action<string, Texture2D> OnMapPictureDataReceived = null;
    public static Action<string, Texture2D> OnMapPictureInGameDataReceived = null;
    public static Action<string, Texture2D> OnBackgroundScrolViewDataReceived = null;

    public static IEnumerator GetAgentsData()
    {
        yield return Request<Agents>(API.URL_API + API.URL_AGENTS, OnAgentsDataReceived);
    }

    public static IEnumerator GetData<T>(string _pictureURL, Action<T> _callback)
    {
        yield return Request<T>(_pictureURL, _callback);
    }

    public static IEnumerator GetPictureData(string _pictureURL, Action<string,Texture2D> _callback)
    {
        yield return RequestTexture(_pictureURL, _callback);
    }

    public static IEnumerator GetIconAgentPictureData(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnAgentPictureDataReceived);
    } 

    public static IEnumerator GetAgentPictureData(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnChangePictureAgent);
    } 
    
    public static IEnumerator GetBackgroundPictureData(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnChangePictureBackground);
    } 
    
    public static IEnumerator GetMapsData()
    {
        yield return Request<Maps>(API.URL_API + API.URL_MAPS, OnMapsDataReceived);
    }

    public static IEnumerator GetMapPictureData(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnMapPictureDataReceived);
    }

    public static IEnumerator GetMapPictureInGameData(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnMapPictureInGameDataReceived);
    }
    
    public static IEnumerator GetBackgroundScrolViewDataReceived(string _pictureURL)
    {
        yield return RequestTexture(_pictureURL, OnBackgroundScrolViewDataReceived);
    }

    public static IEnumerator Request<T>(string _url, Action<T> _callback)
    {
        using( UnityWebRequest _request = UnityWebRequest.Get(_url))
        {
            yield return _request.SendWebRequest();

            if (_request.result == UnityWebRequest.Result.ConnectionError || _request.result == UnityWebRequest.Result.ProtocolError)
            {
                //Debug.Log("Error with the request : " + _request.error);
            }
            else
            {
                string _json= _request.downloadHandler.text;
                //Debug.Log(_json);
                //T data = JsonUtility.FromJson<T>(_json);
                T data = JsonConvert.DeserializeObject<T>(_json);
                _callback?.Invoke(data);
            }
        }
    }


    public static IEnumerator RequestTexture(string _url, Action<string, Texture2D> _callback)
    {
        using (UnityWebRequest _request = UnityWebRequestTexture.GetTexture(_url))
        {
            yield return _request.SendWebRequest();

            if (_request.result == UnityWebRequest.Result.ConnectionError ||
                _request.result == UnityWebRequest.Result.ProtocolError)
            {
                //Debug.Log("Error with the request : " + _request.error+" : "+_url);
            }
            else
            {
                Texture2D _texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
                _callback?.Invoke(_url,_texture);
            }
        }
    }
}

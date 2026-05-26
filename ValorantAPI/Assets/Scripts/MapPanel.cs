using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class MapPanel : MonoBehaviour
{

    [SerializeField] Map currentMap;
    [SerializeField] Maps maps = null;
    //[SerializeField] Transform scrollViewTransform = null;

    [SerializeField] TextMeshProUGUI textMapName = null;
    [SerializeField] TextMeshProUGUI textMapCoordonate = null;
    [SerializeField] RawImage pictureMapInGame = null;

    [SerializeField] MapNextAndPreviousButton nextButtonMap = null;
    [SerializeField] MapNextAndPreviousButton previousButtonMap = null;
    [SerializeField] Texture2D rangeTexture = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Set currentMap an updat what use the currentMap
    /// </summary>
    /// <param name="_map"></param>
    public void SetCurrentMap(Map _map)
    {
        if (_map == null)
        {
            Debug.Log("Can not set CurrentMap with null");
            return;
        }
        currentMap = _map;
        MapMenuData _menu = GetComponentInParent<MapMenuData>();
        maps = _menu.Maps;
        //Debug.Log("_menu.gameObject.name" + _menu.gameObject.name);

        UpdateNextAndPreviousButton();
        UpdateInfoPanel();
    }

    /// <summary>
    /// Update info and picture who appear on the panel
    /// </summary>
    void UpdateInfoPanel()
    {
        textMapName.text=currentMap.DisplayName;
        textMapCoordonate.text= currentMap.Coordinates;

        if (!string.IsNullOrEmpty(currentMap.Splash))
        {
            DataFetcher.OnMapPictureDataReceived += UpdateBackground;
            StartCoroutine(DataFetcher.GetMapPictureData(currentMap.Splash));
        }
        
        string _displayIcon = currentMap.DisplayIcon;
        if (currentMap.DisplayName == "Basic Training" || currentMap.DisplayName == "The Range")
        {
            Debug.Log(currentMap.DisplayName + " = Basic Training or The Range " + _displayIcon);
            UpdateMapInGamePicture("", rangeTexture);
            return;
        }
        if (!string.IsNullOrEmpty(_displayIcon))
        {
            DataFetcher.OnMapPictureInGameDataReceived += UpdateMapInGamePicture;
            StartCoroutine(DataFetcher.GetMapPictureInGameData(_displayIcon));
        }
        else
        {
            pictureMapInGame.gameObject.SetActive(false);
            Debug.LogWarning($"DisplayIcon null or empty for the map: {currentMap.DisplayName}");
        }
    }
    
    /// <summary>
    /// Update Texture in background
    /// </summary>
    /// <param name="_url"></param>
    /// <param name="_texture"></param>
    void UpdateBackground(string _url, Texture2D _texture)
    {
        if (currentMap.Splash != _url)
            return;
        GetComponent<RawImage>().texture = _texture;

    }

    /// <summary>
    /// Update MapInGame texture
    /// </summary>
    /// <param name="_url"></param>
    /// <param name="_texture"></param>
    void UpdateMapInGamePicture(string _url, Texture2D _texture)
    {
        if (currentMap.DisplayIcon != _url && currentMap.DisplayName != "Basic Training" && currentMap.DisplayName != "The Range")
        {
            //Debug.Log(_url);
            return;
        }
        if (pictureMapInGame)
        {
            pictureMapInGame.gameObject.SetActive(true);
            pictureMapInGame.texture = _texture;
        }
        /*RawImage[] _images = GetComponentsInChildren<RawImage>();
        foreach (RawImage _image in _images)
        {
            if(_image.name== "MapInGame")
            {
                //Debug.Log("_image.name ->" + _image.name);
                _image.texture = _texture;
                return;
            }
        }*/
    }

    int GetIndexByMap(Map _map)
    {
        int _size = maps.Data.Count;
        for (int i = 0; i < _size; i++)
        {
            if (maps.Data[i] == _map)
                return i;
        }
        return 0;
    }

    /// <summary>
    /// Update Next Button and Previous Button when chaneg map
    /// </summary>
    void UpdateNextAndPreviousButton()
    {
        int _size = maps.Data.Count;
        int _indexcurrentMap = GetIndexByMap(currentMap);
        int _indeNext = _indexcurrentMap + 1 <= 0 ? 1 : _indexcurrentMap + 1 >= _size ? 0 : _indexcurrentMap + 1;
        int _indePrevious= _indexcurrentMap-1 < 0 ? _size - 1 : _indexcurrentMap - 1 >= _size ? 0: _indexcurrentMap - 1;

        nextButtonMap.SetMap(maps.Data[_indeNext]);
        previousButtonMap.SetMap(maps.Data[_indePrevious]);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapMenuData : MonoBehaviour
{
    [SerializeField] Maps maps= null;
    [SerializeField] MapButtonTall toSpawnForGrid = null;
    [SerializeField] Transform GridTransform = null;
    [SerializeField] List<MapButtonTall> allButtonTall = null;
    [SerializeField] GameObject mapPanel = null;
    [SerializeField] GameObject mapMenuPanel = null;

    public Maps Maps { get { return maps; } }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void init()
    {
        DataFetcher.OnMapsDataReceived += UpdateMapList;
        StartCoroutine(DataFetcher.GetMapsData());
    }

    /// <summary>
    /// Update Maps and update what use Maps
    /// </summary>
    /// <param name="_maps"></param>
    void UpdateMapList(Maps _maps)
    {
        if(_maps == null || _maps.Data == null || _maps.Data.Count <= 0)
        {
            //Debug.LogError("Error : Maps is null or Maps.Data is null or empty");
        }
        maps = _maps;
        InitRandomBackGroundSelectMapScrollView();
        InitScrollViewAndGridMap();
    }

    /// <summary>
    /// Init the grid maps, fill the grid with buttonTall, but they an have 1 time the map "TheRange"
    /// </summary>
    void InitScrollViewAndGridMap()
    {
        bool _theRangeIsPast = false;
        foreach (Map _map in maps.Data)
        {
            if (_theRangeIsPast && _map.DisplayName == "The Range")
                continue;

            if(!_theRangeIsPast && _map.DisplayName == "The Range")
              _theRangeIsPast = true;

            MapButtonTall _buttonTall = Instantiate(toSpawnForGrid, GridTransform);
            _buttonTall.Map = _map;
            allButtonTall.Add(_buttonTall);
        }
        InitButtonTall();
    }

    /// <summary>
    /// Init ButtonTall and gives the panels that appear and disappear when you click on the button
    /// </summary>
    void InitButtonTall()
    {
        int _size = allButtonTall.Count;
        for (int i = 0; i < _size; i++)
        {
            allButtonTall[i].InitButton();
            allButtonTall[i].TargetMapPanel = mapPanel;
            allButtonTall[i].ToStartPanel = mapMenuPanel;
        }
    }

    /// <summary>
    /// init random Texture on the background
    /// </summary>
    void InitRandomBackGroundSelectMapScrollView()
    {
        int _randomIndex=Random.Range(0, maps.Data.Count-1);
        string _url= maps.Data[_randomIndex].StylizedBackgroundImage;
        int _index = 0;
        int _size = maps.Data.Count;
        while (_url== null && _index< _size)
        {
            _randomIndex = Random.Range(0, maps.Data.Count);
            _url = maps.Data[_randomIndex].StylizedBackgroundImage;
            _index++;
        }


        DataFetcher.OnBackgroundScrolViewDataReceived += UpdateBackGroundSelectMapScrollView;
        StartCoroutine(DataFetcher.GetBackgroundScrolViewDataReceived(_url));
    }

    /// <summary>
    /// load random Texture on the background
    /// </summary>
    void UpdateBackGroundSelectMapScrollView(string _url, Texture2D _texture)
    {
        GameObject _scollView =GetComponentInChildren<ScrollRect>().gameObject;
        _scollView.GetComponent<RawImage>().texture = _texture;
    }
}

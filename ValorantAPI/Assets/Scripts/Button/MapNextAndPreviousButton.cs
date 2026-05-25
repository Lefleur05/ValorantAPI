using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapNextAndPreviousButton : CustomButton
{
    [SerializeField] bool isNextButton = true;
    [SerializeField] MapPanel mapPanel = null;
    [SerializeField] Map map = null;

    public bool IsNextButton { get { return isNextButton; } }
    public override void Execute()
    {
        mapPanel.SetCurrentMap(map);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMap(Map _map)
    {
        map = _map;
        GetComponentInChildren<TextMeshProUGUI>().text= map.DisplayName;
        DataFetcher.OnMapPictureDataReceived += UpdatePicture;
        //Debug.Log("map.listViewIcon -> " + map.ListViewIcon);
        StartCoroutine(DataFetcher.GetMapPictureData(map.ListViewIcon));
    }

    void UpdatePicture(string _url, Texture2D _texture)
    {
        if (map.ListViewIcon != _url)
        {
            //Debug.Log(map.listViewIcon);
            //Debug.Log(_url);
            return;
        }

        List<RawImage> _images = GetComponentsInChildren<RawImage>().ToList();
        foreach (RawImage _image in _images)
        {
            if (_image.gameObject.name == "IconMap")
                _image.texture = _texture;
        }
    }
    

}

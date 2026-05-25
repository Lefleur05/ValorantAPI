using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonTall : CustomButton
{
    public Map Map { get; set; }
    public GameObject TargetMapPanel { get; set; }
    public GameObject ToStartPanel { get; set; }
    public override void Execute()
    {
        ToStartPanel.SetActive(false);
        TargetMapPanel.SetActive(true);
        TargetMapPanel.GetComponent<MapPanel>().SetCurrentMap(Map);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitButton()
    {
        DataFetcher.OnMapPictureDataReceived += UpdateButton;
        if (Map.ListViewIconTall == null)
            return;
        //Debug.Log(Map.listViewIconTall);
        StartCoroutine(DataFetcher.GetMapPictureData(Map.ListViewIconTall));
    }

    void UpdateButton(string _url, Texture2D _texture)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = Map.DisplayName;
        if (_url != Map.ListViewIconTall)
            return;
        //Debug.Log("Map.DisplayName" + Map.DisplayName);
        ButtonPictureTexture = _texture;
    }
}

using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IconAgentButton : CustomButton
{
    public Agent Agent { get; set; }
    public RawImage BackgroundToSet { get; set; }
    public RawImage PictureAgentToSet { get; set; }
    public TextMeshProUGUI AgentNameToSet { get; set; }
    public Image BackGroundColor { get; set; }
    public GameObject infoAgentPanel { get; set; }

    [SerializeField] List<InfoAgentButton> infoButton = null;

    public Action<string, Texture2D> OnUpdatePictureInfoAgent = null;

    public override void Execute()
    {
        if (!BackgroundToSet || !PictureAgentToSet || !AgentNameToSet || !BackGroundColor || !infoAgentPanel)
            return;

        AgentNameToSet.text=Agent.DisplayName;
        UpdateBackgroundColor();
        UpdateInfoAgent();

        StartCoroutine(DataFetcher.GetAgentPictureData(Agent.FullPortrait));
        StartCoroutine(DataFetcher.GetBackgroundPictureData(Agent.Background));
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        InitButton();
    }


    public void InitPicture()
    {
        DataFetcher.OnAgentPictureDataReceived += UpdatePicture;
        //Debug.Log(Agent.DisplayIcon);
        StartCoroutine(DataFetcher.GetIconAgentPictureData(Agent.DisplayIcon));
    }

    void InitButton()
    {
        DataFetcher.OnChangePictureAgent += UpdatePictureAgent;
        DataFetcher.OnChangePictureBackground += UpdatePictureBackGround;
    }

    /// <summary>
    /// Load Picture For the Button
    /// </summary>
    void UpdatePicture(string _url, Texture2D _texture)
    {
        if(_url == Agent.DisplayIcon)
        {
            //Debug.Log("Picture");
            ButtonPictureTexture= _texture;
        }
    }

    /// <summary>
    /// change texture of the background
    /// </summary>
    /// <param name="_url"></param>
    /// <param name="_texture"></param>
    void UpdatePictureBackGround(string _url, Texture2D _texture)
    {
        BackgroundToSet.texture = _texture;
        Color _newColor = BackGroundColor.color + new Color(0.10f, 0.10f, 0.10f);
        BackgroundToSet.color = _newColor;
        //Debug.Log(BackgroundToSet.color +"="+ _newColor + ">" +BackGroundColor.color);
    }
    
    void UpdatePictureAgent(string _url, Texture2D _texture)
    {
        PictureAgentToSet.texture = _texture;
    }

    void UpdateBackgroundColor()
    {
        string _hexColor ="#"+ Agent.BackgroundGradientColors[0];
        bool _isValidColor = UnityEngine.ColorUtility.TryParseHtmlString(_hexColor, out Color _newColor);
        if (_isValidColor)
        {
            BackGroundColor.color = _newColor;
        }
    }

    void UpdateInfoAgent()
    {
        if(infoButton == null || infoButton.Count<=0)
        {
            infoButton = infoAgentPanel.GetComponentsInChildren<InfoAgentButton>().ToList();

        }
        int _size = infoButton.Count;

        if( _size <5 )
        {
            //Debug.LogError("Error : a button is missing");
            return;
        }

        List<string> _info = new List<string>();
        _info.Add(Agent.Description);
        _info.Add(Agent.Role.DisplayName +" : " + "\n"+Agent.Role.Description);
        int _sizeAbility= Agent.Abilities.Count;
        for (int i = 0; i < _sizeAbility; i++)
        {
            _info.Add(Agent.Abilities[i].DisplayName + " : " + "\n" + Agent.Abilities[i].Description);
        }


        infoButton[0].TargetInfoShow.text = Agent.Description;
        int _index = 0;
        for (int i = 0; i < _size; i++)
        {
            if (_index >= _info.Count)
                break;

            infoButton[i].Text = _info[_index];
            _index++;

            if(infoButton[i].IsActivable)
            {
                infoButton[i].TexWhenActivatet = _info[_index];
                _index++;
            }
        }

        OnUpdatePictureInfoAgent += UpdateInfoAgentPicture;
        OnUpdatePictureInfoAgent += UpdatePictureAgentAbility1;
        OnUpdatePictureInfoAgent += UpdatePictureAgentAbility2;
        OnUpdatePictureInfoAgent += UpdatePictureAgentAbility3;
        OnUpdatePictureInfoAgent += UpdatePictureAgentAbility4;
        StartCoroutine(DataFetcher.GetPictureData(Agent.Role.DisplayIcon, OnUpdatePictureInfoAgent));
        StartCoroutine(DataFetcher.GetPictureData(Agent.Abilities[0].DisplayIcon, OnUpdatePictureInfoAgent));
        StartCoroutine(DataFetcher.GetPictureData(Agent.Abilities[1].DisplayIcon, OnUpdatePictureInfoAgent));
        StartCoroutine(DataFetcher.GetPictureData(Agent.Abilities[2].DisplayIcon, OnUpdatePictureInfoAgent));
        StartCoroutine(DataFetcher.GetPictureData(Agent.Abilities[3].DisplayIcon, OnUpdatePictureInfoAgent));
       
    }

    void UpdateInfoAgentPicture(string _url, Texture2D _texture)
    {
        if (_url != Agent.Role.DisplayIcon)
            return;
        infoButton[0].GetComponentInChildren<RawImage>().texture = _texture;

    }

    void UpdatePictureAgentAbility1(string _url, Texture2D _texture)
    {
        if (_url != Agent.Abilities[0].DisplayIcon)
            return;
        infoButton[1].GetComponentInChildren<RawImage>().texture = _texture;
    }    
    
    void UpdatePictureAgentAbility2(string _url, Texture2D _texture)
    {
        if (_url != Agent.Abilities[1].DisplayIcon)
            return;
        infoButton[2].GetComponentInChildren<RawImage>().texture = _texture;
    }    
    
    void UpdatePictureAgentAbility3(string _url, Texture2D _texture)
    {
        if (_url != Agent.Abilities[2].DisplayIcon)
            return;
        infoButton[3].GetComponentInChildren<RawImage>().texture = _texture;
    }    
    
    void UpdatePictureAgentAbility4(string _url, Texture2D _texture)
    {
        if (_url != Agent.Abilities[3].DisplayIcon)
            return;
        infoButton[4].GetComponentInChildren<RawImage>().texture = _texture;

    }

}

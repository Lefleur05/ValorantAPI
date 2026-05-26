using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class IconSkinButton : CustomButton
{
    [SerializeField] Skin skin;

    public Skin Skin {  get { return skin; } set { skin = value; } }
    public List<RawImage> SkinToChange { get; set; }
    public TextMeshProUGUI NameSkinToChange { get; set; }

    public event Action<string, Texture2D> OnWeaponPictureDataReceived = null;

    public override void Execute()
    {
        int _size = SkinToChange.Count;
        for (int i = 0; i < _size; i++)
        {
            SkinToChange[i].texture = ButtonPictureTexture;
        }
        NameSkinToChange.text = Skin.DisplayName;
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

    public void InitWeaponButton()
    {
        string _url = skin.DisplayIcon;
        if (_url == null)
        {
            if(skin.Levels.Count > 0)
            _url = skin.Levels[0].DisplayIcon;

            if (_url == null)
            {
                //Debug.Log(skin.DisplayName);
                return;
            }
        }
        OnWeaponPictureDataReceived += UpdatePicture;
        //Debug.Log(skin.DisplayIcon + " -> "+ skin.DisplayName);
        StartCoroutine(DataFetcher.GetPictureData(_url, OnWeaponPictureDataReceived));
    }

    void UpdatePicture(string _url, Texture2D _texture)
    {
        if (skin.DisplayIcon != _url)
            return;
        //Debug.Log(_url);
        ButtonPictureTexture = _texture;
        GetComponentInChildren<RawImage>().texture = _texture;
    }

}

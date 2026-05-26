using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkinMenu : MonoBehaviour
{
    [SerializeField] Weapon currentWeapon = null;
    [SerializeField] Transform scrollViewTransform = null;
    [SerializeField] IconSkinButton toSpawn = null;
    [SerializeField] List<IconSkinButton> allIconWeaponButton = null;

    [SerializeField] List<RawImage> WeaponSkinToChange = null;
    [SerializeField] TextMeshProUGUI NameSkinToChange= null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeapon(Weapon _weapon)
    {
        if (currentWeapon == _weapon)
            return;
        currentWeapon = _weapon;
        //Debug.Log("currentWeapon = _weapon;");
        SetWeaponToButton();
    }

    void SetWeaponToButton()
    {
        int _size = currentWeapon.Skins.Count;
        RectTransform _viewport = scrollViewTransform.parent.GetComponent<RectTransform>();
        float _iconHeight = _viewport.rect.height;
        float _iconWidth = _iconHeight * 2.0f;// 2.0f ratio for 270 on 80

        for (int i = 0; i < _size; i++)
        {
            IconSkinButton _button = Instantiate(toSpawn, scrollViewTransform);

            RectTransform _rectTransfomr = _button.GetComponent<RectTransform>();
            _rectTransfomr.sizeDelta = new Vector2(_iconWidth, _iconHeight);

            _button.Skin = currentWeapon.Skins[i];
            _button.InitWeaponButton();
            _button.SkinToChange = WeaponSkinToChange;
            _button.NameSkinToChange = NameSkinToChange;
            allIconWeaponButton.Add( _button );
        }
    }


}

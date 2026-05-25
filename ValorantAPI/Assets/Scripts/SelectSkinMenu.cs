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
        for (int i = 0; i < _size; i++)
        {
            IconSkinButton _button = Instantiate(toSpawn, scrollViewTransform);

            _button.Skin = currentWeapon.Skins[i];
            _button.InitWeaponButton();
            _button.SkinToChange = WeaponSkinToChange;
            _button.NameSkinToChange = NameSkinToChange;
            allIconWeaponButton.Add( _button );
        }
    }


}

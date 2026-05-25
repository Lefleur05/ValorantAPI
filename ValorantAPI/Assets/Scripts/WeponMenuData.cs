using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponMenuData : MonoBehaviour
{
    [SerializeField] Weapons weapons = null;
    [SerializeField] List<SwitchMenuWeapon> allWeaponButton = null;

    public Weapons Weapons { get { return weapons; } set { weapons = value; } }

    public event Action<Weapons> OnWeaponsDataReceived = null;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        OnWeaponsDataReceived += UpdateWeapons;
        StartCoroutine(DataFetcher.GetData<Weapons>(API.URL_API+ API.URL_WEAPONS, OnWeaponsDataReceived));
    }

    void UpdateWeapons(Weapons _weapons)
    {
        weapons= _weapons;
        UpdateWeaponButton();
    }

    void UpdateWeaponButton()
    {
        int _size = allWeaponButton.Count;
        int _countWeapon = weapons.Data.Count;
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _countWeapon; j++)
            {
                string _name = "Select" + weapons.Data[j].DisplayName + "Skin";
                if (allWeaponButton[i].name== _name)
                {
                    allWeaponButton[i].Weapon = weapons.Data[j];
                }
                
            }
            
        }    
    }


}

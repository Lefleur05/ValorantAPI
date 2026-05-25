using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuWeapon : SwitchMenuButton
{
    [SerializeField] Weapon weapon;

    public Weapon Weapon {  get { return weapon; } set { weapon = value; } }
    public override void Execute()
    {
        
        base.Execute();
        int _size = targetMenu.Count;
        //Debug.Log(_size);
        for (int i = 0; i < _size; i++)
        {
            SelectSkinMenu _selectSkin = targetMenu[i].GetComponent<SelectSkinMenu>();
            if( _selectSkin != null )
            {
                //Debug.Log(" _selectSkin != null -> "+ _selectSkin);
                //Debug.Log(" Weapon give -> "+ weapon);
                _selectSkin.SetWeapon(weapon);
                return;
            }
        }

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
}

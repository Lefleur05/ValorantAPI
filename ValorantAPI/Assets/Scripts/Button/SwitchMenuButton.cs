using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuButton : CustomButton
{
    [SerializeField] List<GameObject> startMenus = null;
    [SerializeField] protected List<GameObject> targetMenu = null;
    public override void Execute()
    {
        int _sizeStartMenu= startMenus.Count;
        for (int i = 0; i < _sizeStartMenu; i++)
        {
            if (startMenus[i] != null)
                startMenus[i].SetActive(false);
        }

        int _sizeTargetMenu= targetMenu.Count;
        for (int i = 0; i < _sizeTargetMenu; i++)
        {
            if (!targetMenu[i])
            {
                //Debug.LogError("Error : Target Menu To Switch is null");
                return;
            }
            targetMenu[i].SetActive(true);
        }

       
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }



}

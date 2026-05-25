using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    public string Uuid { get; set; }
    public string DisplayName;
    public string DefaultSkinUuid { get; set; }
    public string DisplayIcon { get; set; }
    public List<Skin> Skins;
}
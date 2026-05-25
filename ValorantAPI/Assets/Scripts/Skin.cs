using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skin
{
    public string Uuid { get; set; }
    public string DisplayName;
    public string DisplayIcon;
    //public List<Chroma> Chromas;
    public List<LevelSkin> Levels;

}

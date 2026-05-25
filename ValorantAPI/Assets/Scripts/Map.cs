using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    public string Uuid { get; set; }
    public string DisplayName { get; set; }
    public string Coordinates { get; set; }
    public string DisplayIcon { get; set; }
    public string ListViewIcon { get; set; }
    public string ListViewIconTall { get; set; }
    public string Splash { get; set; }
    public string StylizedBackgroundImage { get; set; }
}

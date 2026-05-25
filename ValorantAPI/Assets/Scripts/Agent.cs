using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Agent
{
    public string Uuid { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string DisplayIcon { get; set; }
    public string FullPortrait { get; set; }
    public string Background { get; set; }
    public List<string> BackgroundGradientColors { get; set; }
    public bool IsPlayableCharacter { get; set; }
    public List<Ability> Abilities { get; set; }
    public Role Role { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoAgentButton : CustomButton
{
    [SerializeField] string text = null;
    [SerializeField] string texWhenActivatet = null;
    [SerializeField] TextMeshProUGUI targetInfoShow = null;
    [SerializeField] bool isActivable = false;
    [SerializeField] bool isActivate = false;

    public string Text { get { return text; } set { text = value; } }
    public string TexWhenActivatet { get { return texWhenActivatet; } set { texWhenActivatet = value; } }
    public TextMeshProUGUI TargetInfoShow { get { return targetInfoShow; } set { targetInfoShow = value; } }
    public bool IsActivable { get { return isActivable; } }

    public override void Execute()
    {
        isActivate = !isActivate;
        if (isActivate && isActivable)
        {
            targetInfoShow.text = texWhenActivatet;
        }
        else
        {
            targetInfoShow.text = text;
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

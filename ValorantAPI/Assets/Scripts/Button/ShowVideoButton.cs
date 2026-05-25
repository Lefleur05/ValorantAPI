using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ShowVideoButton : CustomButton
{
    [SerializeField] bool isActivate=false;
    [SerializeField] string textWhenisActivate = "";
    [SerializeField] string textWhenisDesactivate ="";
    //[SerializeField] VideoPlayer video = null;
    public override void Execute()
    {
        isActivate = !isActivate;
        if (isActivate)
        {
            buttonText.text = textWhenisActivate;

        }
        else if(!isActivate)
        {
            buttonText.text = textWhenisDesactivate;

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

    void OpenVideo()
    {
    }

    void CloseVideo()
    {

    }


}

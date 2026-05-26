using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Button button = null;
    [SerializeField] protected TextMeshProUGUI buttonText = null;

    [SerializeField] protected bool changeColorPictureWhenPointerOnHandler = false;
    [SerializeField] protected RawImage buttonPicture = null;

    [SerializeField] protected bool changeColorTextWhenPointerOnHandler = false;
    [SerializeField] protected Color colorWhenPointerOnHandler = new Color(255, 255, 255);
    [SerializeField] protected Color colorWhenPointerNotOnHandler = new Color(255, 255, 255);


    public Button Button => button;
    public TextMeshProUGUI ButtonText => buttonText;
    public Texture ButtonPictureTexture {  get { return buttonPicture.texture; } set { buttonPicture.texture = value; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    protected void Init()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonPicture =GetComponentInChildren<RawImage>();
        button.onClick.AddListener(Execute);
    }

    public abstract void Execute();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (changeColorTextWhenPointerOnHandler)
            buttonText.color = colorWhenPointerOnHandler;
        if(changeColorPictureWhenPointerOnHandler)
            buttonPicture.color = colorWhenPointerOnHandler;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (changeColorTextWhenPointerOnHandler)
            buttonText.color = colorWhenPointerNotOnHandler;
        if (changeColorPictureWhenPointerOnHandler)
            buttonPicture.color = colorWhenPointerNotOnHandler;
    }

    private void OnDisable()
    {
        if (changeColorTextWhenPointerOnHandler)
            buttonText.color = colorWhenPointerNotOnHandler;
        if (changeColorPictureWhenPointerOnHandler)
            buttonPicture.color = colorWhenPointerNotOnHandler;
    }
}

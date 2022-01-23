using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class CardController : MonoBehaviour
{
    [Header("Card Components")]
    public Deck deckToPrint;
    public string printDirectory;
    public new Camera camera;

    [Header("Top Element")]
    public Image headerTop;
    public TextMeshProUGUI actionTypeTop;
    public TextMeshProUGUI costTop;
    public TextMeshProUGUI titleTop;
    public TextMeshProUGUI descriptionTop;
    public TextMeshProUGUI speedTop;
    public SpriteRenderer iconTop;

    [Header("Bottom Element")]
    public Image headerBottom;
    public TextMeshProUGUI actionTypeBottom;
    public TextMeshProUGUI costBottom;
    public TextMeshProUGUI titleBottom;
    public TextMeshProUGUI descriptionBottom;
    public TextMeshProUGUI speedBottom;
    public SpriteRenderer iconBottom;


    [Header("Colour Palatte")]
    public Color actionColor;
    public Color attackColor;
    public Color parryColor;
    public Color moveColor;

    private void Start()
    {
        PrintDeck();

    }

    public void Capture(string id)
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        camera.Render();

        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;

        byte[] bytes = image.EncodeToPNG();
        Destroy(image);

        File.WriteAllBytes(Application.dataPath + printDirectory + "/" + id + ".png", bytes);
        Debug.Log("Card: " + id + " Created");
    }

    public void PrintDeck()
    {
        for (int i = 0; i < deckToPrint.cards.Length; i++)
        {

            ConstructCard(deckToPrint.cards[i]);
            Capture(deckToPrint.cards[i].id);
            //Print Card to Image File

        }
    }


    public void ConstructCard(Card card)
    {
        //Top Element
        //Card Header
        switch (card.topAction.actionType)
        {
            case ACTION_TYPE.ACTION:
                headerTop.color = actionColor;
                actionTypeTop.text = "Action";
                break;
            case ACTION_TYPE.ATTACK:
                headerTop.color = attackColor;
                actionTypeTop.text = "Attack";
                break;
            case ACTION_TYPE.PARRY:
                headerTop.color = parryColor;
                actionTypeTop.text = "Parry";
                break;
            case ACTION_TYPE.MOVE:
                headerTop.color = moveColor;
                actionTypeTop.text = "Move";
                break;
        }
        //Card Body
        costTop.text = card.topAction.cost.ToString();
        titleTop.text = card.topAction.title; ;
        descriptionTop.text = card.topAction.description;
        speedTop.text = card.topAction.speed;
        iconTop.sprite = card.topAction.referenceImage;



        //Bottom Element
        //Card Header
        switch (card.bottomAction.actionType)
        {
            case ACTION_TYPE.ACTION:
                headerBottom.color = actionColor;
                actionTypeBottom.text = "Action";
                break;
            case ACTION_TYPE.ATTACK:
                headerBottom.color = attackColor;
                actionTypeBottom.text = "Attack";
                break;
            case ACTION_TYPE.PARRY:
                headerBottom.color = parryColor;
                actionTypeBottom.text = "Parry";
                break;
            case ACTION_TYPE.MOVE:
                headerBottom.color = moveColor;
                actionTypeBottom.text = "Move";
                break;
        }
        //Card Body
        costBottom.text = card.bottomAction.cost.ToString();
        titleBottom.text = card.bottomAction.title; ;
        descriptionBottom.text = card.bottomAction.description;
        speedBottom.text = card.bottomAction.speed;
        iconBottom.sprite = card.bottomAction.referenceImage;
    }

}


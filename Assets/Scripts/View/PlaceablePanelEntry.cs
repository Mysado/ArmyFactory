using UnityEngine;
using UnityEngine.UI;

public class PlaceablePanelEntry : MonoBehaviour
{
    [SerializeField] private Image placeableImage;
    
    public Button placeableButton;
    private PlaceableData placeableData;

    public void Initialize(PlaceableData placeableData)
    {
        this.placeableData = placeableData;
        placeableImage.sprite = placeableData.Sprite;
    }
}

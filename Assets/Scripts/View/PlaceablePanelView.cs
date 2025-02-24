using UnityEngine;
using VContainer;

public class PlaceablePanelView : MonoBehaviour
{
    [SerializeField] private Transform placeableParent;
    [SerializeField] private GameObject placeableEntryPrefab;
    
    private PlaceableDataContainer placeableDataContainer;
    private ObjectSelector objectSelector;
    
    [Inject]
    public void Configure(PlaceableDataContainer placeableDataContainer, ObjectSelector objectSelector)
    {
        this.placeableDataContainer = placeableDataContainer;
        this.objectSelector = objectSelector;
        
        GeneratePanelEntries();
    }

    private void GeneratePanelEntries()
    {
        foreach (var placeable in placeableDataContainer.PlaceableDataList)
        {
            var entry = Instantiate(placeableEntryPrefab, placeableParent).GetComponent<PlaceablePanelEntry>();
            entry.Initialize(placeable);
            entry.placeableButton.onClick.AddListener(() => objectSelector.SpawnNewPlaceable(placeable));
        }
    }
}

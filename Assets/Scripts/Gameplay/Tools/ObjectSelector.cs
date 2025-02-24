using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class ObjectSelector : MonoBehaviour
{
    private ObjectPlacer objectPlacer;
    private Camera camera;
    
    private Placeable hoveredPlaceable;
    private Placeable selectedPlaceable;
    private LayerMask placeableMask;
    private Vector2Int originalPosition;

    public Placeable SelectedPlaceable => selectedPlaceable;
    
    [Inject]
    public void Configure(ObjectPlacer objectPlacer, InputHandler inputHandler)
    {
        this.objectPlacer = objectPlacer;
        camera = Camera.main;
        inputHandler.OnLMBClicked += OnLeftMouseClick;
        inputHandler.OnRMBClicked += OnRightMouseClick;
        placeableMask = LayerMask.GetMask("Placeable");
    }
    
    void Update()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (selectedPlaceable == null)
        {
            if (Physics.Raycast(ray,
                    out RaycastHit hit, Mathf.Infinity, placeableMask))
            {
                if(hit.collider.gameObject.CompareTag("Placeable"))
                {
                    var placeable = hit.collider.gameObject.GetComponent<Placeable>();
                    if(placeable != selectedPlaceable)
                        hoveredPlaceable = placeable;
                }
                else
                    hoveredPlaceable = null;
            }
            else
                hoveredPlaceable = null;
        }
    }

    private void OnLeftMouseClick()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (selectedPlaceable != null)
        {
            var position = new Vector2Int(Mathf.RoundToInt(selectedPlaceable.transform.position.x),
                Mathf.RoundToInt(selectedPlaceable.transform.position.z));
            
            if (objectPlacer.TryToPlaceObject(selectedPlaceable, position))
                selectedPlaceable = null;
            
        }
        else if(hoveredPlaceable != null)
        {
            originalPosition = hoveredPlaceable.ParentCellData.CellPosition;
            objectPlacer.PickupPlaceable(hoveredPlaceable);
            selectedPlaceable = hoveredPlaceable;
            hoveredPlaceable = null;
        }
    }

    private void OnRightMouseClick()
    {
        if(selectedPlaceable == null)
            return;

        if (originalPosition == Vector2Int.zero)
        {
            RemovePlaceable(selectedPlaceable);
            return;
        }
        
        MovePlaceableToPreviousPosition();
    }

    private void MovePlaceableToPreviousPosition()
    {
        if (objectPlacer.TryToPlaceObject(selectedPlaceable, originalPosition))
        {
            selectedPlaceable = null;
            originalPosition = Vector2Int.zero;
        }   
    }

    private void RemovePlaceable(Placeable placeable)
    {
        Destroy(placeable.gameObject);
    }

    public void SpawnNewPlaceable(PlaceableData placeable)
    {
        if(selectedPlaceable != null && originalPosition != Vector2Int.zero)
            MovePlaceableToPreviousPosition();
        else if(selectedPlaceable != null)
            RemovePlaceable(selectedPlaceable);
        
        var newPlaceable = Instantiate(placeable.Prefab).GetComponent<Placeable>();
        originalPosition = Vector2Int.zero;
        selectedPlaceable = newPlaceable;
    }
}

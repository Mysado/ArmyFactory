using UnityEngine;
using VContainer;

public class ObjectSelector : MonoBehaviour
{
    private ObjectPlacer objectPlacer;
    private InputHandler inputHandler;
    private Camera camera;
    
    private Placeable hoveredPlaceable;
    private Placeable selectedPlaceable;
    private LayerMask groundMask;
    private LayerMask placeableMask;
    
    [Inject]
    public void Configure(ObjectPlacer objectPlacer, InputHandler inputHandler)
    {
        this.objectPlacer = objectPlacer;
        this.inputHandler = inputHandler;
        camera = Camera.main;
        inputHandler.OnLPMClicked += OnMouseClick;
        groundMask = LayerMask.GetMask("Ground");
        placeableMask = LayerMask.GetMask("Placeable");
    }
    
    void Update()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (selectedPlaceable != null)
        {
            if (Physics.Raycast(ray,
                    out RaycastHit hit, Mathf.Infinity, groundMask))
            {
                var position = hit.point;
                position.x = Mathf.RoundToInt(position.x);
                position.z = Mathf.RoundToInt(position.z);
                selectedPlaceable.transform.position = position;
            }
        }
        else
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

    private void OnMouseClick()
    {
        if (selectedPlaceable != null)
        {
            var position = new Vector2Int(Mathf.RoundToInt(selectedPlaceable.transform.position.x),
                Mathf.RoundToInt(selectedPlaceable.transform.position.z));
            
            if (objectPlacer.TryToPlaceObject(selectedPlaceable, position))
                selectedPlaceable = null;
            
        }
        else if(hoveredPlaceable != null)
        {
            selectedPlaceable = hoveredPlaceable;
            hoveredPlaceable = null;
        }
    }
}

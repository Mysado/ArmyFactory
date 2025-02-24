using UnityEngine;
using VContainer;

public class ObjectMover : MonoBehaviour
{
    private ObjectSelector objectSelector;
    private Camera camera;
    
    private Placeable selectedPlaceable => objectSelector.SelectedPlaceable;
    private LayerMask groundMask;
    
    [Inject]
    public void Configure(InputHandler inputHandler, ObjectSelector objectSelector)
    {
        this.objectSelector = objectSelector;

        inputHandler.OnRotateLeftClicked += OnObjectRotatedLeft;
        inputHandler.OnRotateRightClicked += OnObjectRotatedRight;
        camera = Camera.main;
        groundMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (selectedPlaceable == null)
            return;
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,
                out RaycastHit hit, Mathf.Infinity, groundMask))
        {
            var position = hit.point;
            position.x = Mathf.RoundToInt(position.x);
            position.z = Mathf.RoundToInt(position.z);
            selectedPlaceable.transform.position = position;
        }
    }

    private void OnObjectRotatedLeft()
    {
        if(selectedPlaceable == null)
            return;
        
        selectedPlaceable.transform.Rotate(Vector3.up, -90);
    }
    
    private void OnObjectRotatedRight()
    {
        if(selectedPlaceable == null)
            return;
        
        selectedPlaceable.transform.Rotate(Vector3.up, 90);
    }

}

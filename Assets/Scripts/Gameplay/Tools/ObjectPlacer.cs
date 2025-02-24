using UnityEngine;

public class ObjectPlacer
{
    private IPlaceable currentPlaceable;
    private Grid grid;
    
    public ObjectPlacer(Grid grid)
    {
        this.grid = grid;
    }

    public void PickupPlaceable(IPlaceable placeable)
    {
        currentPlaceable = placeable;
        grid.RemoveObjectFromGrid(placeable.ParentCellData.CellPosition);
    }

    public bool TryToPlaceObject(IPlaceable placeable, Vector2Int position)
    {
        if (!grid.IsCellEmpty(position))
            return false;
        grid.PlaceObjectOnGrid(placeable, position);
        currentPlaceable = null;
        return true;
    }
}

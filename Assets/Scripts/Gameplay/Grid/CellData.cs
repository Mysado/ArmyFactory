using UnityEditor;
using UnityEngine;

public class CellData
{
    public Vector2Int CellPosition { get; }
    public bool IsCellEmpty { get; private set; }
    public IPlaceable CellObject { get; private set; }

    public CellData(Vector2Int cellPosition, bool isCellEmpty)
    {
        CellPosition = cellPosition;
        IsCellEmpty = isCellEmpty;
    }

    public void PlaceObject(IPlaceable cellObject)
    {
        CellObject = cellObject;
        IsCellEmpty = false;
    }
    
    public void RemoveObject()
    {
        CellObject = null;
        IsCellEmpty = true;
    }
}

using UnityEngine;

public class Placeable : MonoBehaviour, IPlaceable
{
    public CellData ParentCellData { get; set; }
}

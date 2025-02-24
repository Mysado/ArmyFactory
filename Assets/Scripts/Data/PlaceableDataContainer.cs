using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableDataContainer", menuName = "Scriptable Objects/PlaceableDataContainer")]
public class PlaceableDataContainer : ScriptableObject
{
    [SerializeField] private List<PlaceableData> placeableDataList;
    
    public List<PlaceableData> PlaceableDataList => placeableDataList;
}

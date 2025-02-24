using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableData", menuName = "Scriptable Objects/PlaceableData")]
public class PlaceableData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite sprite;
    
    public GameObject Prefab => prefab;
    public Sprite Sprite => sprite;
}

using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapConfigSO", menuName = "Map/MapConfigSO")]
public class MapConfigSO : ScriptableObject
{
    public List<RoomBlueprints> roomBlueprints = new List<RoomBlueprints>();
}

[Serializable]
public class RoomBlueprints 
{
    public int min, max;
    public RoomType roomType;
}

using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public MapConfigSO mapConfig;
    //房间
    public Room roomPrefab;
    //屏幕高度
    private float screenHeight;
    private float screenWidth;
    private float columnWidth;
    //生成点
    private Vector3 generationPoint;

    //边界
    public float border = 1;

    //private List<Room>  rooms = 

    private void Awake()
    {
        //计算屏幕高度
        screenHeight = Camera.main.orthographicSize * 2;
        //计算屏幕宽度
        screenWidth = Camera.main.aspect * screenHeight;
        //计算每个房间的宽度
        columnWidth = screenWidth / (mapConfig.roomBlueprints.Count + 1);

        CreateMap();
    }

    public void CreateMap()
    {
        for (int column = 0; column < mapConfig.roomBlueprints.Count; column++)
        {
            var blueprint = mapConfig.roomBlueprints[column];
            var amount = Random.Range(blueprint.min, blueprint.max);
            var startHeight = screenHeight / 2 - screenHeight / (amount + 1);
            generationPoint = new Vector3(-screenWidth / 2 + border + columnWidth * column, startHeight, 0);

            var newPosition = generationPoint;

            var posiY = screenHeight / (amount + 1);
            //循环当前列的所有房间数量生成房间
            for (int i = 0; i < amount; i++)
            {
                newPosition.y = startHeight - posiY * i;
                var room = Instantiate(roomPrefab, newPosition, Quaternion.identity, transform);
            }

        }
    }
}
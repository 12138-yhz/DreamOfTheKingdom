using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public MapConfigSO mapConfig;
    //����
    public Room roomPrefab;
    //��Ļ�߶�
    private float screenHeight;
    private float screenWidth;
    private float columnWidth;
    //���ɵ�
    private Vector3 generationPoint;

    //�߽�
    public float border = 1;

    //private List<Room>  rooms = 

    private void Awake()
    {
        //������Ļ�߶�
        screenHeight = Camera.main.orthographicSize * 2;
        //������Ļ���
        screenWidth = Camera.main.aspect * screenHeight;
        //����ÿ������Ŀ��
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
            //ѭ����ǰ�е����з����������ɷ���
            for (int i = 0; i < amount; i++)
            {
                newPosition.y = startHeight - posiY * i;
                var room = Instantiate(roomPrefab, newPosition, Quaternion.identity, transform);
            }

        }
    }
}
using UnityEngine;

public class Room : MonoBehaviour
{
    public int colum;
    public int line;
    private SpriteRenderer sprite;
    public RoomDataSO roomData;
    public RoomState roomState; 

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// 创建房间时调用
    /// </summary>
    /// <param name="colum"></param>
    /// <param name="line"></param>
    /// <param name="roomData"></param>
    public void SetupRoom(int colum,int line,RoomDataSO roomData)
    {
        this.colum = colum;
        this.line = line;
        this.roomData = roomData;
        sprite.sprite = roomData.roomIcon;
    }
}

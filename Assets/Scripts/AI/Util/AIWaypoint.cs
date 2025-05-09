using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
    public enum Type
    {
        SAFE, UNSAFE
    }
    public Vector3 position;
    public Type type;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
        AIWaypointManager.Instance.AddWaypoint(this);
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.Instance.player.transform.position - position).magnitude < 10) {
            this.type = Type.UNSAFE;
        } else {
            this.type = Type.SAFE;
        }
    }
}

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0.0f, 0.0f, -10.0f);
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}

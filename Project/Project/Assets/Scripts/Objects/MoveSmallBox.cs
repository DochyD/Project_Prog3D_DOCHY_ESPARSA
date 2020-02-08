using UnityEngine;

public class MoveSmallBox : MonoBehaviour
{

    private float minHeight = 5f;
    private float maxHeight = 30f;

    private float height = default;

    

   

    void Start()
    {
        moveBox();
    }

    private void moveBox()
    {
        height = Random.Range(minHeight, maxHeight);

        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}

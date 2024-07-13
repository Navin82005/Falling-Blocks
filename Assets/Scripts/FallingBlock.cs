using UnityEngine;
using UnityEngine.UIElements;

public class FallingBlock : MonoBehaviour
{
    public float fallSpeed = 5f;

    void Update()
    {
        transform.Translate(new Vector2(0, -fallSpeed) * Time.deltaTime);
    }
}

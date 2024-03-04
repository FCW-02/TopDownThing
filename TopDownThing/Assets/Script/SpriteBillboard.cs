using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;

    void Update()
    {
        if (freezeXZAxis)
        {
            Vector3 cameraEulerAngles = Camera.main.transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, cameraEulerAngles.y, 0f);
        }
        else
        {
            // Do nothing, let the sprite rotate freely
        }
    }
}

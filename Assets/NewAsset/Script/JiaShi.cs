using UnityEngine;

public class JiaShi : MonoBehaviour
{
    public Camera Xj;
    public float moveSpeed = 10f;
    public float rotateSpeed = 60f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

        Vector3 dir = Xj.transform.forward * v;
        dir.y = 0;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
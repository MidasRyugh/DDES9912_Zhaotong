using UnityEngine;

public class JianTou : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
    }
}
using UnityEngine;

public class GengDi : MonoBehaviour
{
    float ShiJian;
    bool Is_Over;
    public MeshRenderer[] Di;
    public Material mat;
    public GameObject Btn_Over;

    private void Start()
    {
        Is_Over = false;
        ShiJian = 0;
    }

    private void Update()
    {
        if (ShiJian >= 10f && !Is_Over)
        {
            foreach (var item in Di)
            {
                item.material = mat;
            }
            Btn_Over.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Is_Over = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("car") && !Is_Over)
        {
            ShiJian += Time.deltaTime;
        }
        Debug.Log(ShiJian);
    }
    public void btn_exit()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
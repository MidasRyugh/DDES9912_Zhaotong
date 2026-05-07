using UnityEngine;

public class FaDongJi : MonoBehaviour
{
    public GameObject Di, LianGan, Tou;
    public float rotateSpeed;
    public GameObject LianGanLianJieDian;
    public GameObject TouLianJieDian;
    public GameObject[] lun;

    void Update()
    {
        if (Di != null)
        {
            Di.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

        if (LianGan != null && LianGanLianJieDian != null)
        {
            LianGan.transform.position = LianGanLianJieDian.transform.position;
        }
        foreach (var item in lun)
        {
            item.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        LianGan.transform.LookAt(Tou.transform.position);
        Tou.transform.position = new Vector3(TouLianJieDian.transform.position.x, Tou.transform.position.y, Tou.transform.position.z);
    }
}
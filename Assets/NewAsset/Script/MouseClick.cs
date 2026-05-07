using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MouseClick : MonoBehaviour
{
    public UnityEvent OnClick;
    public float delayTime = 2f;
    public UnityEvent OnDelayEvent;
    float rayDistance = 100f;
    public bool is_distance;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckRaycast();
        }
    }

    void CheckRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                OnClick?.Invoke();
                if (is_distance)
                {
                    StartCoroutine(DelayExecute());
                }
                    
            }
        }
    }

    private IEnumerator DelayExecute()
    {
        yield return new WaitForSeconds(delayTime);
        OnDelayEvent?.Invoke();
    }
}
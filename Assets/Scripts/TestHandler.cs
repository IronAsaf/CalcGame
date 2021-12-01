using UnityEngine;

public class TestHandler : MonoBehaviour
{
    [SerializeField] private GameObject someObject;

    private bool flag = false;
    private void Start()
    {
        someObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag = !flag;
            someObject.SetActive(flag);
        }
    }
}

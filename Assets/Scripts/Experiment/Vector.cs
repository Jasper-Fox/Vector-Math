using UnityEngine;

public class Vector : MonoBehaviour
{
    public GameObject Source;
    
    private Vector3 Axis;

    private void Start()
    {
        Axis = Source.transform.localScale;
        transform.position = Axis.normalized;
    }

}
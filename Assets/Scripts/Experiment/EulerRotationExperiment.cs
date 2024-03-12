using UnityEngine;

public class EulerRotationExperiment : MonoBehaviour
{
    public bool localRotation;
    public GameObject Source;
    
    private Vector3 rotationSpeed;

    private void Start()
    {
        rotationSpeed = Source.transform.localScale;
    }
    //Вращаем вокруг заданного вектора 
    private void Update()
    {
       // transform.eulerAngles += rotationSpeed * Time.deltaTime;
        if (localRotation)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
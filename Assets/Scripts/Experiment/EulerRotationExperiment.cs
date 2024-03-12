using UnityEngine;

public class EulerRotationExperiment : MonoBehaviour
{
    public bool localRotation;
    public GameObject Source;
    
    private Vector3 rotationSpeed;
    
    //Вращаем вокруг заданного вектора 
    private void Update()
    {
        rotationSpeed = Source.transform.localScale;
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
using UnityEngine;

public class EulerRotationExperiment : MonoBehaviour
{
    public bool localRotation;
    public GameObject Source;
    
    private Vector3 _rotationSpeed;
    
    //Вращаем вокруг заданного вектора 
    private void Update()
    {
        _rotationSpeed = Source.transform.localScale;
       // transform.eulerAngles += rotationSpeed * Time.deltaTime;
        if (localRotation)
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
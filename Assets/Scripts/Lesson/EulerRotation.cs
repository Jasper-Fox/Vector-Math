using UnityEngine;

public class EulerRotation : MonoBehaviour
{
    public bool localRotation;
    public Vector3 rotationSpeed;

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
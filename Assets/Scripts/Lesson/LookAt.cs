using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform lookAt; 
    
    //Получаем вектор от наюлюдателя до объекта, нормализуем его, и поворачиваем кватернионом объект внаправлении полученного вектора осью z
    void Update()
    {
        Vector3 forward = (lookAt.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}

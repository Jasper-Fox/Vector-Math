using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public bool localRotation;
    public Vector3 rotationSpeed;
    
    /*
     * конвертируем вектор в кватернион: 1. домнажаем полученный кватернион на матрицу предыдущего поворота(тоесть поворачиваем по глобальному x а потом полученное доворачиваем предыдущим положением)
     *                                   2. домножаем исходный поворот на полученный кватернион(тоесть поворачиваем сначала в предыдущее положение а потом доворачиваем по глобальному x)
     */
    void Update()
    {
        Quaternion eulerAngle = Quaternion.Euler(rotationSpeed * Time.deltaTime);
        if (localRotation)
        {
            transform.rotation *= eulerAngle;
        }
        else
        {
            transform.rotation = eulerAngle * transform.rotation;
        }
    }
}

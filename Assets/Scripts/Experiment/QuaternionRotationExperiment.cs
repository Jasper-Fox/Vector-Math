using UnityEngine;

public class QuaternionRotationExperiment : MonoBehaviour
{
    public bool LocalRotation;
    public GameObject Source;
    
    private Vector3 _rotationSpeed;
    
    /*
     * конвертируем вектор в кватернион: 1. домнажаем полученный кватернион на матрицу предыдущего поворота(тоесть поворачиваем по глобальному x а потом полученное доворачиваем предыдущим положением)
     *                                   2. домножаем исходный поворот на полученный кватернион(тоесть поворачиваем сначала в предыдущее положение а потом доворачиваем по глобальному x)
     */
    void Update()
    {
        _rotationSpeed = Source.transform.localScale;
        Quaternion eulerAngle = Quaternion.Euler(_rotationSpeed * Time.deltaTime);
        if (LocalRotation)
        {
            transform.rotation *= eulerAngle;
        }
        else
        {
            transform.rotation = eulerAngle * transform.rotation;
        }
    }
}

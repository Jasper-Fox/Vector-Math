using UnityEngine;

public class QuaternionRotationExperiment : MonoBehaviour
{
    public bool LocalRotation;
    public GameObject Source;
    
    private Vector3 rotationSpeed;
    
    private void Start()
    {
        rotationSpeed = Source.transform.localScale;
    }

    /*
     * конвертируем вектор в кватернион: 1. домнажаем полученный кватернион на матрицу предыдущего поворота(тоесть поворачиваем по глобальному x а потом полученное доворачиваем предыдущим положением)
     *                                   2. домножаем исходный поворот на полученный кватернион(тоесть поворачиваем сначала в предыдущее положение а потом доворачиваем по глобальному x)
     */
    void Update()
    {
        Quaternion eulerAngle = Quaternion.Euler(rotationSpeed * Time.deltaTime);
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

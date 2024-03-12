using UnityEngine;

[ExecuteInEditMode] //Чтоб без запуска игры работало
public class CreatingQuaternion : MonoBehaviour
{
    [Header("Free Rotation")] //Оглавление в инспекторе
    [SerializeField] private bool freeRotation; //Галочка в инспекторе
    [SerializeField] private Vector3 axis;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float angle;

    [Header("Multiply")] 
    [SerializeField] private bool multiply;
    [SerializeField] private Vector3 multiplyAxis;
    [SerializeField] private float multiplyAngle;

    private void Update()
    {
        //Если галочка стоит то за вращение объекта отвечает созданный кватернион
        if (freeRotation)
        {  
            transform.rotation = GetQuaternion(axis, angle);
            //Если галочка стоит то умножаем
            if (multiply)
                Multiply();
        }
        //Иначе обнуляем
        else
        {
            transform.rotation = new Quaternion(); 
        }
        //Умнажаем вектор на кватернион, получаем вектор смещения, перемещаем объект в позицию вектора смещения
        Vector3 result = transform.rotation * offset;
        transform.position = result;
    }

    //Умнажаем кватернион на другой заданный кватернион, получаем сумму углов
    private void Multiply()
    {
        transform.rotation *= GetQuaternion(multiplyAxis, multiplyAngle);
    }

    /*
      Создание кватерниона: Получаем вектор и угол поворота в градусах
                            Нормализуем полученный вектор
                            Получаем половинный угол в радианах
                            В x y z записывем соответствующее заначение нормализованного вектора помноженное на синус половинного угла
                            В w записываем косинус половинного угла
                            Возвращаем кватенрион с соответствующими параметрами
    */
    private Quaternion GetQuaternion(Vector3 axis, float angle)
    {
        Vector3 normalizedAxis = axis.normalized;
        float halfAngle = angle * 0.5f * Mathf.Deg2Rad;

        float x = normalizedAxis.x * Mathf.Sin(halfAngle);
        float y = normalizedAxis.y * Mathf.Sin(halfAngle);
        float z = normalizedAxis.z * Mathf.Sin(halfAngle);
        float w = Mathf.Cos(halfAngle);

        return new Quaternion(x, y, z, w);
    }
}
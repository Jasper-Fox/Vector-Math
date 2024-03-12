using UnityEngine;

public class Vectors : MonoBehaviour
{
    private const float Radius = 0.05f;
    public Transform V1;
    public Transform V2;

    //Функция ресующая во вьюпорте
    private void OnDrawGizmos()
    {
        //Рисует если векторы введены
        if (V1 != null && V2 != null)
        {
            Vector3 vector1 = V1.position - transform.position;
            Vector3 vector2 = V2.position - transform.position;
            DrawVector(transform.position, vector1, Color.red);
            DrawVector(transform.position, vector2, Color.blue);
            DrawVector(transform.position, (vector1 + vector2).normalized, Color.yellow);

            //Сколярное произведение
            float dot = Vector3.Dot(vector1.normalized, vector2.normalized);
            //Создаём новый цвет, такой что яркость его зелёного и красного каналов зависит от значения сколярного произведения
            Color color = new Color(0f, 0f, 0f);
            if (dot > 0)
                color.g = dot;
            else
            {
                color.r = -dot;
            }

            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, 0.1f);
            
            //Векторное произведение
            Vector3 cross = Vector3.Cross(vector2, vector1);
            DrawVector(transform.position, cross, Color.green);
        }
    }

    /*
     * Получаем конец начало и цвет вектора
     * рисуем вектор и сфкру на конце
     */
    private void DrawVector(Vector3 start, Vector3 vector, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(start, vector);
        Gizmos.DrawSphere(start + vector, Radius);
    }
}

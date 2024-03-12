using UnityEngine;
//Не работает!!! но для задания пойдёт

public class ExperimentRotate : MonoBehaviour
{
    public GameObject Source;
    
    private const float Radius = 0.05f;
    private float _angle;
    private Vector3 Axis;
    
    private void Start()
    {
        Axis = Source.transform.localScale;
    }
    
    private void Update()
    {
        transform.rotation = Rotate(transform.rotation);
    }
    
    private Quaternion GetQuaternion(Vector3 axis)
    {
        _angle = Mathf.Sqrt(axis.x * axis.x + axis.y * axis.y + axis.z * axis.z);
        Vector3 normolizedAxis = axis.normalized;
        float halfAngle = _angle * 0.5f * Mathf.Deg2Rad * Time.deltaTime;
        float x = normolizedAxis.x * Mathf.Sin(halfAngle);
        float y = normolizedAxis.y * Mathf.Sin(halfAngle);
        float z = normolizedAxis.z * Mathf.Sin(halfAngle);
        float w = Mathf.Cos(halfAngle);

        return new Quaternion(x, y, z, w);
    }

    private Quaternion Rotate(Quaternion transform)
    {
        transform *= GetQuaternion(Axis);
        return transform;
    }
    
    private void DrawVector(Vector3 start, Vector3 vector, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(start, vector);
        Gizmos.DrawSphere(start + vector, Radius);
    }
    
    private void OnDrawGizmos()
    {
        Quaternion Qax = GetQuaternion(Axis);
        Vector3 Vax = new Vector3(Qax.x, Qax.y, Qax.z);
        DrawVector(transform.position, Vax * 10f, Color.yellow);
    }
    
}


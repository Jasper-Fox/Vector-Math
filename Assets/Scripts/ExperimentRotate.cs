using System.Linq;
using UnityEngine;

[ExecuteInEditMode] 

public class ExperimentRotate : MonoBehaviour
{
    public Vector3 Axis;
    
    private const float Radius = 0.05f;
    private float _angle;
    private float _numberOfComponents;
    private float[] _components;
    
    private void Update()
    {
        transform.rotation = GetQuaternion(Axis);
    }

    public float Components
    {
        get
        {
            _components = new[] { Axis.x, Axis.y, Axis.z };
            for (int i = 0; i <= 2; i++)
            {
                if (_components[i] != 0)
                    _components[i] = 1;
            }
            _numberOfComponents = _components.Sum();
            return _numberOfComponents;
        }
    }

    private Quaternion GetQuaternion(Vector3 axis)
    {
        _angle = (axis.x + axis.y + axis.z) / Components;
        
        Vector3 normolizedAxis = axis.normalized;
        float halfAngle = _angle * 0.5f * Mathf.Deg2Rad * Time.deltaTime;

        float x = normolizedAxis.x * Mathf.Sin(halfAngle);
        float y = normolizedAxis.y * Mathf.Sin(halfAngle);
        float z = normolizedAxis.z * Mathf.Sin(halfAngle);
        float w = Mathf.Cos(halfAngle);

        return new Quaternion(x, y, z, w);
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
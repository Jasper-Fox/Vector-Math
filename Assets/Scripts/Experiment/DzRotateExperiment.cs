using UnityEngine;

public partial class DzRotateExperiment : MonoBehaviour
{
    public GameObject Source;
    public float Angle;

    private const float Radius = 0.05f;
    private Vector3 _axis;

    
    private void OnDrawGizmos()
    {
        Quaternion Qax = GetQuaternion(_axis, Angle);
        Vector3 Vax = new Vector3(Qax.x, Qax.y, Qax.z);
        DrawVector(transform.position, Vax * 10f, Color.yellow);
    }
    
    void Update()
    {
        _axis = Source.transform.localScale;
        transform.rotation *= GetQuaternion(_axis, Angle);
    }

    private Quaternion GetQuaternion(Vector3 axis, float angle)
    {
        Vector3 normolizedAxis = axis.normalized;
        float halfAngle = angle * 0.5f * Mathf.Deg2Rad * Time.deltaTime;

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
}

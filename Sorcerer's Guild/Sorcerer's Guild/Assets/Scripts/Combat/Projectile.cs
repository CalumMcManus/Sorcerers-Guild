using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    private Vector3 m_Target;
    public Vector3 Target { set { m_Target = value; } }
    private Rigidbody m_Body;
    private int m_iSpeed = 15;
    public int Speed { set { m_iSpeed = value; } }

    void Start()
    {
        
        Vector3 vDir = (m_Target - transform.position).normalized;
        StartCoroutine(MoveToPos(vDir));

    }

    private IEnumerator MoveToPos(Vector3 vDir)
    {
        while (Vector3.Distance(transform.position, m_Target) > 1f)
        {
            transform.Translate(vDir*Time.deltaTime*m_iSpeed);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

    
}

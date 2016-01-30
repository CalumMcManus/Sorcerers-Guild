using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    [SerializeField] private Transform m_Target;
    public Transform Target { set { m_Target = value; } }
    private Rigidbody m_Body;
    private int m_iSpeed = 15;
    public int Speed { set { m_iSpeed = value; } }

    void OnEnable()
    {
        m_Body = GetComponent<Rigidbody>();
        StartCoroutine(Follow());
    }

    private IEnumerator Follow()
    {
        while (Vector3.Distance(transform.position, m_Target.position) > 1f)
        {
            Vector3 vDir = (m_Target.position - transform.position).normalized;
            m_Body.velocity = vDir*m_iSpeed;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}

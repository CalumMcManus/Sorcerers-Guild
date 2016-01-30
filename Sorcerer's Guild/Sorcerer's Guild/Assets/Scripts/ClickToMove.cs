using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    private string m_sGroundTag = "Ground";


    private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == m_sGroundTag)
                {
                    m_Agent.SetDestination(hit.point);
                }
            }
        }
    }

}

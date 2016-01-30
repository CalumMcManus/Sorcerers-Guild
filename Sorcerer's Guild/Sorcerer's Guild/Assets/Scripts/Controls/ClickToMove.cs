using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    private string m_sGroundTag = "Ground";


    private NavMeshAgent m_Agent;
    private bool m_bCanMove = true;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && m_bCanMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == m_sGroundTag)
                {
                    m_Agent.SetDestination(hit.point);
                }
            }
        }
    }

    public void ForceMoveTo(Vector3 pos, bool moveAtDest)
    {
        m_bCanMove = false;
        m_Agent.SetDestination(pos);
        if (moveAtDest)
        {
            StartCoroutine(CheckIfAtEndOfPath());
        }
    }

    private IEnumerator CheckIfAtEndOfPath()
    {
        Vector3 endPos = m_Agent.pathEndPosition;
        while (Vector3.Distance(transform.position, endPos) > 0.5f)
        {
            yield return new WaitForEndOfFrame();
        }

        m_bCanMove = true;
    }

}

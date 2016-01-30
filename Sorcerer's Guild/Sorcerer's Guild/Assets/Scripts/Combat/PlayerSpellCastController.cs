using UnityEngine;
using System.Collections;

public class PlayerSpellCastController : MonoBehaviour
{

    [SerializeField] private Projectile m_Projectile;


	void Start () {

	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Projectile projectile = Instantiate(m_Projectile, transform.position, Quaternion.identity) as Projectile;
                projectile.Target = hit.point;
            }  
        }
    }

}

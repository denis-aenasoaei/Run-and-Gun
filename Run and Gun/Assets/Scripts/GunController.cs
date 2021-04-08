
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 50f;

    public Camera fpsCam;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            EnemyScript es = hit.transform.GetComponent<EnemyScript>();
            if(es != null)
            {
                es.TakeDamage(damage);
            }
        }

    }
}

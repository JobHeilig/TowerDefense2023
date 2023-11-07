using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootInterval = 1;

    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (targets.Length == 0)
        {
            return;
        }

        target = targets[0];

        for (int i = 0; i < targets.Length; i++)
        {

        }

        LookAtTarget();

    }

    public void LookAtTarget()
    {
        Vector2 direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            if (target == null)
            {
                yield return new WaitForEndOfFrame();
            } else
            {
                GameObject projectileGameObject = Instantiate(projectilePrefab);
                Projectile projectile = projectileGameObject.GetComponent<Projectile>();
                projectileGameObject.transform.position = transform.position;
                projectile.target = target.transform;

                yield return new WaitForSeconds(shootInterval);
            }
        }
    }


}

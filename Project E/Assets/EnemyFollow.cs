using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    GameObject target;
    NavMeshAgent enemy;
    [SerializeField]
    float distPlayer = 8f;

    public LayerMask playerLayer;
    public LayerMask wallsLayer;

    bool hitWall = false;

    bool didHit = false;

    bool isPlayerDead = false;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player;
    }

    void Update()
    {
        PlayerDetect();
        if(Vector3.Distance(transform.position, target.transform.position) <= enemy.stoppingDistance && !didHit && !isPlayerDead)
        {
            StartCoroutine(EnemyHit());
            didHit = true;
            HitPlayer();
        }
    }


    IEnumerator EnemyHit()
    {
        Debug.Log("Hit");
        yield return new WaitForSeconds(1);
        didHit = false;
    }

    void HitPlayer()
    {
        Ray ray;
        RaycastHit hit;
        Vector3 direction = transform.forward * enemy.stoppingDistance;
        ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hit, enemy.stoppingDistance, playerLayer))
        {
            if(hit.collider.GetComponent<PlayerStats>().playerIsDead)
            {
                isPlayerDead = true;
                return;
            }
            hit.collider.GetComponent<PlayerStats>().playerHealthHP -= 5;
            Debug.DrawRay(transform.position, direction, Color.red);
        }
    }

    void PlayerDetect()
    {
        Ray ray;
        RaycastHit hit;
        for (int i = -40; i < 40; i += 1)
        {
            Vector3 direction = Quaternion.AngleAxis(i, Vector3.up) * transform.forward * distPlayer;
            ray = new Ray(transform.position, direction);
            //Debug.DrawRay(transform.position, direction);
            if (Physics.Raycast(ray, out hit, distPlayer, wallsLayer))
            {
                hitWall = true;
            }
            else if (Physics.Raycast(ray, out hit, distPlayer, playerLayer))
            {
                hitWall = false;
                enemy.SetDestination(target.transform.position);
                transform.LookAt(target.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distPlayer);
    }
}

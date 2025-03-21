using UnityEngine;
using UnityEngine.AI;

public class TDCharater : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private bool isDead;
    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        isDead = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            // ���������ɸ�����������������߼����������ײ�ȣ�
            return;
        }

        // ������ƶ��У�����Ƿ񵽴�Ŀ��
        if (isMoving && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude < 0.01f)
            {
                isMoving = false;
                animator.SetBool("isWalking", false);
            }
        }
    }

    /// <summary>
    /// ͨ�õ��ƶ�������������һ���AI���ɵ���
    /// </summary>
    public void MoveTo(Vector3 destination)
    {
        if (!isDead)
        {
            isMoving = true;
            agent.SetDestination(destination);
            animator.SetBool("isWalking", true);
        }
    }

    public void Attack()
    {
        if (!isDead)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
    }
}

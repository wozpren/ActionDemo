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
            // 已死亡，可根据需求添加死亡后逻辑（如禁用碰撞等）
            return;
        }

        // 如果在移动中，检查是否到达目标
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
    /// 通用的移动函数：无论玩家还是AI都可调用
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

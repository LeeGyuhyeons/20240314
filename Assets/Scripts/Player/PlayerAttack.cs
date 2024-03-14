using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("플레이어 데미지")]
    public int NormalDamage = 10;
    public int SkillsDamage = 30;
    public int DashDamage = 30;

    [Header("공격대상")]
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    /// <summary>
    /// 일반 공격 시 호출될 함수
    /// </summary>
    public void NormalAttack()
    {
        //1. 노멀 타겟의 리스트를 조회합니다.
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        //타겟 리스트 안의 몬스터를 전체 조회합니다
        foreach(var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(NormalDamage, transform.position, 0.5f, 0.5f));
            }
        }
    }

    /// <summary>
    /// 스킬 공겨 시 호출될 함수
    /// </summary>
    public void SkillAttack()
    {
        //1. 스킬 타겟의 리스트를 조회합니다.
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        //2. 리스트 안의 몬스터들을 전체 wh회합니다.
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            //3. 스킬 데미지만큼 데미지를 주며 1초 딜레이 2만큼 pushback
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(NormalDamage, transform.position, 1f, 2f));
            }
        }

    }

    /// <summary>
    /// 대쉬 스킬 사용 시 호출
    /// </summary>
    public void DashAttack()
    {
        //1. 스킬 타겟의 리스트를 조회합니다.
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        //2. 리스트 안의 몬스터들을 전체 조회합니다.
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            //3. 스킬 데미지만큼 데미지를 주며 1초 딜레이 2만큼 pushback
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(DashDamage, transform.position, 1f, 2f));
            }
        }
    }
}

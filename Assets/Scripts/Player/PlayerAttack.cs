using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("�÷��̾� ������")]
    public int NormalDamage = 10;
    public int SkillsDamage = 30;
    public int DashDamage = 30;

    [Header("���ݴ��")]
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    /// <summary>
    /// �Ϲ� ���� �� ȣ��� �Լ�
    /// </summary>
    public void NormalAttack()
    {
        //1. ��� Ÿ���� ����Ʈ�� ��ȸ�մϴ�.
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        //Ÿ�� ����Ʈ ���� ���͸� ��ü ��ȸ�մϴ�
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
    /// ��ų ���� �� ȣ��� �Լ�
    /// </summary>
    public void SkillAttack()
    {
        //1. ��ų Ÿ���� ����Ʈ�� ��ȸ�մϴ�.
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        //2. ����Ʈ ���� ���͵��� ��ü whȸ�մϴ�.
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            //3. ��ų ��������ŭ �������� �ָ� 1�� ������ 2��ŭ pushback
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(NormalDamage, transform.position, 1f, 2f));
            }
        }

    }

    /// <summary>
    /// �뽬 ��ų ��� �� ȣ��
    /// </summary>
    public void DashAttack()
    {
        //1. ��ų Ÿ���� ����Ʈ�� ��ȸ�մϴ�.
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        //2. ����Ʈ ���� ���͵��� ��ü ��ȸ�մϴ�.
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            //3. ��ų ��������ŭ �������� �ָ� 1�� ������ 2��ŭ pushback
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(DashDamage, transform.position, 1f, 2f));
            }
        }
    }
}

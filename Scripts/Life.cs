using System; //Action������ �޾ƾ���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������, ȸ��, ���
/// </summary>
public class Life : MonoBehaviour, IDamage
{
    public float startHp = 100f; // ���� ü��
    public float hp; // ���� ü��
    public bool dead; // ��� ����
    public event Action onDeath; // ����� �ߵ��� �̺�Ʈ

    //ü�� �ʱ�ȭ
    public virtual void OnEnable()
    {
        // ������� ���� ���·� ����
        dead = false;
        // ü���� ���� ü������ �ʱ�ȭ
        hp = startHp;
    }

    /// <summary>
    /// �������� �Դ� ���
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="hitPoint"></param>
    /// <param name="hitNormal"></param>
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        hp -= damage;

        if (hp <= 0 && !dead)
        {
            Die();
        }
    }

    /// <summary>
    /// ü���� ȸ���ϴ� ���
    /// </summary>
    /// <param name="healHealth"></param>
    public virtual void HealingHealth(float healHealth)
    {
        if (dead) return;
        hp += healHealth;
    }

    

    /// <summary>
    /// onDeath �̺�Ʈ �Լ��� �����ϸ� ����, dead = true�� ����
    /// </summary>
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        // Life�� ����ϴ� ��ü���� �ٸ� �޼ҵ���� ���� ������ 
        // ���� �̸����� ���ϰ� �����ų������.
        if (onDeath != null)
        {
            onDeath();
        }

        // ��� ���¸� ������ ����
        dead = true;
    }
}

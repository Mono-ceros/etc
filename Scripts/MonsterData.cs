using UnityEngine;

// ���� ������ �����ͷ� ����� ��ũ���ͺ� ������Ʈ
[CreateAssetMenu(menuName = "Scriptable/MonsterData", fileName = "Monster Data", order = 2)]
public class MonsterData : ScriptableObject
{
    public float health = 100f; // ü��
    public float damage = 20f; // ���ݷ�
    public float speed = 2f; // �̵� �ӵ�
    public float timeBetAttack = 1f; // ���� ����
}

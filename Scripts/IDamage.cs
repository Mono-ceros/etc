using UnityEngine;

/// <summary>
/// ������ �����ֵ� �ѹ��� ȣ���ؼ� ������ ���� �������̽�
/// </summary>
public interface IDamage
{
    //������, ������, ��������
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}

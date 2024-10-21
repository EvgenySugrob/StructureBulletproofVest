using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dintRadius = 0.1f; // ������ �������
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ������ �� ���� � ������ � ����������� Armor
        Armor armor = collision.gameObject.GetComponent<Armor>();
        if (armor != null)
        {
            // �������� ����� ���������
            ContactPoint contact = collision.contacts[0];

            //// ��������� ����������� �����������
            //armor.ApplyDamage(damage);

            // ���� � ����������� ���� �������� � �������� DamageDintShader
            Renderer armorRenderer = armor.GetComponent<Renderer>();
            if (armorRenderer != null && armorRenderer.material != null)
            {
                Material armorMaterial = armorRenderer.material; // �������� ��������
                armorMaterial.SetVector("_HitPosition", contact.point); // ������������� ������� ���������
                armorMaterial.SetFloat("_DintRadius", dintRadius); // ������������� ������ �������
            }

            // ���������� ���� (��� �������� ����� ������ ������)
            Destroy(gameObject);
        }
    }
}

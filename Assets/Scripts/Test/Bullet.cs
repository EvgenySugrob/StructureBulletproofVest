using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dintRadius = 0.1f; // Радиус вмятины
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, попала ли пуля в объект с компонентом Armor
        Armor armor = collision.gameObject.GetComponent<Armor>();
        if (armor != null)
        {
            // Получаем точку попадания
            ContactPoint contact = collision.contacts[0];

            //// Применяем повреждение бронежилету
            //armor.ApplyDamage(damage);

            // Если у бронежилета есть материал с шейдером DamageDintShader
            Renderer armorRenderer = armor.GetComponent<Renderer>();
            if (armorRenderer != null && armorRenderer.material != null)
            {
                Material armorMaterial = armorRenderer.material; // Получаем материал
                armorMaterial.SetVector("_HitPosition", contact.point); // Устанавливаем позицию попадания
                armorMaterial.SetFloat("_DintRadius", dintRadius); // Устанавливаем радиус вмятины
            }

            // Уничтожаем пулю (или добавьте любую другую логику)
            Destroy(gameObject);
        }
    }
}

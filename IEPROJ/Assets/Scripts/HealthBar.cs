using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public bool isInv = false;
    public float invTimer = 1;
    public float invTime = 0;

    public void SetMax(int max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
    public void SetHealth(int damage)
    {
        slider.value = damage;
    }

    public void Hurt()
    {
        isInv = true;
        slider.value--;

        StartCoroutine("Invincible");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isInv && collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(1);

        isInv = false;
    }
}

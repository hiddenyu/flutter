using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterHealth : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void changeHealth(int dmgAmount) {
        curHealth -= dmgAmount;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);

        if (curHealth <= 0) {
            Destroy(gameObject);
        }
    }
}

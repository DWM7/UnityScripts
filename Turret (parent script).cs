using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    public int Health;
    public int Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TakeDamage(int incomingDamage)
    {
        // apply the damage
        Health -= incomingDamage;

        // if the health is less than or equal to 0
        // destroy the game object
        if (Health <= 0)
        {
            //gameObject comes from MonoBehaviour and refers to itself
            // GameObject is a class (ie. variable type)
            // gameObject (lower case g) is a variable that refers to ourselves
            GameObject.Destroy(gameObject);
        }
    }
}

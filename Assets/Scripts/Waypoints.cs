using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;
    public float startHealth = 100f;
    public static float health;

	void Awake () {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
	}

    void Start() {
        health = startHealth;
    }

    void Update() {

    }

    public static void TakeDammage(float amount)
    {
        health -= amount;
        // healthbar.fillAmount = health / startHealth;
        if(health <= 0)
        {
             Debug.Log("FIN DU GAME");
        }
    }

}

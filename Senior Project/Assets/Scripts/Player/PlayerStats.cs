using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public int avalPoints;

	public float health;
	public float maxHealth;
	public float strength;
	public float dexterity;
	public float agility;

	public int protectedHits;

	bool inGrace;
	float graceTimer;

	public Text healthText;
	public Slider healthSlider;

	Rigidbody2D playerRig;

	void Start () {
		avalPoints = 5;
		DontDestroyOnLoad (this.gameObject);
		healthSlider = GameObject.FindGameObjectWithTag ("PlayerUI").transform.Find ("HealthBar").GetComponent<Slider> ();
		healthText = GameObject.FindGameObjectWithTag ("PlayerUI").transform.Find ("HealthBar/HealthText").GetComponent<Text>();
//		maxHealth = health;
//		healthSlider.maxValue = maxHealth;
//		healthText.text = health + " / " + maxHealth;
//		healthSlider.value = health;
	}

	void OnLevelWasLoaded () {
		if (Application.loadedLevel == 1) {
			maxHealth = health;
			healthSlider.maxValue = maxHealth;
			healthText.text = health + " / " + maxHealth;
			healthSlider.value = health;
		}
		playerRig = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (inGrace) {
			graceTimer -= Time.deltaTime;
			if (graceTimer < 0) {
				inGrace = false;
				Physics2D.IgnoreLayerCollision (13, 14, false);
				graceTimer = 1.0f;
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
	}

	public void TakeDamage (float damage) {
		if (!inGrace) {
			inGrace = true;
			Physics2D.IgnoreLayerCollision (13, 14, true);
			GetComponent<SpriteRenderer> ().color = Color.red;

			if (protectedHits > 0)
				protectedHits--;
			else {
				health -= damage;
				healthText.text = health + " / " + maxHealth;
				healthSlider.value = health;
			}

			if (health <= 0) {
				Invoke ("Dead", 3f);
				Destroy (this.gameObject);
			}
		}
	}

	public void TakeKnockBack (Vector3 pos, float knockback) {
		Vector2 direction = transform.position - pos;
		Vector2 force = direction.normalized;
		playerRig.velocity = Vector2.up * 10;
		playerRig.velocity = force * knockback * 3;
	}

	void Dead () {
		Application.LoadLevel (0);
	}

	public void UpdateHealth () {
		healthSlider.value = health;
	}
}
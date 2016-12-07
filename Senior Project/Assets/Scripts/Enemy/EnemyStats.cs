using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float damage;
	public float contactDamage;
	public float knockback;
	public float slashRes;
	public float pierceRes;
	public float smashRes;
	public float knockbackRes;

	public int goldDrop;

	bool inGrace;
	float graceTimer;

	public List<GameObject> itemDrops = new List<GameObject> ();
	public bool dropKey;
	public bool isBoss;
	GameObject player;

	SpriteRenderer rend;
	Rigidbody2D rigBody;

	public Text healthText;
	public Transform healthBar;

	public AudioClip hit;
	public AudioSource audioSource;

	public float healthScale;
	// Use this for initialization
	void Start () {
		maxHealth = health;
		rend = GetComponent<SpriteRenderer> ();
		rigBody = GetComponent<Rigidbody2D> ();
		healthBar = transform.Find ("HealthBar/Foreground").transform;

		maxHealth = health;
		healthScale = transform.Find ("HealthBar/Foreground").localScale.x / maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (inGrace) {
			graceTimer -= Time.deltaTime;
			if (graceTimer < 0) {
				inGrace = false;
				graceTimer = .1f;
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}

		if (health <= 0) {
			ItemDrops ();

			if (dropKey) {
				GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<ExtDoor> ().taskComplete = true;
				GameObject.Find("GameManager/Player UI/TaskImage/TaskText").GetComponent<Text>().text = "Task Complete!";
			}

			if (isBoss) {
				Invoke ("LoadMenu", 5f);
			}

			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().UpdateUI (goldDrop);
			RemovefromLists ();
			Destroy (this.gameObject);
		}
	}

	public void TakeDamage (float slash, float pierce, float smash) {
		if (!inGrace) {
			audioSource.PlayOneShot (hit);
		
			health -= (slash * (1 - slashRes)) + (pierce * (1 - pierceRes)) + (smash * (1 - smashRes));
			GetComponent<SpriteRenderer> ().color = Color.red;
			inGrace = true;
			healthBar.localScale = new Vector3 ((health / maxHealth), 1, 1);
		}
	}

	public void TakeRangedDamage (float damage) {
		if (!inGrace) {
			health -= damage;
			GetComponent<SpriteRenderer> ().color = Color.red;
			inGrace = true;
			healthBar.localScale = new Vector3 ((health / maxHealth), 1, 1);
		}
	}
		
	public void KnockBack (float knockback, Vector3 pos) {
		if (knockback > knockbackRes) {
			Vector2 direction = transform.position - pos;
			Vector2 force = direction.normalized;
			rigBody.velocity = Vector2.up * 20;
			rigBody.velocity = force * knockback * (1 - knockbackRes )* 3;
		}
	}
		
	void RemovefromLists () {
		if (transform.parent.GetComponent<EnemyCounter> () != null) {
			transform.parent.GetComponent<EnemyCounter> ().enemyNum--;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerStats> ().TakeDamage (contactDamage);
			col.gameObject.GetComponent<PlayerStats> ().TakeKnockBack (transform.position, knockback);
		}
	}
		
	void ItemDrops () {
		int num1 = Random.Range (0, itemDrops.Count);
		Instantiate(itemDrops[num1], transform.position, Quaternion.identity);
	}

	void LoadMenu () {
		Application.LoadLevel (0);
	}
}
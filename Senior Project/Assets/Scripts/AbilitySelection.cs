using UnityEngine;
using System.Collections;

public class AbilitySelection : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject characterCanvas;
	public GameObject player;
	public PlayerStats playerStats;

	bool bonusHealth;
	bool extraDefence;
	bool movementSpeed;
	bool damageIncrease;
	
	bool selfHeal;
	bool invincibility;
	bool stopTime;
	bool massDamage;

	//-------------------------------
	bool toChracter;
	Vector3 characterPos = new Vector3 (0,0,-10);
	//-------------------------------

	// Use this for initialization
	void Start () {

	}

	void Update () {
		if (toChracter) {
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, characterPos, 10 * Time.deltaTime);
			if (mainCamera.transform.position == characterPos) {
				toChracter = false;
				characterCanvas.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}


	public void SetActives (string active) {
		if (active == "Self Heal") {
			selfHeal = !selfHeal;
			if (selfHeal) {
				player.gameObject.AddComponent<SelfHeal>(); 
			} else {
				Destroy(player.gameObject.GetComponent<SelfHeal>());
			}
		} else if (active == "Invinc") {
			invincibility = !invincibility;
			if (invincibility) {
				player.gameObject.AddComponent<Invincibility>();
			} else {
				Destroy(player.gameObject.GetComponent<Invincibility>());
			}
		} else if (active == "Stop Time") {
			stopTime = !stopTime;
			if (stopTime) {
				player.gameObject.AddComponent<PauseTime>();
			} else {
				Destroy(player.gameObject.GetComponent<PauseTime>());
			}
		} else if (active == "Mass Damage") {
			massDamage = !massDamage;
			if (massDamage) {
				player.gameObject.AddComponent<MassDamage>();
			} else {
				Destroy(player.gameObject.GetComponent<MassDamage>());
			}
		}
	}
	
	public void SetPassives (string passive) {
		
		if (passive == "Bonus Health") {
			bonusHealth = !bonusHealth;
			if (bonusHealth) {
				playerStats.health += 2;
			} else {
				playerStats.health -= 2;
			}
		} else if (passive == "Extra Defence") {
			extraDefence = !extraDefence;
			if (extraDefence) {
				playerStats.defence += 1;
			} else {
				playerStats.defence -= 1;
			}
		} else if (passive == "Movement Speed") {
			movementSpeed = !movementSpeed;
			if (movementSpeed) {
				playerStats.moveSpeed += 5;
			} else  {
				playerStats.moveSpeed -= 5;
			}
		} else if (passive == "Damage Increase") {
			damageIncrease = !damageIncrease;
			if (damageIncrease) {
				playerStats.meleeDamage += 1;
				playerStats.rangedDamage += 1;
			} else {
				playerStats.meleeDamage -= 1;
				playerStats.rangedDamage -= 1;
			}
		}
	}

	public void LoadLevel () {
		Application.LoadLevel (1);
		player.transform.position = new Vector3 (0f, 0f, -.1f);
		player.transform.localScale = new Vector3 (5f, 5f, 1f);
	}

	public void moveToCharacter () {
		toChracter = true;
	}

	public void ResetBools () {
		bonusHealth = false;
		extraDefence = false;
		movementSpeed = false;
		damageIncrease = false;
		
		selfHeal = false;
		invincibility = false;
		stopTime = false;
		massDamage = false;
	}

}

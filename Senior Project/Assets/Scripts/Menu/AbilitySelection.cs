using UnityEngine;
using System.Collections;

public class AbilitySelection : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject characterCanvas;
	public StatsCanvas statsCanvas;
	public GameObject player;
	public PlayerStats playerStats;
	public int avalPoints;

	bool bonusHealth;
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
			if (avalPoints > 0 || selfHeal) {
				selfHeal = !selfHeal;
				if (selfHeal) {
					player.gameObject.AddComponent<SelfHeal> ();
					avalPoints -= 1;
				} else if (!selfHeal) {
					Destroy (player.gameObject.GetComponent<SelfHeal> ());
					avalPoints += 1;
				}
			}
		} else if (active == "Invinc") {
			if (avalPoints > 0 || invincibility) {
				invincibility = !invincibility;
				if (invincibility && avalPoints > 0) {
					player.gameObject.AddComponent<Invincibility> ();
					avalPoints -= 1;
				} else if (!invincibility) {
					Destroy (player.gameObject.GetComponent<Invincibility> ());
					avalPoints += 1;
				}
			}
		} else if (active == "Stop Time") {
			if (avalPoints > 0 || stopTime) {
				stopTime = !stopTime;
				if (stopTime && avalPoints > 0) {
					player.gameObject.AddComponent<PauseTime> ();
					avalPoints -= 1;

				} else if (!stopTime) {
					Destroy (player.gameObject.GetComponent<PauseTime> ());
					avalPoints += 1;
				}
			}
		} else if (active == "Mass Damage") {
			if (avalPoints > 0 || massDamage) {
				massDamage = !massDamage;
				if (massDamage && avalPoints > 0) {
					player.gameObject.AddComponent<MassDamage> ();
					avalPoints -= 1;
				} else if (!massDamage) {
					Destroy (player.gameObject.GetComponent<MassDamage> ());
					avalPoints += 1;
				}
			}
		}

		statsCanvas.UpdateStats();
	}
	
	public void SetPassives (string passive) {
		
		if (passive == "Bonus Health") {
			if (avalPoints > 0 || bonusHealth) {
				bonusHealth = !bonusHealth;
				if (bonusHealth && avalPoints > 0) {
					playerStats.health += 2;
					avalPoints -= 1;

				} else if (!bonusHealth) {
					playerStats.health -= 2;
					avalPoints += 1;
				}
			}
		} else if (passive == "Movement Speed") {
			if (avalPoints > 0 || movementSpeed) {
				movementSpeed = !movementSpeed;
				if (movementSpeed && avalPoints > 0) {
					playerStats.moveSpeed += .4f;
					avalPoints -= 1;

				} else if (!movementSpeed) {
					playerStats.moveSpeed -= .4f;
					avalPoints += 1;
				}
			}
		} else if (passive == "Damage Increase") {
			if (avalPoints > 0 || damageIncrease) {
				damageIncrease = !damageIncrease;
				if (damageIncrease && avalPoints > 0) {
					playerStats.meleeDamage += 1;
					playerStats.rangedDamage += 1;
					avalPoints -= 1;

				} else if (!damageIncrease) {
					playerStats.meleeDamage -= 1;
					playerStats.rangedDamage -= 1;
					avalPoints += 1;
				}
			}
		}
		statsCanvas.UpdateStats();
	}

	public void LoadLevel () {
		Application.LoadLevel (1);
		player.transform.position = new Vector3 (0f, 0f, -.1f);
		player.transform.localScale = new Vector3 (5f, 5f, 1f);
		player.AddComponent<Rigidbody2D> ();
		player.GetComponent<Rigidbody2D>().freezeRotation = true;
	}

	public void moveToCharacter () {
		toChracter = true;
	}

	public void ResetBools () {
		bonusHealth = false;
		movementSpeed = false;
		damageIncrease = false;
		
		selfHeal = false;
		invincibility = false;
		stopTime = false;
		massDamage = false;
	}

}

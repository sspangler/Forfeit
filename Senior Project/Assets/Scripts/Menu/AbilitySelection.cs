using UnityEngine;
using System.Collections;

public class AbilitySelection : MonoBehaviour {
	
	GameObject mainCamera;
	GameObject characterCanvas;
	StatsCanvas statsCanvas;
	public GameObject player;
	public PlayerController playerCont;
	public PlayerStats playerStats;
	 DifficultyModifier difMod;
	AbilityTracker abilTracker;
	public int availPoints;

	// stat passives
	bool bonusHealth;
	bool movementSpeed;
	bool strengthIncrease;
	bool dexterityIncrease;
	bool agilityIncrease;
	bool doubleJump;
	bool groundDash;
	
	bool selfHeal;
	bool invincibility;
	bool stopTime;
	bool massDamage;

	//-------------------------------
	bool toChracter;
	Vector3 characterPos = new Vector3 (0,0,-10);
	//-------------------------------
	

	void Start () {
		statsCanvas = GameObject.Find ("Stats Canvas").GetComponent<StatsCanvas>();
		difMod = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DifficultyModifier> ();
		abilTracker = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AbilityTracker> ();
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
			if (availPoints > 0 || selfHeal) {
				selfHeal = !selfHeal;
				if (selfHeal) {
					player.gameObject.AddComponent<SelfHeal> ();
					availPoints -= 1;
					abilTracker.abilities.Add (active);
				} else if (!selfHeal) {
					Destroy (player.gameObject.GetComponent<SelfHeal> ());
					availPoints += 1;
					abilTracker.abilities.Remove (active);
				}
			}
		} else if (active == "Invincibility") {
			if (availPoints > 0 || invincibility) {
				invincibility = !invincibility;
				if (invincibility && availPoints > 0) {
					player.gameObject.AddComponent<Invincibility> ();
					availPoints -= 1;
					abilTracker.abilities.Add (active);
				} else if (!invincibility) {
					Destroy (player.gameObject.GetComponent<Invincibility> ());
					availPoints += 1;
					abilTracker.abilities.Remove (active);
				}
			}
		} else if (active == "Mass Damage") {
			if (availPoints > 0 || massDamage) {
				massDamage = !massDamage;
				if (massDamage && availPoints > 0) {
					player.gameObject.AddComponent<MassDamage> ();
					availPoints -= 1;
					abilTracker.abilities.Add (active);
				} else if (!massDamage) {
					Destroy (player.gameObject.GetComponent<MassDamage> ());
					availPoints += 1;
					abilTracker.abilities.Remove (active);
				}
			}
		}

		statsCanvas.UpdateStats();
	}
	
	public void SetPassives (string passive) {
		
		if (passive == "Bonus Max Health") {
			if (availPoints > 0 || bonusHealth) {
				bonusHealth = !bonusHealth;
				if (bonusHealth && availPoints > 0) {
					playerStats.health += 2;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!bonusHealth) {
					playerStats.health -= 2;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Extra Movement Speed") {
			if (availPoints > 0 || movementSpeed) {
				movementSpeed = !movementSpeed;
				if (movementSpeed && availPoints > 0) {
					playerCont.speed += 2;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!movementSpeed) {
					playerCont.speed -= 2;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Added Strength") {
			if (availPoints > 0 || strengthIncrease) {
				strengthIncrease = !strengthIncrease;
				if (strengthIncrease && availPoints > 0) {
					playerStats.strength += 1;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!strengthIncrease) {
					playerStats.strength -= 1;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Added Dexterity") {
			if (availPoints > 0 || dexterityIncrease) {
				dexterityIncrease = !dexterityIncrease;
				if (dexterityIncrease && availPoints > 0) {
					playerStats.dexterity += 1;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!dexterityIncrease) {
					playerStats.dexterity -= 1;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Added Agility") {
			if (availPoints > 0 || agilityIncrease) {
				agilityIncrease = !agilityIncrease;
				if (agilityIncrease && availPoints > 0) {
					playerStats.agility += 1;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!agilityIncrease) {
					playerStats.agility -= 1;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Double Jump") {
			if (availPoints > 0 || doubleJump) {
				doubleJump = !doubleJump;
				if (doubleJump && availPoints > 0) {
					playerCont.amountOfJumps += 1;
					availPoints -= 1;
					abilTracker.abilities.Add (passive);
				} else if (!doubleJump) {
					playerCont.amountOfJumps -= 1;
					availPoints += 1;
					abilTracker.abilities.Remove (passive);
				}
			}
		} else if (passive == "Ground Dash") {
			if (availPoints > 0 || groundDash) {
				groundDash = !groundDash;
				if (groundDash && availPoints > 0) {
					playerStats.agility += 1;
					availPoints -= 1;
					player.gameObject.AddComponent<DashAbility> ();
					abilTracker.abilities.Add (passive);
				} else if (!groundDash) {
					playerStats.agility -= 1;
					availPoints += 1;
					Destroy (player.gameObject.GetComponent<DashAbility> ());
					abilTracker.abilities.Remove (passive);
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
		difMod.InvokeRepeating ("UpDifficulty", difMod.secondsPerDif, difMod.secondsPerDif);

	}

	public void moveToCharacter () {
		toChracter = true;
	}

	public void ResetBools () {
		bonusHealth = false;
		movementSpeed = false;
		strengthIncrease = false;
		
		selfHeal = false;
		invincibility = false;
		stopTime = false;
		massDamage = false;
	}

}

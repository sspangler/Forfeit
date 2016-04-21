using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilitySelection : MonoBehaviour {
	
	GameObject mainCamera;
	GameObject characterCanvas;
	public StatsCanvas statsCanvas;
	public GameObject player;
	public PlayerController playerCont;
	public PlayerStats playerStats;
	DifficultyModifier difMod;
	public AbilityTracker abilTracker;
	public int availPoints;
	public int startpoints;

	// abilities
	bool bonusHealth;
	bool movementSpeed;
	bool strengthIncrease;
	bool dexterityIncrease;
	bool agilityIncrease;
	bool doubleJump;
	bool groundDash;
	
	bool selfHeal;
	bool invincibility;
	bool massDamage;
	

	void Start () {
		//statsCanvas = GameObject.Find ("Stats Canvas").GetComponent<StatsCanvas>();
		//abilTracker = GetComponent<AbilityTracker> ();
	}
	
	public void SetAbilities (GameObject passive) {
		if (passive.name == "Bonus Max Health") {
			if (availPoints > 0 || bonusHealth) {
				bonusHealth = !bonusHealth;
				if (bonusHealth && availPoints > 0) {
					playerStats.health += 25;
					availPoints -= 1;
				} else if (!bonusHealth) {
					playerStats.health -= 25;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Extra Movement Speed") {
			if (availPoints > 0 || movementSpeed) {
				movementSpeed = !movementSpeed;
				if (movementSpeed && availPoints > 0) {
					playerCont.speed += 2;
					availPoints -= 1;
				} else if (!movementSpeed) {
					playerCont.speed -= 2;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Added Strength") {
			if (availPoints > 0 || strengthIncrease) {
				strengthIncrease = !strengthIncrease;
				if (strengthIncrease && availPoints > 0) {
					playerStats.strength += 1;
					availPoints -= 1;
				} else if (!strengthIncrease) {
					playerStats.strength -= 1;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Added Dexterity") {
			if (availPoints > 0 || dexterityIncrease) {
				dexterityIncrease = !dexterityIncrease;
				if (dexterityIncrease && availPoints > 0) {
					playerStats.dexterity += 1;
					availPoints -= 1;
				} else if (!dexterityIncrease) {
					playerStats.dexterity -= 1;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Added Agility") {
			if (availPoints > 0 || agilityIncrease) {
				agilityIncrease = !agilityIncrease;
				if (agilityIncrease && availPoints > 0) {
					playerStats.agility += 1;
					availPoints -= 1;
				} else if (!agilityIncrease) {
					playerStats.agility -= 1;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Double Jump") {
			if (availPoints > 0 || doubleJump) {
				doubleJump = !doubleJump;
				if (doubleJump && availPoints > 0) {
					playerCont.amountOfJumps += 1;
					availPoints -= 1;
				} else if (!doubleJump) {
					playerCont.amountOfJumps -= 1;
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Ground Dash") {
			if (availPoints > 0 || groundDash) {
				groundDash = !groundDash;
				if (groundDash && availPoints > 0) {
					availPoints -= 1;
					player.gameObject.AddComponent<DashAbility> ();
				} else if (!groundDash) {
					availPoints += 1;
					Destroy (player.gameObject.GetComponent<DashAbility> ());
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Self Heal") {
			if (availPoints > 0 || selfHeal) {
				selfHeal = !selfHeal;
				if (selfHeal) {
					player.gameObject.AddComponent<SelfHeal> ();
					availPoints -= 1;
				} else if (!selfHeal) {
					Destroy (player.gameObject.GetComponent<SelfHeal> ());
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Invincibility") {
			if (availPoints > 0 || invincibility) {
				invincibility = !invincibility;
				if (invincibility && availPoints > 0) {
					player.gameObject.AddComponent<Invincibility> ();
					availPoints -= 1;
				} else if (!invincibility) {
					Destroy (player.gameObject.GetComponent<Invincibility> ());
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		} else if (passive.name == "Mass Damage") {
			if (availPoints > 0 || massDamage) {
				massDamage = !massDamage;
				if (massDamage && availPoints > 0) {
					player.gameObject.AddComponent<MassDamage> ();
					availPoints -= 1;
				} else if (!massDamage) {
					Destroy (player.gameObject.GetComponent<MassDamage> ());
					availPoints += 1;
				}
				if (passive.GetComponent<Button> ().image.color != Color.yellow)
					passive.GetComponent<Button> ().image.color = Color.yellow;
				else
					passive.GetComponent<Button> ().image.color = Color.white;
			}
		}

		if (!abilTracker.abilities.Contains (passive.name) && abilTracker.abilities.Count != startpoints) {
			abilTracker.abilities.Add (passive.name);
		} else {
			abilTracker.abilities.Remove (passive.name);
		}

		statsCanvas.UpdateStats();
	}
		

	public void ResetBools () {
		abilTracker.abilities.Clear ();
		bonusHealth = false;
		movementSpeed = false;
		strengthIncrease = false;
		dexterityIncrease = false;
		agilityIncrease = false;
		doubleJump = false;
		groundDash = false;
		selfHeal = false;
		invincibility = false;
		massDamage = false;
	}
}
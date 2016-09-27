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

	public void HeadAbilites (GameObject passive) {
		if (passive.name == "Double Jump") {
			if (availPoints > 0 || doubleJump) {
				doubleJump = !doubleJump;
				if (doubleJump && availPoints > 0) {
					playerCont.amountOfJumps += 1;
				} else if (!doubleJump) {
					playerCont.amountOfJumps -= 1;
				}
			}
		}

		SetAbilities (passive, 0);
	}

	public void ChestAbilites (GameObject passive) {
		if (passive.name == "Bonus Max Health") {
			if (availPoints > 0 || bonusHealth) {
				bonusHealth = !bonusHealth;
				if (bonusHealth && availPoints > 0) {
					playerStats.health += 25;
					playerStats.maxHealth += 25;
				} else if (!bonusHealth) {
					playerStats.health -= 25;
					playerStats.maxHealth += 25;
				}
			}
		}

		SetAbilities (passive, 1);
	}

	public void ArmAbilites (GameObject passive) {
		if (passive.name == "Added Strength") {
			if (availPoints > 0 || strengthIncrease) {
				strengthIncrease = !strengthIncrease;
				if (strengthIncrease && availPoints > 0) {
					playerStats.strength += 1;
				} else if (!strengthIncrease) {
					playerStats.strength -= 1;
				}
			}
		} else if (passive.name == "Added Dexterity") {
			if (availPoints > 0 || dexterityIncrease) {
				dexterityIncrease = !dexterityIncrease;
				if (dexterityIncrease && availPoints > 0) {
					playerStats.dexterity += 1;
				} else if (!dexterityIncrease) {
					playerStats.dexterity -= 1;
				}
			}
		} 

		SetAbilities (passive, 2);
	}

	public void LegAbilites (GameObject passive) {
		if (passive.name == "Extra Movement Speed") {
			if (availPoints > 0 || movementSpeed) {
				movementSpeed = !movementSpeed;
				if (movementSpeed && availPoints > 0) {
					playerCont.speed += 2;
				} else if (!movementSpeed) {
					playerCont.speed -= 2;
				}
			}
		} else if (passive.name == "Added Agility") {
			if (availPoints > 0 || agilityIncrease) {
				agilityIncrease = !agilityIncrease;
				if (agilityIncrease && availPoints > 0) {
					playerStats.agility += 1;
				} else if (!agilityIncrease) {
					playerStats.agility -= 1;
				}
			}
		} else if (passive.name == "Ground Dash") {
			if (availPoints > 0 || groundDash) {
				groundDash = !groundDash;
				if (groundDash && availPoints > 0) {
					player.gameObject.AddComponent<DashAbility> ();
				} else if (!groundDash) {
					Destroy (player.gameObject.GetComponent<DashAbility> ());
				}
			}
		}

		SetAbilities (passive, 3);
	}

	public void MiscAbilites (GameObject passive) {
		if (passive.name == "Self Heal") {
			if (availPoints > 0 || selfHeal) {
				selfHeal = !selfHeal;
				if (selfHeal) {
					player.gameObject.AddComponent<SelfHeal> ();
				} else if (!selfHeal) {
					Destroy (player.gameObject.GetComponent<SelfHeal> ());
				}
			}
		} else if (passive.name == "Invincibility") {
			if (availPoints > 0 || invincibility) {
				invincibility = !invincibility;
				if (invincibility && availPoints > 0) {
					player.gameObject.AddComponent<Invincibility> ();
				} else if (!invincibility) {
					Destroy (player.gameObject.GetComponent<Invincibility> ());
				}
			}
		} else if (passive.name == "Mass Damage") {
			if (availPoints > 0 || massDamage) {
				massDamage = !massDamage;
				if (massDamage && availPoints > 0) {
					player.gameObject.AddComponent<MassDamage> ();
				} else if (!massDamage) {
					Destroy (player.gameObject.GetComponent<MassDamage> ());
				}
			}
		}

		SetAbilities (passive, 4);
	}

	public void SetAbilities (GameObject passive, int num) {

		for (int i = 0; i < passive.transform.parent.childCount; i++) {
			passive.transform.parent.GetChild (i).GetComponent<Button> ().image.color = Color.white;
		}
			
		passive.GetComponent<Button> ().image.color = Color.yellow;

		if (!abilTracker.abilities.Contains (passive.name)) {
			if (abilTracker.abilities[num] == "")
				availPoints -= 1;
			abilTracker.abilities.Insert (num, passive.name);
			abilTracker.abilities.RemoveAt (num + 1);
		} else {
			abilTracker.abilities [num] = "";
			availPoints += 1;
			passive.GetComponent<Button> ().image.color = Color.white;
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
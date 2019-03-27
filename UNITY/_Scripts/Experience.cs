using UnityEngine;
using System.Collections;

/* USAGE
 * Just drop the script onto your character or a manager GameObject. 
 * Now, how you implement it depends on your game. 
 * Just call GainExp(int) from whatever object/action you want to reward your player for. 
 * Dying enemy, found item, destroyed building, you get the idea. 
 * Once the player has accumulated enough experience, LvlUp() is called automatically. 
 * Add whatever cool stuff should happen on level up here. 
 * You know, trumpet sounds, sparkly particles, increase player strength,... 
 * Oh, and don't forget to add a juicy UI experience bar! 
 * Just in case, the progress bar should have a width of x *(vCurrExp/vExpLeft), 
 * with x being the maximum width of the progress bar. 
 */

public class Experience : MonoBehaviour 
{

	//current level
	public int vLevel = 1;
	//current exp amount
	public int vCurrExp = 0;
	//exp amount needed for lvl 1
	public int vExpBase = 10;
	//exp amount left to next levelup
	public int vExpLeft = 10;
	//modifier that increases needed exp each level
	public float vExpMod = 1.15f;

	//vvvvvv USED FOR TESTING FEEL FREE TO DELETE
	void Update () 
	{
		if (Input.GetButtonDown("Jump"))
		{
			GainExp(3);
		}
	}
	//^^^^^^ USED FOR TESTING FEEL FREE TO DELETE

	//leveling methods
	public void GainExp(int e)
	{
		vCurrExp += e;
		if(vCurrExp >= vExpLeft)
		{
			LvlUp();
		}
	}
	void LvlUp()
	{
		vCurrExp -= vExpLeft;
		vLevel++;
		float t = Mathf.Pow(vExpMod, vLevel);
		vExpLeft = (int)Mathf.Floor(vExpBase * t);
	}
}
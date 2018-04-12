using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

/// <summary>
/// To draw damage motion with npc monster.
/// </summary>
public class NpcControl : MonoBehaviour {
    public GameObject slashEffect;
    public GameObject bloodEffect;
    public Slider hpBar;
    public SpriteRenderer idleSprite, attackSprite, damageSprite;
    SpriteRenderer sRender;
	
	float healthPoint = 1f;

    public Element element;


    public int health;
    public int maxHealth;



    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sRender = GetComponent<SpriteRenderer>();
    }

    IEnumerator DoneAttack(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (idleSprite) idleSprite.enabled = true;
        if (attackSprite) attackSprite.enabled = false;
    }

    IEnumerator DoneDamage(float delayTime)
    {
		yield return new WaitForSeconds(delayTime);
        if (idleSprite) idleSprite.enabled = true;
        if (damageSprite) damageSprite.enabled = false;
	}

    IEnumerator DoAttack(float delayTime)
    {
        if (idleSprite) idleSprite.enabled = false;
        if (attackSprite) attackSprite.enabled = true;
        yield return new WaitForSeconds(delayTime);
        GameObject instance = Instantiate(slashEffect) as GameObject;
        instance.transform.parent = transform.parent;
        instance.transform.localPosition = new Vector3(0f, 80f, 0f);
    }

	IEnumerator DoDamage(float delayTime) {
        if (damageSprite) damageSprite.enabled = true;
        if (idleSprite) idleSprite.enabled = false;
		yield return new WaitForSeconds(delayTime);
        GameObject instance = Instantiate(bloodEffect) as GameObject;
        instance.transform.parent = transform.parent;
        if (sRender)
            instance.transform.localPosition = transform.localPosition + new Vector3(0f, 20f, 0f);
        else
            instance.transform.localPosition = transform.localPosition + new Vector3(0f, 100f, 0f);
    }
	
	void SetHealthPoint(float point){
		if (point<0f) point = 1f;
		if (point>1f) point = 1f;
		TweenParms parms = new TweenParms().Prop("sliderValue", point).Ease(EaseType.EaseOutQuart);
		HOTween.To(hpBar, 0.1f, parms );
		healthPoint = point;
	}

	void SetHealthDamage(float damage){
		SetHealthPoint(healthPoint - damage);
	}

	public void Damage(int damageToTake, Element damageElement){
        if (animator) animator.CrossFade("Damage", 0.2f);


        int totalDamage = damageToTake;
        switch (damageElement)
        {
            case Element.WATER:
                if (element == Element.FIRE)
                    totalDamage = damageToTake * 2;
                break;
        }


        health -= totalDamage;
        

        StartCoroutine(DoDamage(0.1f));
		StartCoroutine( DoneDamage(0.1f) );
		SetHealthDamage(0.1f);

        if (health <= 0) Die();
    }

    void Die()
    {
        // Probably destroy the game object or something
    }


    public void Attack()
    {
        if (animator) animator.CrossFade("Attack", 0.2f);
        StartCoroutine(DoAttack(0.5f));
        StartCoroutine(DoneAttack(0.5f));
    }
}


public enum Element
{
    FIRE = 0,
    WATER = 1,
    ELEC = 2,
    MAGNET = 3,
    LENGTH = 4,
}
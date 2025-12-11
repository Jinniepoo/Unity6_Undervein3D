using System.Collections;           
using UnityEngine;                  
using UnityEngine.UI;               
using TMPro;                        

public class SkillCooldown : MonoBehaviour
{
    public Image skillIcon;           
    public Image cooldownMask;        
    public TextMeshProUGUI timerText; 
    public float cooldownDuration = 5f;

    public void StartCooldown()
    {
        skillIcon.color = new Color(1f, 1f, 1f, 0.5f); // Àá½Ã ¾îµÓ°Ô
        cooldownMask.fillAmount = 1f;
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        float timer = cooldownDuration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            cooldownMask.fillAmount = timer / cooldownDuration;

            if (timerText != null)
                timerText.text = Mathf.Ceil(timer).ToString();

            yield return null;
        }

        cooldownMask.fillAmount = 0f;
        skillIcon.color = Color.white; 
        if (timerText != null)
            timerText.text = "";
    }
}

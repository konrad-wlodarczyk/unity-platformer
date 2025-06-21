using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public static StatsMenu Instance;
    public static bool isMenuOpen = false;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private TMP_Text ExperienceValue;
    [SerializeField]
    private TMP_Text MaxHealth;
    [SerializeField]
    private TMP_Text Strength;
    [SerializeField]
    private TMP_Text Agility;
   

    [SerializeField]
    private PlayerData playerData;

    public Player player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isMenuOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }

        ExperienceValue.text = "EXP: " + playerData.experience.ToString();
        MaxHealth.text = "MAX HP: " + playerData.maxHealth.ToString();
        Strength.text = "STRENGTH: " + playerData.maxStrenght.ToString();
        Agility.text = "AGILITY: " + playerData.maxAgility.ToString();
    }

    public void OpenMenu()
    {

        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        player.currentHealth = playerData.maxHealth;
        HealthBar.Instance.SetHealth(player.currentHealth, playerData.maxHealth);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        isMenuOpen = false;
    }

    public void UpgradeHealth()
    {
        playerData.AddHealth();  
        Update();
        HealthBar.Instance.SetHealth(player.currentHealth, playerData.maxHealth);
    }

    public void UpgradeStrength()
    {
        playerData.AddStrength();
        Update();
    }

    public void UpgradeAgility()
    {
        playerData.AddAgility();
        Update();
    }
}
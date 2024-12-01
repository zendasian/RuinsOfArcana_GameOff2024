using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Main_Menu_Manager : MonoBehaviour
{
    public AudioMixer Master_mix;
    public void play_button()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    public void music_Volume_control(float volume)
    {
        Master_mix.SetFloat("Music",  volume);
    }
    public void SFx_Volume_control(float volume)
    {
        Master_mix.SetFloat("Sfx", volume);
    }
    public void Quite_bitton()
    {
        Application.Quit();
    }
    public void Continue_button()
    {
        Audio_Manager.instance.Stop("Reveal_full");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Main_Menu_button()
    {
        SceneManager.LoadScene("MainMenu");
    }



}

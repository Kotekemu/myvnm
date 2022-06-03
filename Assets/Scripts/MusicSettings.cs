using System.Linq;
using Fungus;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Скрипт для настройки звуков и качества графики
/// </summary>
public class MusicSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    /// <summary>
    /// Установка качества графики
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Поставить звук на паузу
    /// </summary>
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    private void Awake()
    {
        var audioSources = FungusManager.Instance.GetComponents<AudioSource>(); // вытаскиваем аудиосоурс самого фангуса
        var mgroup = audioMixer.FindMatchingGroups("Master").First();
        foreach (var audioSource in audioSources) // перестраиваем все аудиосоурсы на наш микшер
        {
            audioSource.outputAudioMixerGroup = mgroup;
        }
        if (!FungusPrefs.HasKey(0, "Volume")) // Проверяем  былили ранее сохранения громкости на стороне клиента (сотовом или десктопе)
        {
            FungusPrefs.SetFloat(0,"Volume", 1f); // если небыло то устанавалием
            FungusPrefs.Save(); //и сохраняем
        }
        audioMixer.SetFloat("volume", FungusPrefs.GetFloat(0,"Volume")); //выставляем ту громкость которая была сохранена у пользователя
    }

    public void SetVolume(float sliderValue)
    {
        Debug.Log(sliderValue);
        var v = -80 + Mathf.Log10(sliderValue) * 100; //хитрая формула... можно менять. 
        FungusPrefs.SetFloat(0,"Volume", v); // устанавливаем на стороне пользователя новые настройки 
        audioMixer.SetFloat("volume", v); //настраиваем микшер
        FungusPrefs.Save(); //сохраняем пользовательские настройки
    }

}

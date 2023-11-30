using Boot;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class ChangeWheel : MonoBehaviour
{
    [SerializeField, Required]
    private CarWheel _firstCarWheel;

    [SerializeField, Required]
    private CarWheel _secondCarWheel;

    [SerializeField]
    private Sprite[] _spritesWheel = new Sprite[3];


    private void Start()
    {
        if (PlayerPrefs.HasKey($"Wheels{gameObject.name}"))
        {
            Debug.Log(_spritesWheel[PlayerPrefs.GetInt($"Wheels{gameObject.name}")]);
            _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[PlayerPrefs.GetInt($"Wheels{gameObject.name}")];
            _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[PlayerPrefs.GetInt($"Wheels{gameObject.name}")];
        }
    }

    [Button("Change wheel")]
    public void SetNewWheel(int indexWheel)
    {
        if (indexWheel >= _spritesWheel.Length)
            throw new System.Exception();

        _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        PlayerPrefs.SetInt($"Wheels{gameObject.name}", indexWheel);
        Debug.Log($"Wheels player: {PlayerPrefs.GetInt($"Wheels{gameObject.name}")}");
    }
}

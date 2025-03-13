// Written by Aaron Williams
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CatalogFilterToggle : Toggle
{
    //TODO make the filters create through code and remove this serialize tag
    [SerializeField]
    private string category;

    private Image backgroundButtonImage;

    public string Category { get => category; set => category = value; }

    protected override void Start()
    {
        base.Start();

        onValueChanged.AddListener(OnToggleChanged);
        backgroundButtonImage = gameObject.GetComponent<Image>();
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            UIUtils.SetTransparency(backgroundButtonImage, 1f);
        }
        else
        {
            UIUtils.SetTransparency(backgroundButtonImage, 0.2f);
        }
    }
}

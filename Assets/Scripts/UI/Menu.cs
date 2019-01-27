using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : SingletonBehaviour<Menu>
{
    // Start is called before the first frame update

    [SerializeField]
    private RectTransform mainMenu;
    public RectTransform MainMenu
    {
        get { return mainMenu; }
    }

    [SerializeField]
    private RectTransform optionMenu;
    public RectTransform OptionMenu
    {
        get { return optionMenu; }
    }

    [SerializeField]
    private RectTransform creditsMenu;
    public RectTransform CreditsMenu
    {
        get { return creditsMenu; }
    }

}

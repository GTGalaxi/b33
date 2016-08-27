using System;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    /// Indicates if this bar will change colour
    [SerializeField]
    private bool lerpColors;

    /// A reference to the content of the bar(the coloured bar)
    [SerializeField]
    private Image content;

    /// A reference to the text on the bar for example. Health: 100
    [SerializeField]
	private Text valueText = null;

    /// This movement speed of the bar
    [SerializeField]
    private float lerpSpeed;

    /// The current fill amount of the bar
    private float fillAmount;

    /// The colour that the bar will have when it is full
    /// This is only in use if lerpColours is enabled
    [SerializeField]
    private Color fullColor;

    /// The colour that the bar will have when it is low
    /// This is only in use if lerpColours is enabled
    [SerializeField]
    private Color lowColor;

    /// Inidcates the max value of the bar, this can reflect the player's max health etc.
    public float MaxValue { get; set; }

    /// A property for setting a the bar's value
    /// It makes sure to update the text on the bar and generete a new fill amount.
    public float Value
    {
        set
        {
			if (!valueText == null) 
			{
				string[] tmp = valueText.text.Split(':');

				valueText.text = value + "/100";
			}
            

            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    void Start()
    {
        if (lerpColors) //Sets the standard colour
        {
            content.color = fullColor;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //Makes sure that handle bar is called.
        HandleBar();

    }
		
    /// Updates the bar
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);

            if (lerpColors) //If we need to lerp our colours
            {   
                //Lerp the colour from full to low
                content.color = Color.Lerp(lowColor, fullColor, fillAmount);
            }
           
        }
    }


    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}

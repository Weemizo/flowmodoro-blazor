using System;

public class SettingsService
{
    private int _customizedBreakTime = 5; // Default value

    public int CustomizedBreakTime
    {
        get { return _customizedBreakTime; }
        set
        {
            if (value > 0)
                _customizedBreakTime = value;
        }
    }
}

using RPG.UI;
using RPG.Units.Extensions;

public interface IFocusable
{
    public string ShowFocusInfo();
    public SideType GetSide()
    {
        return SideType.None;
    }
    public FocusType GetFocusType();
}

using BeatThat.Properties;
namespace BeatThat.Controllers.Buttons
{
    public class LabelButtonText : WrapsTextOn<LabelButton>
	{
		protected override string GetValue (object driven)
		{
			return (driven as LabelButton).labelText;
		}
		protected override void SetValue (object driven, string value)
		{
			(driven as LabelButton).labelText = value;
		}
	}
}



using UnityEngine.Events;

namespace BeatThat.Controllers.Buttons
{
    public interface IButtonView : IView 
	{
		UnityEvent onClicked { get; }

		void SetProperty<T>(string name, T value);
	}
}


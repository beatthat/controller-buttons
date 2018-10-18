using BeatThat.Properties;
using UnityEngine.Events;

namespace BeatThat.Controllers.Buttons
{
    public class LabelButton : Controller<NoModel, IButtonView>, IHasClick
	{
		public const string PROP_LABEL_TEXT = "LabelText";

		public string m_labelText; 

		public UnityEvent onClicked { get { return m_onClicked != null ? m_onClicked: (m_onClicked = new UnityEvent()); } }
		public UnityEvent m_onClicked;

		public string labelText { 
            get { return m_labelText; }
            set
            {
                m_labelText = value;
                this.view.SetProperty(PROP_LABEL_TEXT, this.labelText);
            }
        }

        public bool interactable 
        {
            get {
                return this.hasView ? this.view.interactable : false;
            }
            set {
                if(this.hasView) {
                    this.view.interactable = value;
                }
            }
        }

		override protected void GoController()
		{
			Bind (this.view.onClicked, this.onViewClickedAction);
			this.view.SetProperty (PROP_LABEL_TEXT, this.labelText);
		}

		private UnityAction onViewClickedAction { get { return m_onViewClickedAction != null ? m_onViewClickedAction: (m_onViewClickedAction = this.OnViewClicked); } }

        private UnityAction m_onViewClickedAction;
		private void OnViewClicked()
		{
			this.onClicked.Invoke ();
		}

	}
}


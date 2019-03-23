using UnityEngine;
using UnityEngine.UI;

namespace DigitsNFCToolkit.Samples
{
	public class MessageScreenView: MonoBehaviour
	{
		private Text label;
		private Button cancelButton;
		private Button okButton;
		private bool initialized;

		private void Initialize()
		{
			label = transform.Find("MessageBox/Label").GetComponent<Text>();
			cancelButton = transform.Find("MessageBox/CancelButton").GetComponent<Button>();
			okButton = transform.Find("MessageBox/OKButton").GetComponent<Button>();
		}

		private void Awake()
		{
			if(!initialized) { Initialize(); }
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void SwitchToPendingWrite()
		{
			if(!initialized) { Initialize(); }

			label.text = "Hold the nfc tag against your device to write the NDEF Message";
			cancelButton.gameObject.SetActive(true);
			okButton.gameObject.SetActive(false);
		}

		public void SwitchToWriteResult(string writeResult)
		{
			if(!initialized) { Initialize(); }

			label.text = writeResult;
			cancelButton.gameObject.SetActive(false);
			okButton.gameObject.SetActive(true);
		}
	}
}

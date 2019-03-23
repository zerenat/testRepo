using DigitsNFCToolkit.JSON;
using UnityEngine;

namespace DigitsNFCToolkit
{
	/// <summary>Delegate for OnNFCTagDetected</summary>
	public delegate void OnNFCTagDetected(NFCTag tag);

	/// <summary>Delegate for OnNDEFReadFinished</summary>
	public delegate void OnNDEFReadFinished(NDEFReadResult result);

	/// <summary>Delegate for OnNDEFWriteFinished</summary>
	public delegate void OnNDEFWriteFinished(NDEFWriteResult result);

	/// <summary>Base class for the native nfc functionality for each platform</summary>
	public abstract class NativeNFC: MonoBehaviour
	{
		/// <summary>Event for OnNFCTagDetected</summary>
		protected event OnNFCTagDetected onNFCTagDetected;

		/// <summary>Event for OnNDEFReadFinished</summary>
		protected event OnNDEFReadFinished onNDEFReadFinished;

		/// <summary>Event for OnNDEFWriteFinished</summary>
		protected event OnNDEFWriteFinished onNDEFWriteFinished;

		/// <summary>Event for OnNFCTagDetected</summary>
		public event OnNFCTagDetected NFCTagDetected
		{
			add { onNFCTagDetected += value; }
			remove { onNFCTagDetected -= value; }
		}

		/// <summary>Event for OnNDEFReadFinished</summary>
		public event OnNDEFReadFinished NDEFReadFinished
		{
			add { onNDEFReadFinished += value; }
			remove { onNDEFReadFinished -= value; }
		}

		/// <summary>Event for OnNDEFWriteFinished</summary>
		public event OnNDEFWriteFinished NDEFWriteFinished
		{
			add { onNDEFWriteFinished += value; }
			remove { onNDEFWriteFinished -= value; }
		}

		/// <summary>Initializes this class</summary>
		public abstract void Initialize();

		/// <summary>Checks if NFC Tag Info Read is supported on this device</summary>
		public abstract bool IsNFCTagInfoReadSupported();

		/// <summary>Checks if NDEF Read is supported on this device</summary>
		public abstract bool IsNDEFReadSupported();

		/// <summary>Checks if NDEF Write is supported on this device</summary>
		public abstract bool IsNDEFWriteSupported();

		/// <summary>Enables NFC Reading and Writing</summary>
		public abstract void Enable();

		/// <summary>Disables NFC Reading and Writing</summary>
		public abstract void Disable();

		/// <summary>Start a write request for given NDEF Message</summary>
		public abstract void RequestNDEFWrite(string messageJSON);

		/// <summary>Cancel pending NDEF Message write request (if any)</summary>
		public abstract void CancelNDEFWriteRequest();

		/// <summary>Event callback when a NFC Tag was detected</summary>
		public void OnNFCTagDetected(string tagJSON)
		{
			JSONObject jsonObject = JSONObject.Parse(tagJSON);
			NFCTag tag = new NFCTag(jsonObject);

			if(onNFCTagDetected != null)
			{
				onNFCTagDetected(tag);
			}
		}

		/// <summary>Event callback when a NDEF Message Read request was finished</summary>
		public void OnNDEFReadFinished(string resultJSON)
		{
			JSONObject jsonObject = JSONObject.Parse(resultJSON);
			NDEFReadResult result = new NDEFReadResult(jsonObject);

			if(onNDEFReadFinished != null)
			{
				onNDEFReadFinished(result);
			}
		}

		/// <summary>Event callback when a NDEF Message Write request was finished</summary>
		public void OnNDEFWriteFinished(string resultJSON)
		{
			JSONObject jsonObject = JSONObject.Parse(resultJSON);
			NDEFWriteResult result = new NDEFWriteResult(jsonObject);

			if(onNDEFWriteFinished != null)
			{
				onNDEFWriteFinished(result);
			}
		}
	}
}

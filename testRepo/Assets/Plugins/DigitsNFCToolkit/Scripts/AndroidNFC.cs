#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;

namespace DigitsNFCToolkit
{
	/// <summary>Class for the native nfc functionality on Android</summary>
	public class AndroidNFC: NativeNFC
	{
		private AndroidJavaObject mainClass;

		public override void Initialize()
		{
			mainClass = new AndroidJavaClass("com.apollojourney.nativenfc.NativeNFC");
			mainClass.CallStatic("_initialize", gameObject.name);
		}

		public override bool IsNFCTagInfoReadSupported()
		{
			return mainClass.CallStatic<bool>("_isNFCTagInfoReadSupported");
		}

		public override bool IsNDEFReadSupported()
		{
			return mainClass.CallStatic<bool>("_isNDEFReadSupported");
		}

		public override bool IsNDEFWriteSupported()
		{
			return mainClass.CallStatic<bool>("_isNDEFWriteSupported");
		}

		public override void Enable()
		{
			mainClass.CallStatic("_enable");
		}

		public override void Disable()
		{
			mainClass.CallStatic("_disable");
		}

		public override void RequestNDEFWrite(string messageJSON)
		{
			mainClass.CallStatic("_requestNDEFWrite", messageJSON);
		}

		public override void CancelNDEFWriteRequest()
		{
			mainClass.CallStatic("_cancelNDEFWriteRequest");
		}
	}
}
#endif
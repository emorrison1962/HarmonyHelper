using System;

namespace NeckDiagrams
{
	internal interface IModelProvider
	{
		//event EventHandler<HarmonyModel> ModelChanged;
		HarmonyModel Model { get; }
	}
	internal interface IModelObserver
	{
		void ModelChanged_Handler(object sender, HarmonyModel model);
	}
}
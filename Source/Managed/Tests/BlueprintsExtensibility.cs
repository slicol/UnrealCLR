using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class BlueprintsExtensibility {
		private static Blueprint blueprintActor = Blueprint.Load("/Game/Tests/BlueprintActor");
		private static Blueprint blueprintSceneComponent = Blueprint.Load("/Game/Tests/BlueprintSceneComponent");
		private static Actor actor = new Actor(blueprint: blueprintActor);
		private static SceneComponent sceneComponent = new SceneComponent(actor, blueprint: blueprintSceneComponent);

		public static void OnBeginPlay() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			if (actor.IsSpawned)
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Tomato, "Blueprint actor is spawned!");

			if (sceneComponent.IsCreated)
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Tomato, "Blueprint scene component is created!");

			TestActorBoolProperty();
			TestActorByteProperty();
			TestActorIntProperty();
			TestActorFloatProperty();
			TestActorTextProperty();
			TestSceneComponentBoolProperty();
			TestSceneComponentByteProperty();
			TestSceneComponentIntProperty();
			TestSceneComponentFloatProperty();
			TestSceneComponentTextProperty();
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}

		private static void TestActorBoolProperty() {
			bool value = false;

			Assert.IsTrue(actor.SetBool("TestBool", true));

			if (actor.GetBool("TestBool", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorByteProperty() {
			byte value = 0;

			Assert.IsTrue(actor.SetByte("TestByte", 128));

			if (actor.GetByte("TestByte", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorIntProperty() {
			int value = 0;

			Assert.IsTrue(actor.SetInt("TestInt", 500));

			if (actor.GetInt("TestInt", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorFloatProperty() {
			float value = 0;

			Assert.IsTrue(actor.SetFloat("TestFloat", 250.5f));

			if (actor.GetFloat("TestFloat", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(actor.SetText("TestText", "Test message from managed code"));

			if (actor.GetText("TestText", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestSceneComponentBoolProperty() {
			bool value = false;

			Assert.IsTrue(sceneComponent.SetBool("TestBool", true));

			if (sceneComponent.GetBool("TestBool", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentByteProperty() {
			byte value = 0;

			Assert.IsTrue(sceneComponent.SetByte("TestByte", 128));

			if (sceneComponent.GetByte("TestByte", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentIntProperty() {
			int value = 0;

			Assert.IsTrue(sceneComponent.SetInt("TestInt", 500));

			if (sceneComponent.GetInt("TestInt", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentFloatProperty() {
			float value = 0;

			Assert.IsTrue(sceneComponent.SetFloat("TestFloat", 250.5f));

			if (sceneComponent.GetFloat("TestFloat", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetText("TestText", "Test message from managed code"));

			if (sceneComponent.GetText("TestText", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}
	}

	public static class BlueprintActor {
		public static void OnBeginPlay() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint actor!");
	}

	public static class BlueprintSceneComponent {
		public static void OnBeginPlay() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint scene component!");
	}
}
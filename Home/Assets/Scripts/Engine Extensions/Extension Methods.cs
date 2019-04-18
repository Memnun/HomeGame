using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods {
	
	public static float Map (float inputValue, float inputLow, float inputHigh, float outputLow, float outputHigh) {
		return (inputValue - inputLow) / (inputHigh - inputLow) * (outputHigh - outputLow) + outputLow;
	}
	
}

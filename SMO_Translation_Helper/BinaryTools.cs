using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SMO_Translation_Helper
{
	public enum ByteOrder
	{
		LittleEndian = 0,
		BigEndian = 1
	}

	class QA
	{
		private static readonly Dictionary<byte[], string> tagList = new Dictionary<byte[], string>()
		{
			#region BUTTONS
			// A Button
			{ new byte[] { 14, 0, 6, 0, 2, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0 },
						"_Button_A_" },
			// B Button
			{ new byte[] { 14, 0, 6, 0, 3, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0 },
						"_Button_B_" },
			// X Button
			{ new byte[] { 14, 0, 6, 0, 4, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0 },
						"_Button_X_" },
			// Y Button
			{ new byte[] { 14, 0, 6, 0, 5, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0 },
						"_Button_Y_" },
			
			// L Button
			{ new byte[] { 14, 0, 6, 0, 6, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0 },
						"_Button_L_" },
			// R Button
			{ new byte[] { 14, 0, 6, 0, 7, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0 },
						"_Button_R_" },
			// ZL Button
			{ new byte[] { 14, 0, 6, 0, 8, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0 },
						"_Button_ZL_" },
			// ZR Button
			{ new byte[] { 14, 0, 6, 0, 9, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0 },
						"_Button_ZR_" },
			
			// HOME Button
			{ new byte[] { 14, 0, 9, 0, 21, 0, 4, 0, 0, 0, 244, 224 },
						"_Button_Home_" },
			// Capture Button
			{ new byte[] { 14, 0, 9, 0, 22, 0, 4, 0, 0, 0, 245, 224 },
						"_Button_Screenshot_" },
			// + Button
			{ new byte[] { 14, 0, 6, 0, 29, 0, 70, 0, 20, 0, 77, 0, 101, 0, 110, 0, 117, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 22, 0, 77, 0, 101, 0, 110, 0, 117, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 76, 0, 22, 0, 77, 0, 101, 0, 110, 0, 117, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 82, 0 },
						"_Button_Plus_" },
			// - Button
			{ new byte[] { 14, 0, 6, 0, 30, 0, 64, 0, 18, 0, 77, 0, 97, 0, 112, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 20, 0, 77, 0, 97, 0, 112, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 76, 0, 20, 0, 77, 0, 97, 0, 112, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 82, 0 },
						"_Button_Minus_" },
			// + Button (Second duplicate icon)
			{ new byte[] { 14, 0, 6, 0, 11, 0, 166, 0, 28, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 36, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 34, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 28, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 30, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0 },
						"_Button_Plus_Duplicate_" },
			#endregion

			#region DPAD
			// Directional Pad - Left
			{ new byte[] { 14, 0, 6, 0, 14, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0 },
						"_Dpad_Left_" },
			// Directional Pad - Right
			{ new byte[] { 14, 0, 6, 0, 15, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0 },
						"_Dpad_Right_" },
			// Directional Pad - Right (used only for amiibo descriptions)
			{ new byte[] { 14, 0, 9, 0, 17, 0, 4, 0, 0, 0, 238, 224 },
						"_Dpad_Right_Amiibo_" },
			#endregion

			#region STICKS
			// Left Stick
			{ new byte[] { 14, 0, 6, 0, 16, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0 },
						"_Stick_Left_" },
			// Right Stick
			{ new byte[] { 14, 0, 6, 0, 17, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0 },
						"_Stick_Right_" },			
			// Right Stick - Push
			{ new byte[] { 14, 0, 6, 0, 18, 0, 166, 0, 28, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 36, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 34, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 28, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 30, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0 },
						"_Stick_Right_Push_" },
			// Left Stick - Up and Down
			{ new byte[] { 14, 0, 6, 0, 19, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0 },
						"_Stick_Left_UpDown_" },
			// Right Stick - Left and Right
			{ new byte[] { 14, 0, 6, 0, 20, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0 },
						"_Stick_Right_LeftRight_" },
			#endregion

			#region ICONS
			// Icon - Arrow
			{ new byte[] { 14, 0, 9, 0, 41, 0, 4, 0, 0, 0, 70, 225 },
						"_Icon_Arrow_" },
			// Icon - Album
			{ new byte[] { 14, 0, 9, 0, 42, 0, 4, 0, 0, 0, 52, 225 },
						"_Icon_Album_" },

			// Icon - Coin
			{ new byte[] { 14, 0, 8, 0, 0, 0, 4, 0, 6, 0, 64, 0 },
						"_Icon_Coin_" },
			// Icon - Globe
			{ new byte[] { 14, 0, 8, 0, 1, 0, 4, 0, 6, 0, 65, 0 },
						"_Icon_Globe_" },
			// Icon - Checkpoint Flag
			{ new byte[] { 14, 0, 8, 0, 2, 0, 4, 0, 6, 0, 66, 0 },
						"_Icon_CheckpointFlag_" },
			// Icon - Bowser
			{ new byte[] { 14, 0, 8, 0, 3, 0, 4, 0, 6, 0, 67, 0 },
						"_Icon_Bowser_" },
			// Icon - Princess Peach
			{ new byte[] { 14, 0, 8, 0, 4, 0, 4, 0, 6, 0, 68, 0 },
						"_Icon_PrincessPeach_" },
			// Icon - Tiara
			{ new byte[] { 14, 0, 8, 0, 5, 0, 4, 0, 6, 0, 69, 0 },
						"_Icon_Tiara_" },
			// Icon - Broodals - Rango
			{ new byte[] { 14, 0, 8, 0, 6, 0, 4, 0, 6, 0, 70, 0 },
						"_Icon_Broodals_Rango_" },
			// Icon - Broodals - Spewart
			{ new byte[] { 14, 0, 8, 0, 7, 0, 4, 0, 6, 0, 71, 0 },
						"_Icon_Broodals_Spewart_" },
			// Icon - Broodals - Topper
			{ new byte[] { 14, 0, 8, 0, 8, 0, 4, 0, 6, 0, 72, 0 },
						"_Icon_Broodals_Topper_" },
			// Icon - Broodals - Hariet
			{ new byte[] { 14, 0, 8, 0, 9, 0, 4, 0, 6, 0, 73, 0 },
						"_Icon_Broodals_Hariet_" },
			// Icon - The Oddysey (Mario's airship)
			{ new byte[] { 14, 0, 8, 0, 10, 0, 4, 0, 6, 0, 74, 0 },
						"_Icon_TheOddysey_" },
			// Icon - Frog
			{ new byte[] { 14, 0, 8, 0, 11, 0, 4, 0, 6, 0, 75, 0 },
						"_Icon_Frog_" },
			// Icon - Mario with Cappy
			{ new byte[] { 14, 0, 8, 0, 12, 0, 4, 0, 6, 0, 76, 0 },
						"_Icon_MarioWithCappy_" },
			// Icon - Cappy
			{ new byte[] { 14, 0, 8, 0, 13, 0, 4, 0, 6, 0, 77, 0 },
						"_Icon_Cappy_" },
			// Icon - Mario
			{ new byte[] { 14, 0, 8, 0, 14, 0, 4, 0, 6, 0, 78, 0 },
						"_Icon_Mario_" },
			// Icon - Mayor Pauline
			{ new byte[] { 14, 0, 8, 0, 15, 0, 4, 0, 6, 0, 79, 0 },
						"_Icon_MayorPauline_" },

			// Icon - Regional Coin - Cap Kingdom
			{ new byte[] { 14, 0, 8, 0, 16, 0, 4, 0, 6, 0, 80, 0 },
						"_Icon_RegionalCoin_CapKingdom_" },
			// Icon - Regional Coin - Cascade Kingdom
			{ new byte[] { 14, 0, 8, 0, 17, 0, 4, 0, 6, 0, 81, 0 },
						"_Icon_RegionalCoin_CascadeKingdom_" },
			// Icon - Regional Coin - Sand Kingdom
			{ new byte[] { 14, 0, 8, 0, 18, 0, 4, 0, 6, 0, 82, 0 },
						"_Icon_RegionalCoin_SandKingdom_" },
			// Icon - Regional Coin - Wooded Kingdom
			{ new byte[] { 14, 0, 8, 0, 19, 0, 4, 0, 6, 0, 83, 0 },
						"_Icon_RegionalCoin_WoodedKingdom_" },
			// Icon - Regional Coin - Lake Kingdom
			{ new byte[] { 14, 0, 8, 0, 20, 0, 4, 0, 6, 0, 84, 0 },
						"_Icon_RegionalCoin_LakeKingdom_" },
			// Icon - Regional Coin - Lost Kingdom
			{ new byte[] { 14, 0, 8, 0, 21, 0, 4, 0, 6, 0, 85, 0 },
						"_Icon_RegionalCoin_LostKingdom_" },
			// Icon - Regional Coin - Metro Kingdom
			{ new byte[] { 14, 0, 8, 0, 22, 0, 4, 0, 6, 0, 86, 0 },
						"_Icon_RegionalCoin_MetroKingdom_" },
			// Icon - Regional Coin - Seaside Kingdom
			{ new byte[] { 14, 0, 8, 0, 23, 0, 4, 0, 6, 0, 87, 0 },
						"_Icon_RegionalCoin_SeasideKingdom_" },
			// Icon - Regional Coin - Snow Kingdom
			{ new byte[] { 14, 0, 8, 0, 24, 0, 4, 0, 6, 0, 88, 0 },
						"_Icon_RegionalCoin_SnowKingdom_" },
			// Icon - Regional Coin - Luncheon Kingdom
			{ new byte[] { 14, 0, 8, 0, 25, 0, 4, 0, 6, 0, 89, 0 },
						"_Icon_RegionalCoin_LuncheonKingdom_" },
			// Icon - Regional Coin - Bowser's Kingdom
			{ new byte[] { 14, 0, 8, 0, 26, 0, 4, 0, 6, 0, 90, 0 },
						"_Icon_RegionalCoin_BowsersKingdom_" },
			// Icon - Regional Coin - Moon Kingdom
			{ new byte[] { 14, 0, 8, 0, 27, 0, 4, 0, 6, 0, 91, 0 },
						"_Icon_RegionalCoin_MoonKingdom_" },
			// Icon - Regional Coin - Mushroom Kingdom
			{ new byte[] { 14, 0, 8, 0, 28, 0, 4, 0, 6, 0, 92, 0 },
						"_Icon_RegionalCoin_MushroomKingdom_" },

			// Icon - Binding Band (Wedding Ring)
			{ new byte[] { 14, 0, 8, 0, 29, 0, 4, 0, 6, 0, 96, 0 },
						"_Icon_Binding_Band_" },
			// Icon - Soirée Bouquet
			{ new byte[] { 14, 0, 8, 0, 30, 0, 4, 0, 6, 0, 97, 0 },
						"_Icon_Soiree_Bouquet_" },
			// Icon - Lochlady Dress
			{ new byte[] { 14, 0, 8, 0, 31, 0, 4, 0, 6, 0, 98, 0 },
						"_Icon_Lochlady_Dress_" },
			// Icon - Sparkle Water
			{ new byte[] { 14, 0, 8, 0, 32, 0, 4, 0, 6, 0, 99, 0 },
						"_Icon_Sparkle_Water_" },
			// Icon - Frost-Frosted Cake
			{ new byte[] { 14, 0, 8, 0, 33, 0, 4, 0, 6, 0, 100, 0 },
						"_Icon_FrostFrosted_Cake_" },
			// Icon - Stupendous Stew
			{ new byte[] { 14, 0, 8, 0, 34, 0, 4, 0, 6, 0, 101, 0 },
						"_Icon_Stupendous_Stew_" },
			
			// Icon - Power Moon - Yellow
			{ new byte[] { 14, 0, 8, 0, 35, 0, 4, 0, 6, 0, 112, 0 },
						"_Icon_PowerMoon_Yellow_" },
			// Icon - Power Moon - Brown
			{ new byte[] { 14, 0, 8, 0, 36, 0, 4, 0, 6, 0, 113, 0 },
						"_Icon_PowerMoon_Brown_" },
			// Icon - Power Moon - Blue
			{ new byte[] { 14, 0, 8, 0, 37, 0, 4, 0, 6, 0, 114, 0 },
						"_Icon_PowerMoon_Blue_" },
			// Icon - Power Moon - Red
			{ new byte[] { 14, 0, 8, 0, 38, 0, 4, 0, 6, 0, 115, 0 },
						"_Icon_PowerMoon_Red_" },
			// Icon - Power Moon - Orange
			{ new byte[] { 14, 0, 8, 0, 39, 0, 4, 0, 6, 0, 116, 0 },
						"_Icon_PowerMoon_Orange_" },
			// Icon - Power Moon - Green
			{ new byte[] { 14, 0, 8, 0, 40, 0, 4, 0, 6, 0, 117, 0 },
						"_Icon_PowerMoon_Green_" },
			// Icon - Power Moon - Cyan
			{ new byte[] { 14, 0, 8, 0, 41, 0, 4, 0, 6, 0, 118, 0 },
						"_Icon_PowerMoon_Cyan_" },
			// Icon - Power Moon - Pink
			{ new byte[] { 14, 0, 8, 0, 42, 0, 4, 0, 6, 0, 119, 0 },
						"_Icon_PowerMoon_Pink_" },
			// Icon - Power Moon - Purple
			{ new byte[] { 14, 0, 8, 0, 43, 0, 4, 0, 6, 0, 120, 0 },
						"_Icon_PowerMoon_Purple_" },
			// Icon - Power Moon - White
			{ new byte[] { 14, 0, 8, 0, 44, 0, 4, 0, 6, 0, 121, 0 },
						"_Icon_PowerMoon_White_" },
			// Icon - Power Moon - All
			{ new byte[] { 14, 0, 8, 0, 45, 0, 4, 0, 6, 0, 122, 0 },
						"_Icon_PowerMoon_All_" },
			// Icon - Power Moon - Empty
			{ new byte[] { 14, 0, 8, 0, 46, 0, 4, 0, 6, 0, 123, 0 },
						"_Icon_PowerMoon_Empty_" },
			
			// Icon - Life-Up Heart
			{ new byte[] { 14, 0, 8, 0, 49, 0, 4, 0, 6, 0, 55, 0 },
						"_Icon_LifeUpHeart_" },
			// Icon - Luigi
			{ new byte[] { 14, 0, 8, 0, 51, 0, 4, 0, 6, 0, 57, 0 },
						"_Icon_Luigi_" },
			// Icon - Pointing Arrow for finding Balloon
			{ new byte[] { 14, 0, 8, 0, 52, 0, 4, 0, 6, 0, 58, 0 },
						"_Icon_PointingArrow_" },

			// Icon - Power Moon
			{ new byte[] { 14, 0, 6, 0, 0, 0, 0, 0 },
						"_Icon_PowerMoon_" },
			// Icon - Regional Coin (Purple Coin)
			{ new byte[] { 14, 0, 6, 0, 1, 0, 0, 0},
						"_Icon_RegionalCoin_" },
			#endregion
			
			#region SPECIAL TAGS
			// Tag - Start of yellow color
			{ new byte[] { 14, 0, 0, 0, 3, 0, 2, 0, 1, 0 },
						"_BEGIN_YELLOW_COLOR_" },
			// Tag - End of yellow color
			{ new byte[] { 14, 0, 0, 0, 3, 0, 2, 0, 255, 255 },
						"_END_YELLOW_COLOR_" },
			#endregion

			#region VARIABLES
			// Variable - Coin - Reward - After finding Balloon
			{ new byte[] { 14, 0, 2, 0, 2, 0, 26, 0, 4, 0, 0, 0, 20, 0, 67, 0, 111, 0, 105, 0, 110, 0, 82, 0, 101, 0, 119, 0, 97, 0, 114, 0, 100, 0 },
						"_Icon_Coin_Reward_FindingBalloon_" },
			// Variable - Coin - Paying for finding Balloon
			{ new byte[] { 14, 0, 2, 0, 2, 0, 28, 0, 3, 0, 0, 0, 22, 0, 67, 0, 111, 0, 105, 0, 110, 0, 80, 0, 97, 0, 121, 0, 70, 0, 105, 0, 110, 0, 100, 0 },
						"_Icon_Coin_Paying_FindingBalloon_" },
			// Variable - Coin - Paying for finding Balloon - Retry &#xE;&#x2;&#x2;&amp;&#x3;\0 CoinPayFindRetry
			{ new byte[] { 14, 0, 2, 0, 2, 0, 38, 0, 3, 0, 0, 0, 32, 0, 67, 0, 111, 0, 105, 0, 110, 0, 80, 0, 97, 0, 121, 0, 70, 0, 105, 0, 110, 0, 100, 0, 82, 0, 101, 0, 116, 0, 114, 0, 121, 0 },
						"_Icon_Coin_Paying_FindingBalloon_Retry_" },
			#endregion
		};
		
		private static Encoding fileEncoding = Encoding.Unicode;

		private static string ConvertTags(string rawString, bool beforeExport)
		{
			string processedString = rawString;

			if (beforeExport)
			{
				foreach (var tagListEntry in tagList)
				{
					processedString = processedString.Replace(fileEncoding.GetString(tagListEntry.Key), tagListEntry.Value);
				}
			}
			else
			{
				foreach (var tagListEntry in tagList)
				{
					processedString = processedString.Replace(fileEncoding.GetString(tagListEntry.Key), tagListEntry.Value);
				}
			}

			return processedString;
		}

		public static string CleanBeforeExport(byte[] rawBytes)
		{
			string processedString = fileEncoding.GetString(rawBytes);
			
			// Convert tags from byte form to string form
			processedString = ConvertTags(processedString, true);

			// DOS new lines
			processedString = processedString.Replace("\n", "\r\n");

			// Removed trailing zeros
			processedString = processedString.TrimEnd('\0');

			// Replaced all byte zeros with "\0"
			processedString = processedString.Replace("\0", @"\0");


			return processedString;
		}

		public static byte[] CleanBeforeImport(string rawString)
		{
			string processedString = rawString;
			
			// UNIX new lines
			processedString = processedString.Replace("\r\n", "\n");

			// Replaced all "\0" with byte zeros
			processedString = processedString.Replace(@"\0", "\0");

			// Add a trailing zero
			processedString += "\0";
			
			// Store whole string with converted tags to byte array
			byte[] finalBytes = fileEncoding.GetBytes(ConvertTags(processedString, false));

			return finalBytes;
		}
	}

	class BinaryReaderX : BinaryReader
	{
		public ByteOrder ByteOrder { get; set; }

		public BinaryReaderX(Stream input, ByteOrder byteOrder = ByteOrder.LittleEndian)
			: base(input)
		{
			ByteOrder = byteOrder;
		}

		public override ushort ReadUInt16()
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				return base.ReadUInt16();
			else
				return BitConverter.ToUInt16(base.ReadBytes(2).Reverse().ToArray(), 0);
		}

		public override uint ReadUInt32()
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				return base.ReadUInt32();
			else
				return BitConverter.ToUInt32(base.ReadBytes(4).Reverse().ToArray(), 0);
		}

		public string ReadString(int length)
		{
			return Encoding.ASCII.GetString(ReadBytes(length)).TrimEnd('\0');
		}

		public string PeekString(int length = 4)
		{
			List<byte> bytes = new List<byte>();
			long startOffset = BaseStream.Position;

			for (int i = 0; i < length; i++)
				bytes.Add(ReadByte());

			BaseStream.Seek(startOffset, SeekOrigin.Begin);

			return Encoding.ASCII.GetString(bytes.ToArray());
		}
	}

	class BinaryWriterX : BinaryWriter
	{
		public ByteOrder ByteOrder { get; set; }

		public BinaryWriterX(Stream input, ByteOrder byteOrder = ByteOrder.LittleEndian)
			: base(input)
		{
			ByteOrder = byteOrder;
		}

		public override void Write(ushort value)
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				base.Write(value);
			else
				base.Write(BitConverter.GetBytes(value).Reverse().ToArray());
		}

		public override void Write(uint value)
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				base.Write(value);
			else
				base.Write(BitConverter.GetBytes(value).Reverse().ToArray());
		}

		public void WriteASCII(string value)
		{
			base.Write(Encoding.ASCII.GetBytes(value));
		}
	}
}
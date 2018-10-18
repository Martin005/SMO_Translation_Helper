﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO_Translation_Helper
{
	class QA
	{
		private static readonly Dictionary<byte[], string> tagList = new Dictionary<byte[], string>()
		{
			#region CONTROLLER

			#region SECOND PLAYER
			// Second Player - Left Stick
			{ new byte[] { 14, 0, 6, 0, 27, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0 },
						"{SecondPlayer_Stick_Left}" },
			// Second Player - Right Stick
			{ new byte[] { 14, 0, 6, 0, 28, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0 },
						"{SecondPlayer_Stick_Right}" },
			// Second Player - Y Button
			{ new byte[] { 14, 0, 6, 0, 26, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0 },
						"{SecondPlayer_Button_Y}" },
			#endregion

			#region CONTROLLER ICONS
			// Controller Icon with "Joy-Con" text
			{ new byte[] { 14, 0, 6, 0, 22, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0 },
						"{ControllerIcon}" },
			// Controller Icon - Duplicate
			{ new byte[] { 14, 0, 6, 0, 25, 0, 206, 0, 36, 0, 68, 0, 117, 0, 97, 0, 108, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 73, 0, 99, 0, 111, 0, 110, 0, 79, 0, 110, 0, 108, 0, 121, 0, 44, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 73, 0, 99, 0, 111, 0, 110, 0, 79, 0, 110, 0, 108, 0, 121, 0, 42, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 73, 0, 99, 0, 111, 0, 110, 0, 79, 0, 110, 0, 108, 0, 121, 0, 36, 0, 76, 0, 101, 0, 102, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 73, 0, 99, 0, 111, 0, 110, 0, 79, 0, 110, 0, 108, 0, 121, 0, 38, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 73, 0, 99, 0, 111, 0, 110, 0, 79, 0, 110, 0, 108, 0, 121, 0 },
						"{ControllerIcon_Duplicate}" },
			// Controller Icon - Right Joy-Con with "Joy-Con (R)" text
			{ new byte[] { 14, 0, 6, 0, 23, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 82, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 82, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 82, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 82, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 74, 0, 111, 0, 121, 0, 67, 0, 111, 0, 110, 0, 82, 0 },
						"{ControllerIcon_JoyConRight}" },
			#endregion

			#region BUTTONS
			// A Button
			{ new byte[] { 14, 0, 6, 0, 2, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 65, 0 },
						"{Button_A}" },
			// B Button
			{ new byte[] { 14, 0, 6, 0, 3, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 66, 0 },
						"{Button_B}" },
			// X Button
			{ new byte[] { 14, 0, 6, 0, 4, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 88, 0 },
						"{Button_X}" },
			// Y Button
			{ new byte[] { 14, 0, 6, 0, 5, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 89, 0 },
						"{Button_Y}" },
			
			// L Button
			{ new byte[] { 14, 0, 6, 0, 6, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 76, 0 },
						"{Button_L}" },
			// R Button
			{ new byte[] { 14, 0, 6, 0, 7, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 82, 0 },
						"{Button_R}" },
			// R Button (Used for "Reset" text)
			{ new byte[] { 14, 0, 6, 0, 24, 0, 116, 0, 18, 0, 68, 0, 117, 0, 97, 0, 108, 0, 82, 0, 101, 0, 115, 0, 101, 0, 116, 0, 26, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 82, 0, 101, 0, 115, 0, 101, 0, 116, 0, 24, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 82, 0, 101, 0, 115, 0, 101, 0, 116, 0, 18, 0, 76, 0, 101, 0, 102, 0, 116, 0, 82, 0, 101, 0, 115, 0, 101, 0, 116, 0, 20, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 82, 0, 101, 0, 115, 0, 101, 0, 116, 0 },
						"{Button_R_Reset}" },
			// ZL Button
			{ new byte[] { 14, 0, 6, 0, 8, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 76, 0 },
						"{Button_ZL}" },
			// ZR Button
			{ new byte[] { 14, 0, 6, 0, 9, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 90, 0, 82, 0 },
						"{Button_ZR}" },
			
			// HOME Button
			{ new byte[] { 14, 0, 9, 0, 21, 0, 4, 0, 0, 0, 244, 224 },
						"{Button_Home}" },
			// Capture Button
			{ new byte[] { 14, 0, 9, 0, 22, 0, 4, 0, 0, 0, 245, 224 },
						"{Button_Screenshot}" },
			// Capture Button (Second duplicate icon)
			{ new byte[] { 14, 0, 9, 0, 15, 0, 4, 0, 0, 0, 236, 224 },
						"{Button_Screenshot_Duplicate}" },
			// + Button
			{ new byte[] { 14, 0, 6, 0, 29, 0, 70, 0, 20, 0, 77, 0, 101, 0, 110, 0, 117, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 22, 0, 77, 0, 101, 0, 110, 0, 117, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 76, 0, 22, 0, 77, 0, 101, 0, 110, 0, 117, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 82, 0 },
						"{Button_Plus}" },
			// - Button
			{ new byte[] { 14, 0, 6, 0, 30, 0, 64, 0, 18, 0, 77, 0, 97, 0, 112, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 20, 0, 77, 0, 97, 0, 112, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 76, 0, 20, 0, 77, 0, 97, 0, 112, 0, 80, 0, 108, 0, 97, 0, 121, 0, 101, 0, 114, 0, 82, 0 },
						"{Button_Minus}" },
			// + Button (Second duplicate icon)
			{ new byte[] { 14, 0, 6, 0, 11, 0, 166, 0, 28, 0, 68, 0, 117, 0, 97, 0, 108, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 36, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 34, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 28, 0, 76, 0, 101, 0, 102, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0, 30, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 66, 0, 117, 0, 116, 0, 116, 0, 111, 0, 110, 0, 80, 0, 108, 0, 117, 0, 115, 0 },
						"{Button_Plus_Duplicate}" },
			#endregion

			#region DPAD
			// Directional Pad - Left
			{ new byte[] { 14, 0, 6, 0, 14, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 75, 0, 101, 0, 121, 0, 76, 0, 101, 0, 102, 0, 116, 0 },
						"{Dpad_Left}" },
			// Directional Pad - Right
			{ new byte[] { 14, 0, 6, 0, 15, 0, 146, 0, 24, 0, 68, 0, 117, 0, 97, 0, 108, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 32, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 30, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 24, 0, 76, 0, 101, 0, 102, 0, 116, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 26, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 75, 0, 101, 0, 121, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0 },
						"{Dpad_Right}" },
			// Directional Pad - Right (used only for amiibo descriptions)
			{ new byte[] { 14, 0, 9, 0, 17, 0, 4, 0, 0, 0, 238, 224 },
						"{Dpad_Right_Amiibo}" },
			#endregion

			#region STICKS
			// Left Stick
			{ new byte[] { 14, 0, 6, 0, 16, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0 },
						"{Stick_Left}" },
			// Right Stick
			{ new byte[] { 14, 0, 6, 0, 17, 0, 126, 0, 20, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 28, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 26, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 20, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0, 22, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 82, 0 },
						"{Stick_Right}" },			
			// Right Stick - Push
			{ new byte[] { 14, 0, 6, 0, 18, 0, 166, 0, 28, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 36, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 34, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 28, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0, 30, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 80, 0, 117, 0, 115, 0, 104, 0, 82, 0 },
						"{Stick_Right_Push}" },
			// Left Stick - Up and Down
			{ new byte[] { 14, 0, 6, 0, 19, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 85, 0, 68, 0 },
						"{Stick_Left_UpDown}" },
			// Right Stick - Left and Right
			{ new byte[] { 14, 0, 6, 0, 20, 0, 136, 0, 22, 0, 68, 0, 117, 0, 97, 0, 108, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 30, 0, 72, 0, 97, 0, 110, 0, 100, 0, 104, 0, 101, 0, 108, 0, 100, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 28, 0, 70, 0, 117, 0, 108, 0, 108, 0, 75, 0, 101, 0, 121, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 22, 0, 76, 0, 101, 0, 102, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0, 24, 0, 82, 0, 105, 0, 103, 0, 104, 0, 116, 0, 83, 0, 116, 0, 105, 0, 99, 0, 107, 0, 76, 0, 82, 0 },
						"{Stick_Right_LeftRight}" },
			#endregion

			#endregion

			#region ICONS
			// Icon - Arrow
			{ new byte[] { 14, 0, 9, 0, 41, 0, 4, 0, 0, 0, 70, 225 },
						"{Icon_Arrow}" },
			// Icon - Album
			{ new byte[] { 14, 0, 9, 0, 42, 0, 4, 0, 0, 0, 52, 225 },
						"{Icon_Album}" },

			// Icon - Coin
			{ new byte[] { 14, 0, 8, 0, 0, 0, 4, 0, 6, 0, 64, 0 },
						"{Icon_Coin}" },
			// Icon - Globe
			{ new byte[] { 14, 0, 8, 0, 1, 0, 4, 0, 6, 0, 65, 0 },
						"{Icon_Globe}" },
			// Icon - Checkpoint Flag
			{ new byte[] { 14, 0, 8, 0, 2, 0, 4, 0, 6, 0, 66, 0 },
						"{Icon_CheckpointFlag}" },
			// Icon - Bowser
			{ new byte[] { 14, 0, 8, 0, 3, 0, 4, 0, 6, 0, 67, 0 },
						"{Icon_Bowser}" },
			// Icon - Princess Peach
			{ new byte[] { 14, 0, 8, 0, 4, 0, 4, 0, 6, 0, 68, 0 },
						"{Icon_PrincessPeach}" },
			// Icon - Tiara
			{ new byte[] { 14, 0, 8, 0, 5, 0, 4, 0, 6, 0, 69, 0 },
						"{Icon_Tiara}" },
			// Icon - Broodals - Rango
			{ new byte[] { 14, 0, 8, 0, 6, 0, 4, 0, 6, 0, 70, 0 },
						"{Icon_Broodals_Rango}" },
			// Icon - Broodals - Spewart
			{ new byte[] { 14, 0, 8, 0, 7, 0, 4, 0, 6, 0, 71, 0 },
						"{Icon_Broodals_Spewart}" },
			// Icon - Broodals - Topper
			{ new byte[] { 14, 0, 8, 0, 8, 0, 4, 0, 6, 0, 72, 0 },
						"{Icon_Broodals_Topper}" },
			// Icon - Broodals - Hariet
			{ new byte[] { 14, 0, 8, 0, 9, 0, 4, 0, 6, 0, 73, 0 },
						"{Icon_Broodals_Hariet}" },
			// Icon - The Odyssey (Mario's airship)
			{ new byte[] { 14, 0, 8, 0, 10, 0, 4, 0, 6, 0, 74, 0 },
						"{Icon_TheOdyssey}" },
			// Icon - Frog
			{ new byte[] { 14, 0, 8, 0, 11, 0, 4, 0, 6, 0, 75, 0 },
						"{Icon_Frog}" },
			// Icon - Mario with Cappy
			{ new byte[] { 14, 0, 8, 0, 12, 0, 4, 0, 6, 0, 76, 0 },
						"{Icon_MarioWithCappy}" },
			// Icon - Cappy
			{ new byte[] { 14, 0, 8, 0, 13, 0, 4, 0, 6, 0, 77, 0 },
						"{Icon_Cappy}" },
			// Icon - Mario
			{ new byte[] { 14, 0, 8, 0, 14, 0, 4, 0, 6, 0, 78, 0 },
						"{Icon_Mario}" },
			// Icon - Mayor Pauline
			{ new byte[] { 14, 0, 8, 0, 15, 0, 4, 0, 6, 0, 79, 0 },
						"{Icon_MayorPauline}" },

			// Icon - Regional Coin - Cap Kingdom
			{ new byte[] { 14, 0, 8, 0, 16, 0, 4, 0, 6, 0, 80, 0 },
						"{Icon_RegionalCoin_CapKingdom}" },
			// Icon - Regional Coin - Cascade Kingdom
			{ new byte[] { 14, 0, 8, 0, 17, 0, 4, 0, 6, 0, 81, 0 },
						"{Icon_RegionalCoin_CascadeKingdom}" },
			// Icon - Regional Coin - Sand Kingdom
			{ new byte[] { 14, 0, 8, 0, 18, 0, 4, 0, 6, 0, 82, 0 },
						"{Icon_RegionalCoin_SandKingdom}" },
			// Icon - Regional Coin - Wooded Kingdom
			{ new byte[] { 14, 0, 8, 0, 19, 0, 4, 0, 6, 0, 83, 0 },
						"{Icon_RegionalCoin_WoodedKingdom}" },
			// Icon - Regional Coin - Lake Kingdom
			{ new byte[] { 14, 0, 8, 0, 20, 0, 4, 0, 6, 0, 84, 0 },
						"{Icon_RegionalCoin_LakeKingdom}" },
			// Icon - Regional Coin - Lost Kingdom
			{ new byte[] { 14, 0, 8, 0, 21, 0, 4, 0, 6, 0, 85, 0 },
						"{Icon_RegionalCoin_LostKingdom}" },
			// Icon - Regional Coin - Metro Kingdom
			{ new byte[] { 14, 0, 8, 0, 22, 0, 4, 0, 6, 0, 86, 0 },
						"{Icon_RegionalCoin_MetroKingdom}" },
			// Icon - Regional Coin - Seaside Kingdom
			{ new byte[] { 14, 0, 8, 0, 23, 0, 4, 0, 6, 0, 87, 0 },
						"{Icon_RegionalCoin_SeasideKingdom}" },
			// Icon - Regional Coin - Snow Kingdom
			{ new byte[] { 14, 0, 8, 0, 24, 0, 4, 0, 6, 0, 88, 0 },
						"{Icon_RegionalCoin_SnowKingdom}" },
			// Icon - Regional Coin - Luncheon Kingdom
			{ new byte[] { 14, 0, 8, 0, 25, 0, 4, 0, 6, 0, 89, 0 },
						"{Icon_RegionalCoin_LuncheonKingdom}" },
			// Icon - Regional Coin - Bowser's Kingdom
			{ new byte[] { 14, 0, 8, 0, 26, 0, 4, 0, 6, 0, 90, 0 },
						"{Icon_RegionalCoin_BowsersKingdom}" },
			// Icon - Regional Coin - Moon Kingdom
			{ new byte[] { 14, 0, 8, 0, 27, 0, 4, 0, 6, 0, 91, 0 },
						"{Icon_RegionalCoin_MoonKingdom}" },
			// Icon - Regional Coin - Mushroom Kingdom
			{ new byte[] { 14, 0, 8, 0, 28, 0, 4, 0, 6, 0, 92, 0 },
						"{Icon_RegionalCoin_MushroomKingdom}" },

			// Icon - Binding Band (Wedding Ring)
			{ new byte[] { 14, 0, 8, 0, 29, 0, 4, 0, 6, 0, 96, 0 },
						"{Icon_Binding_Band}" },
			// Icon - Soirée Bouquet
			{ new byte[] { 14, 0, 8, 0, 30, 0, 4, 0, 6, 0, 97, 0 },
						"{Icon_Soiree_Bouquet}" },
			// Icon - Lochlady Dress
			{ new byte[] { 14, 0, 8, 0, 31, 0, 4, 0, 6, 0, 98, 0 },
						"{Icon_Lochlady_Dress}" },
			// Icon - Sparkle Water
			{ new byte[] { 14, 0, 8, 0, 32, 0, 4, 0, 6, 0, 99, 0 },
						"{Icon_Sparkle_Water}" },
			// Icon - Frost-Frosted Cake
			{ new byte[] { 14, 0, 8, 0, 33, 0, 4, 0, 6, 0, 100, 0 },
						"{Icon_FrostFrosted_Cake}" },
			// Icon - Stupendous Stew
			{ new byte[] { 14, 0, 8, 0, 34, 0, 4, 0, 6, 0, 101, 0 },
						"{Icon_Stupendous_Stew}" },
			
			// Icon - Power Moon - Yellow
			{ new byte[] { 14, 0, 8, 0, 35, 0, 4, 0, 6, 0, 112, 0 },
						"{Icon_PowerMoon_Yellow}" },
			// Icon - Power Moon - Brown
			{ new byte[] { 14, 0, 8, 0, 36, 0, 4, 0, 6, 0, 113, 0 },
						"{Icon_PowerMoon_Brown}" },
			// Icon - Power Moon - Blue
			{ new byte[] { 14, 0, 8, 0, 37, 0, 4, 0, 6, 0, 114, 0 },
						"{Icon_PowerMoon_Blue}" },
			// Icon - Power Moon - Red
			{ new byte[] { 14, 0, 8, 0, 38, 0, 4, 0, 6, 0, 115, 0 },
						"{Icon_PowerMoon_Red}" },
			// Icon - Power Moon - Orange
			{ new byte[] { 14, 0, 8, 0, 39, 0, 4, 0, 6, 0, 116, 0 },
						"{Icon_PowerMoon_Orange}" },
			// Icon - Power Moon - Green
			{ new byte[] { 14, 0, 8, 0, 40, 0, 4, 0, 6, 0, 117, 0 },
						"{Icon_PowerMoon_Green}" },
			// Icon - Power Moon - Cyan
			{ new byte[] { 14, 0, 8, 0, 41, 0, 4, 0, 6, 0, 118, 0 },
						"{Icon_PowerMoon_Cyan}" },
			// Icon - Power Moon - Pink
			{ new byte[] { 14, 0, 8, 0, 42, 0, 4, 0, 6, 0, 119, 0 },
						"{Icon_PowerMoon_Pink}" },
			// Icon - Power Moon - Purple
			{ new byte[] { 14, 0, 8, 0, 43, 0, 4, 0, 6, 0, 120, 0 },
						"{Icon_PowerMoon_Purple}" },
			// Icon - Power Moon - White
			{ new byte[] { 14, 0, 8, 0, 44, 0, 4, 0, 6, 0, 121, 0 },
						"{Icon_PowerMoon_White}" },
			// Icon - Power Moon - All
			{ new byte[] { 14, 0, 8, 0, 45, 0, 4, 0, 6, 0, 122, 0 },
						"{Icon_PowerMoon_All}" },
			// Icon - Power Moon - Empty
			{ new byte[] { 14, 0, 8, 0, 46, 0, 4, 0, 6, 0, 123, 0 },
						"{Icon_PowerMoon_Empty}" },
			
			// Icon - Rank Star in finding Balloon
			{ new byte[] { 14, 0, 8, 0, 47, 0, 4, 0, 6, 0, 53, 0 },
						"{Icon_BalloonFinding_RankStar}" },
			// Icon - Life-Up Heart
			{ new byte[] { 14, 0, 8, 0, 49, 0, 4, 0, 6, 0, 55, 0 },
						"{Icon_LifeUpHeart}" },
			// Icon - Luigi
			{ new byte[] { 14, 0, 8, 0, 51, 0, 4, 0, 6, 0, 57, 0 },
						"{Icon_Luigi}" },
			// Icon - Pointing Arrow for finding Balloon
			{ new byte[] { 14, 0, 8, 0, 52, 0, 4, 0, 6, 0, 58, 0 },
						"{Icon_BalloonFinding_PointingArrow}" },

			// Icon - Power Moon
			{ new byte[] { 14, 0, 6, 0, 0, 0, 0, 0 },
						"{Icon_PowerMoon}" },
			// Icon - Regional Coin (Purple Coin)
			{ new byte[] { 14, 0, 6, 0, 1, 0, 0, 0},
						"{Icon_RegionalCoin}" },
			#endregion
			
			#region SPECIAL TAGS
			// Tag - Start of yellow color
			{ new byte[] { 14, 0, 0, 0, 3, 0, 2, 0, 1, 0 },
						"{BEGIN_YELLOW_COLOR}" },
			// Tag - End of yellow color
			{ new byte[] { 14, 0, 0, 0, 3, 0, 2, 0, 255, 255 },
						"{END_YELLOW_COLOR}" },
			// Tag - Show a new dialog screen
			{ new byte[] { 14, 0, 0, 0, 4, 0, 0, 0 },
						"{SHOW_NEW_DIALOG_SCREEN}" },
			// Tag - Pause scrolling text for half a second
			{ new byte[] { 14, 0, 1, 0, 0, 0, 4, 0, 30, 0, 0, 0 },
						"{PAUSE_SCROLLING_TEXT}" },
			// Tag - Show following text on a "ribbon"
			{ new byte[] { 14, 0, 1, 0, 1, 0, 4, 0, 0, 0, 32, 65 },
						"{SHOW_TEXT_ON_RIBBON}" },
			// Tag - Show following text as visually "jumping"
			{ new byte[] { 14, 0, 3, 0, 4, 0, 0, 0 },
						"{SHOW_JUMPING_TEXT}" },
			// Tag - Show following text as visually "shaking"
			{ new byte[] { 14, 0, 4, 0, 0, 0, 22, 0, 20, 0, 82, 0, 101, 0, 115, 0, 117, 0, 108, 0, 116, 0, 82, 0, 111, 0, 108, 0, 108, 0 },
						"{SHOW_SHAKING_TEXT}" },
			#endregion

			#region VARIABLES
			// Variable - Balloon World - Play count of a balloon you hid
			{ new byte[] { 14, 0, 2, 0, 0, 0, 24, 0, 6, 0, 0, 0, 18, 0, 80, 0, 108, 0, 97, 0, 121, 0, 67, 0, 111, 0, 117, 0, 110, 0, 116, 0 },
						"{Variable_BalloonWorld_PlayCountOfBalloon}" },
			// Variable - Balloon World - Coin - Reward - People searching
			{ new byte[] { 14, 0, 2, 0, 2, 0, 20, 0, 6, 0, 0, 0, 14, 0, 67, 0, 111, 0, 105, 0, 110, 0, 78, 0, 117, 0, 109, 0 },
						"{Variable_BalloonWorld_Coin_Reward_PeopleSearching}" },
			// Variable - Balloon World - Coin - Reward - After finding Balloon
			{ new byte[] { 14, 0, 2, 0, 2, 0, 26, 0, 4, 0, 0, 0, 20, 0, 67, 0, 111, 0, 105, 0, 110, 0, 82, 0, 101, 0, 119, 0, 97, 0, 114, 0, 100, 0 },
						"{Variable_BalloonWorld_Coin_Reward_FindingBalloon}" },
			// Variable - Balloon World - Coin - Paying for finding Balloon
			{ new byte[] { 14, 0, 2, 0, 2, 0, 28, 0, 3, 0, 0, 0, 22, 0, 67, 0, 111, 0, 105, 0, 110, 0, 80, 0, 97, 0, 121, 0, 70, 0, 105, 0, 110, 0, 100, 0 },
						"{Variable_BalloonWorld_Coin_Paying_FindingBalloon}" },
			// Variable - Balloon World - Coin - Paying for finding Balloon - Duplicate
			{ new byte[] { 14, 0, 2, 0, 2, 0, 28, 0, 2, 0, 0, 0, 22, 0, 67, 0, 111, 0, 105, 0, 110, 0, 80, 0, 97, 0, 121, 0, 70, 0, 105, 0, 110, 0, 100, 0 },
						"{Variable_BalloonWorld_Coin_Paying_FindingBalloon_Duplicate}" },
			// Variable - Balloon World - Coin - Paying for finding Balloon - Retry
			{ new byte[] { 14, 0, 2, 0, 2, 0, 38, 0, 3, 0, 0, 0, 32, 0, 67, 0, 111, 0, 105, 0, 110, 0, 80, 0, 97, 0, 121, 0, 70, 0, 105, 0, 110, 0, 100, 0, 82, 0, 101, 0, 116, 0, 114, 0, 121, 0 },
						"{Variable_BalloonWorld_Coin_Paying_FindingBalloon_Retry}" },
			// Variable - Balloon World - Coin - Paying for finding Balloon - Retry - Duplicate
			{ new byte[] { 14, 0, 2, 0, 2, 0, 24, 0, 3, 0, 0, 0, 18, 0, 82, 0, 101, 0, 116, 0, 114, 0, 121, 0, 67, 0, 111, 0, 105, 0, 110, 0 },
						"{Variable_BalloonWorld_Coin_Paying_FindingBalloon_Retry_Duplicate}" },

			// Variable - Picture Match - Score - Score to success
			{ new byte[] { 14, 0, 2, 0, 0, 0, 30, 0, 3, 0, 0, 0, 24, 0, 83, 0, 117, 0, 99, 0, 99, 0, 101, 0, 115, 0, 115, 0, 83, 0, 99, 0, 111, 0, 114, 0, 101, 0 },
						"{Variable_PictureMatch_ScoreToSuccess}" },
			// Variable - Picture Match - Score - Achieved score
			{ new byte[] { 14, 0, 4, 0, 0, 0, 24, 0, 22, 0, 82, 0, 101, 0, 115, 0, 117, 0, 108, 0, 116, 0, 83, 0, 99, 0, 111, 0, 114, 0, 101, 0 },
						"{Variable_PictureMatch_AchievedScore}" },


			// Variable - Score/Moon counter
			{ new byte[] { 14, 0, 2, 0, 0, 0, 16, 0, 3, 0, 0, 0, 10, 0, 83, 0, 99, 0, 111, 0, 114, 0, 101, 0 },
						"{Variable_ScoreMoon_Counter}" },
			// Variable - Moon - Norma (?)
			{ new byte[] { 14, 0, 2, 0, 0, 0, 16, 0, 3, 0, 0, 0, 10, 0, 78, 0, 111, 0, 114, 0, 109, 0, 97, 0 },
						"{Variable_Moon_Norma}" },

			// Variable - World Name (Balloon minigame descriptions)
			{ new byte[] { 14, 0, 5, 0, 2, 0, 12, 0 },
						"{Variable_Name_World}" },
			// Variable - Bonus World Name
			{ new byte[] { 14, 0, 5, 0, 2, 0, 22, 0, 20, 0, 66, 0, 111, 0, 110, 0, 117, 0, 115, 0, 87, 0, 111, 0, 114, 0, 108, 0, 100, 0 },
						"{Variable_Name_BonusWorld}" },
			// Variable - Moon Name
			{ new byte[] { 14, 0, 5, 0, 5, 0, 18, 0, 16, 0, 77, 0, 111, 0, 111, 0, 110, 0, 78, 0, 97, 0, 109, 0, 101, 0 },
						"{Variable_Name_Moon}" },
			// Variable - Minigame Name
			{ new byte[] { 14, 0, 5, 0, 6, 0, 26, 0, 24, 0, 77, 0, 105, 0, 110, 0, 105, 0, 103, 0, 97, 0, 109, 0, 101, 0, 78, 0, 97, 0, 109, 0, 101, 0 },
						"{Variable_Name_Minigame}" },
			// Variable - Achievement Name
			{ new byte[] { 14, 0, 5, 0, 9, 0, 32, 0, 30, 0, 65, 0, 99, 0, 104, 0, 105, 0, 101, 0, 118, 0, 101, 0, 109, 0, 101, 0, 110, 0, 116, 0, 78, 0, 97, 0, 109, 0, 101, 0 },
						"{Variable_Name_Achievement}" },

			// Variable - Amiibo Name - New
			{ new byte[] { 14, 0, 5, 0, 3, 0, 12, 0, 10, 0, 84, 0, 111, 0, 117, 0, 99, 0, 104, 0 },
						"{Variable_Name_Amiibo_New}" },
			// Variable - Amiibo Name - First
			{ new byte[] { 14, 0, 5, 0, 3, 0, 12, 0, 10, 0, 70, 0, 105, 0, 114, 0, 115, 0, 116, 0 },
						"{Variable_Name_Amiibo_First}" },
			// Variable - Amiibo Name - Second
			{ new byte[] { 14, 0, 5, 0, 3, 0, 14, 0, 12, 0, 83, 0, 101, 0, 99, 0, 111, 0, 110, 0, 100, 0 },
						"{Variable_Name_Amiibo_Second}" },
			// Variable - Amiibo Name - Third
			{ new byte[] { 14, 0, 5, 0, 3, 0, 12, 0, 10, 0, 84, 0, 104, 0, 105, 0, 114, 0, 100, 0 },
						"{Variable_Name_Amiibo_Third}" },
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
					processedString = processedString.Replace(tagListEntry.Value, fileEncoding.GetString(tagListEntry.Key));
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
}

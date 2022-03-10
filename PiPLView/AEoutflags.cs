using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPLInfo
{
	public class AEoutflags
	{
		static public readonly string[] PF_OutFlag = new string[]
		{
			"PF_OutFlag_KEEP_RESOURCE_OPEN",//0
			"PF_OutFlag_WIDE_TIME_INPUT",//1
			"PF_OutFlag_NON_PARAM_VARY",//2
			"PF_OutFlag_RESERVED6",//3
			"PF_OutFlag_SEQUENCE_DATA_NEEDS_FLATTENING",//4
			"PF_OutFlag_I_DO_DIALOG",//5
			"PF_OutFlag_USE_OUTPUT_EXTENT",//6
			"PF_OutFlag_SEND_DO_DIALOG",//7
			"PF_OutFlag_DISPLAY_ERROR_MESSAGE",//8
			"PF_OutFlag_I_EXPAND_BUFFER",//9
			"PF_OutFlag_PIX_INDEPENDENT",//10
			"PF_OutFlag_I_WRITE_INPUT_BUFFER",//11
			"PF_OutFlag_I_SHRINK_BUFFER",//12
			"PF_OutFlag_WORKS_IN_PLACE",//13
			"PF_OutFlag_RESERVED8",//14
			"PF_OutFlag_CUSTOM_UI",//15
			"PF_OutFlag_RESERVED7",//16
			"PF_OutFlag_REFRESH_UI",//17
			"PF_OutFlag_NOP_RENDER",//18
			"PF_OutFlag_I_USE_SHUTTER_ANGLE",//19
			"PF_OutFlag_I_USE_AUDIO",//20
			"PF_OutFlag_I_AM_OBSOLETE",//21
			"PF_OutFlag_FORCE_RERENDER",//22
			"PF_OutFlag_PiPL_OVERRIDES_OUTDATA_OUTFLAGS",//23
			"PF_OutFlag_I_HAVE_EXTERNAL_DEPENDENCIES",//24
			"PF_OutFlag_DEEP_COLOR_AWARE(16bit対応)",//25
			"PF_OutFlag_SEND_UPDATE_PARAMS_UI",//26
			"PF_OutFlag_AUDIO_FLOAT_ONLY",//27
			"PF_OutFlag_AUDIO_IIR",//28
			"PF_OutFlag_I_SYNTHESIZE_AUDIO",//29
			"PF_OutFlag_AUDIO_EFFECT_TOO",//30
			"PF_OutFlag_AUDIO_EFFECT_ONLY"//31
		};
		static public readonly string[] PF_OutFlag2 = new string[]
		{
			"PF_OutFlag2_SUPPORTS_QUERY_DYNAMIC_FLAGS",//0
			"PF_OutFlag2_I_USE_3D_CAMERA",//1
			"PF_OutFlag2_I_USE_3D_LIGHTS",//2
			"PF_OutFlag2_PARAM_GROUP_START_COLLAPSED_FLAG",//3
			"PF_OutFlag2_I_AM_THREADSAFE",//4
			"PF_OutFlag2_CAN_COMBINE_WITH_DESTINATION",//5
			"PF_OutFlag2_DOESNT_NEED_EMPTY_PIXELS",//6
			"PF_OutFlag2_REVEALS_ZERO_ALPHA",//7
			"PF_OutFlag2_PRESERVES_FULLY_OPAQUE_PIXELS",//8
			"secret",//9
			"PF_OutFlag2_SUPPORTS_SMART_RENDER(SmartFX対応)",//10
			"PF_OutFlag2_RESERVED9",//11
			"PF_OutFlag2_FLOAT_COLOR_AWARE(32bit対応)",//12
			"PF_OutFlag2_I_USE_COLORSPACE_ENUMERATION",//13
			"PF_OutFlag2_I_AM_DEPRECATED",//14
			"PF_OutFlag2_PPRO_DO_NOT_CLONE_SEQUENCE_DATA_FOR_RENDER",//15
			"PF_OutFlag2_RESERVED10",//16
			"PF_OutFlag2_AUTOMATIC_WIDE_TIME_INPUT",//17
			"PF_OutFlag2_I_USE_TIMECODE",//18
			"PF_OutFlag2_DEPENDS_ON_UNREFERENCED_MASKS",//19
			"PF_OutFlag2_OUTPUT_IS_WATERMARKED",//20
			"PF_OutFlag2_I_MIX_GUID_DEPENDENCIES",//21
			"PF_OutFlag2_AE13_5_THREADSAFE",//22
			"PF_OutFlag2_SUPPORTS_GET_FLATTENED_SEQUENCE_DATA",//23
			"PF_OutFlag2_CUSTOM_UI_ASYNC_MANAGER",//24
			"PF_OutFlag2_SUPPORTS_GPU_RENDER_F32",//25
			"PF_OutFlag2_RESERVED12",//26
			"PF_OutFlag2_SUPPORTS_THREADED_RENDERING(マルチフレームレンダリング対応)",//27
			"PF_OutFlag2_MUTABLE_RENDER_SEQUENCE_DATA_SLOWER"//28
		};



		// ********************************************************************************************************************
		public AEoutflags()
		{
		}
		static public string flg0(int v)
		{
			string ret = "";

			for (int i=0; i<PF_OutFlag.Length;i++)
			{
				if ( (( v >> i)&1)==1)
				{
					ret += PF_OutFlag[i]+"\r\n";
				}
			}
			return ret;

		}
		static public string flg2(int v)
		{
			string ret = "";

			for (int i = 0; i < PF_OutFlag2.Length; i++)
			{
				if (((v >> i) & 1) == 1)
				{
					ret += PF_OutFlag2[i] + "\r\n";
				}
			}
			return ret;

		}
	}
}


// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "RayData2.0/Run"
{
	Properties
	{
		[HDR]_EmissionColor("EmissionColor", Color) = (1,1,1,1)
		_EmissionTex("EmissionTex", 2D) = "white" {}
		_EmissionTex_U_Speed("EmissionTex_U_Speed", Float) = 0
		_EmissionTex_V_Speed("EmissionTex_V_Speed", Float) = 0
		[Header(Global_Opacity)]_Global_Opacity("Global_Opacity", Range( 0 , 1)) = 1
		[Toggle]_Fade_Button("Fade_Button", Float) = 0
		_Fade_Distance("Fade_Distance", Range( 0.1 , 1000)) = 500
		_FadeValue("FadeValue【渐变区域】", Range( -0.5 , 0)) = -0.25
		[Enum(UnityEngine.Rendering.CullMode)][Header(Advanced)]_CullMode("CullMode(default is Back)", Float) = 0
		[Enum(Off,0,On,1)]_ZWriteMode("ZWriteMode(default is On)", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)]_ZTestMode("ZTestMode(default is LessEqual)", Float) = 4
		[Enum(Alpha_Blend,5,Addtive,1)][Header(...............................Blend Mode...........................)]_BlendMode_Src("BlendMode_Src", Float) = 5
		[Enum(Alpha_Blend,10,Addtive,1)]_BlendMode_Dst("BlendMode_Dst", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull [_CullMode]
		ZWrite [_ZWriteMode]
		ZTest [_ZTestMode]
		Blend [_BlendMode_Src] [_BlendMode_Dst]
		BlendOp Add
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma exclude_renderers xbox360 xboxone ps4 psp2 n3ds wiiu 
		#pragma surface surf Unlit keepalpha noshadow nolightmap  nodirlightmap 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
			float3 worldPos;
		};

		uniform float _ZTestMode;
		uniform float _ZWriteMode;
		uniform float _CullMode;
		uniform float _BlendMode_Src;
		uniform float _BlendMode_Dst;
		uniform sampler2D _EmissionTex;
		uniform float _EmissionTex_U_Speed;
		uniform float _EmissionTex_V_Speed;
		uniform float4 _EmissionTex_ST;
		uniform half4 _EmissionColor;
		uniform float _Global_Opacity;
		uniform float _Fade_Button;
		uniform float _Fade_Distance;
		uniform float _FadeValue;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 appendResult432 = (float2(_EmissionTex_U_Speed , _EmissionTex_V_Speed));
			float2 uv0_EmissionTex = i.uv_texcoord * _EmissionTex_ST.xy + _EmissionTex_ST.zw;
			float2 panner425 = ( 1.0 * _Time.y * appendResult432 + uv0_EmissionTex);
			float4 tex2DNode14 = tex2D( _EmissionTex, panner425 );
			float4 lerpResult448 = lerp( float4( 0,0,0,0 ) , ( tex2DNode14 * _EmissionColor * i.vertexColor ) , _Global_Opacity);
			float3 ase_worldPos = i.worldPos;
			float temp_output_450_0 = max( ( 1.0 - _Fade_Button ) , ( 1.0 - saturate( ( ( saturate( ( distance( _WorldSpaceCameraPos , ase_worldPos ) / _Fade_Distance ) ) + _FadeValue ) * ( 1.0 / ( _FadeValue + 1.0 + _FadeValue ) ) ) ) ) );
			o.Emission = ( lerpResult448 * temp_output_450_0 ).rgb;
			o.Alpha = ( _Global_Opacity * temp_output_450_0 * tex2DNode14.a * _EmissionColor.a * i.vertexColor.a );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17700
1920;3;1920;1019;1117.785;361.1987;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;430;-1699.482,28.17293;Float;False;Property;_EmissionTex_V_Speed;EmissionTex_V_Speed;4;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;431;-1699.482,-67.82701;Float;False;Property;_EmissionTex_U_Speed;EmissionTex_U_Speed;3;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;432;-1395.482,-51.82701;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;423;-1658.512,-281.5662;Inherit;False;0;14;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;425;-1151.491,-172.9984;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;444;-195.8493,228.4283;Inherit;False;Property;_Fade_Button;Fade_Button;6;1;[Toggle];Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;441;-396.285,373.0672;Inherit;False;Property;_Fade_Distance;Fade_Distance;7;0;Create;True;0;0;False;0;500;600;0.1;1000;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;453;-774.834,244.9388;Inherit;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;14;-888.376,-199.5326;Inherit;True;Property;_EmissionTex;EmissionTex;2;0;Create;True;0;0;False;0;-1;None;d48e9c55d6fb6e14e8b499b26b74772d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;24;-805.6074,29.0267;Half;False;Property;_EmissionColor;EmissionColor;1;1;[HDR];Create;True;0;0;False;0;1,1,1,1;1,0.5009518,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;451;64.205,226.9418;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;442;-100.1723,372.4063;Inherit;False;DistanceFade;8;;3;7aa4f9784a2302840a4287cfe5157221;0;1;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;447;79.93241,51.28811;Inherit;False;Property;_Global_Opacity;Global_Opacity;5;0;Create;True;0;0;False;1;Header(Global_Opacity);1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;328;-178.4122,-107.4198;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMaxOpNode;450;407.4049,316.6419;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;448;450.1074,-92.18387;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;353;79.37304,800.9881;Inherit;False;Property;_ZTestMode;ZTestMode(default is LessEqual);12;1;[Enum];Create;False;2;Off;0;On;1;1;UnityEngine.Rendering.CompareFunction;True;0;4;4;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;352;79.42947,686.069;Inherit;False;Property;_ZWriteMode;ZWriteMode(default is On);11;1;[Enum];Create;False;2;Off;0;On;1;0;True;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;449;636.2048,76.14184;Inherit;False;5;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;452;627.1051,-90.25819;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;351;81.53025,605.836;Inherit;False;Property;_CullMode;CullMode(default is Back);10;1;[Enum];Create;False;0;1;UnityEngine.Rendering.CullMode;True;1;Header(Advanced);0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;429;490.8058,593.7628;Inherit;False;Property;_BlendMode_Src;BlendMode_Src;13;1;[Enum];Create;True;2;Alpha_Blend;5;Addtive;1;0;True;1;Header(...............................Blend Mode...........................);5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;428;490.8055,669.2197;Inherit;False;Property;_BlendMode_Dst;BlendMode_Dst;14;1;[Enum];Create;True;2;Alpha_Blend;10;Addtive;1;0;True;0;1;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;889.3231,-127.3518;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;RayData2.0/Run;False;False;False;False;False;False;True;False;True;False;False;False;False;False;False;False;False;False;False;False;False;Back;1;True;352;0;True;353;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Transparent;All;8;d3d9;d3d11_9x;d3d11;glcore;gles;gles3;metal;vulkan;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;1;5;True;429;10;True;428;0;4;False;-1;1;False;-1;1;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;True;351;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;432;0;431;0
WireConnection;432;1;430;0
WireConnection;425;0;423;0
WireConnection;425;2;432;0
WireConnection;14;1;425;0
WireConnection;451;0;444;0
WireConnection;442;4;441;0
WireConnection;328;0;14;0
WireConnection;328;1;24;0
WireConnection;328;2;453;0
WireConnection;450;0;451;0
WireConnection;450;1;442;0
WireConnection;448;1;328;0
WireConnection;448;2;447;0
WireConnection;449;0;447;0
WireConnection;449;1;450;0
WireConnection;449;2;14;4
WireConnection;449;3;24;4
WireConnection;449;4;453;4
WireConnection;452;0;448;0
WireConnection;452;1;450;0
WireConnection;0;2;452;0
WireConnection;0;9;449;0
ASEEND*/
//CHKSM=489276B799CA627DC551BDCA50FE3919F194A230
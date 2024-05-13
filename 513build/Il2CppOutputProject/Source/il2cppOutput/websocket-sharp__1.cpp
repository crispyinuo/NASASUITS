#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

// System.Collections.Generic.Dictionary`2<System.String,WebSocketSharp.Net.HttpHeaderInfo>
struct Dictionary_2_t3A90C82D938D47128CF15BBD66A0B8DB06909839;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588;
// System.Char[]
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// System.Collections.ArrayList
struct ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A;
// System.Collections.Hashtable
struct Hashtable_tEFC3B6496E6747787D8BB761B51F2AE3A8CFFE2D;
// System.Collections.IEqualityComparer
struct IEqualityComparer_tEF8F1EC76B9C8E76695BE848D41E6B147928D1C1;
// System.Runtime.Serialization.IFormatterConverter
struct IFormatterConverter_t726606DAC82C384B08C82471313C340968DDB609;
// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37;
// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t;
// System.StringComparer
struct StringComparer_t6268F19CA34879176651429C0D8A3D0002BB8E06;
// System.Type
struct Type_t;
// WebSocketSharp.Net.WebHeaderCollection
struct WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331;
// System.Collections.Specialized.NameObjectCollectionBase/KeysCollection
struct KeysCollection_t8FF5FD8704F6F99F6FD4B8A2D27DFAEFD3880F81;
// System.Collections.Specialized.NameObjectCollectionBase/NameObjectEntry
struct NameObjectEntry_t58A8B38FC7A6ABE5C83153B6C3F2696F88E7A9A2;
// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0
struct U3CU3Ec__DisplayClass59_0_t68C8CB5E3E41F8A5EDBBDBD218D08119A9B62660;
// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0
struct U3CU3Ec__DisplayClass70_0_tCB5F1A02C3F28DA93EB6F505D2D49120FFF3B777;

IL2CPP_EXTERN_C String_t* _stringLiteral95C5AE48F5DB42D8A787E2092C983C3F77EB5182;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_tE2E45F09B1224B753B14385A84BC342FCAC9053A  : public RuntimeObject
{
};

// System.Collections.Specialized.NameObjectCollectionBase
struct NameObjectCollectionBase_tB6400DF2FA3B64660D79586B79016B4A0BA645FC  : public RuntimeObject
{
	// System.Boolean System.Collections.Specialized.NameObjectCollectionBase::_readOnly
	bool ____readOnly_8;
	// System.Collections.ArrayList System.Collections.Specialized.NameObjectCollectionBase::_entriesArray
	ArrayList_t7A8E5AF0C4378015B5731ABE2BED8F2782FEEF8A* ____entriesArray_9;
	// System.Collections.IEqualityComparer System.Collections.Specialized.NameObjectCollectionBase::_keyComparer
	RuntimeObject* ____keyComparer_10;
	// System.Collections.Hashtable modreq(System.Runtime.CompilerServices.IsVolatile) System.Collections.Specialized.NameObjectCollectionBase::_entriesTable
	Hashtable_tEFC3B6496E6747787D8BB761B51F2AE3A8CFFE2D* ____entriesTable_11;
	// System.Collections.Specialized.NameObjectCollectionBase/NameObjectEntry modreq(System.Runtime.CompilerServices.IsVolatile) System.Collections.Specialized.NameObjectCollectionBase::_nullKeyEntry
	NameObjectEntry_t58A8B38FC7A6ABE5C83153B6C3F2696F88E7A9A2* ____nullKeyEntry_12;
	// System.Collections.Specialized.NameObjectCollectionBase/KeysCollection System.Collections.Specialized.NameObjectCollectionBase::_keys
	KeysCollection_t8FF5FD8704F6F99F6FD4B8A2D27DFAEFD3880F81* ____keys_13;
	// System.Runtime.Serialization.SerializationInfo System.Collections.Specialized.NameObjectCollectionBase::_serializationInfo
	SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ____serializationInfo_14;
	// System.Int32 System.Collections.Specialized.NameObjectCollectionBase::_version
	int32_t ____version_15;
	// System.Object System.Collections.Specialized.NameObjectCollectionBase::_syncRoot
	RuntimeObject* ____syncRoot_16;
};

// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37  : public RuntimeObject
{
	// System.String[] System.Runtime.Serialization.SerializationInfo::m_members
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___m_members_3;
	// System.Object[] System.Runtime.Serialization.SerializationInfo::m_data
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___m_data_4;
	// System.Type[] System.Runtime.Serialization.SerializationInfo::m_types
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___m_types_5;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Runtime.Serialization.SerializationInfo::m_nameToIndex
	Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588* ___m_nameToIndex_6;
	// System.Int32 System.Runtime.Serialization.SerializationInfo::m_currMember
	int32_t ___m_currMember_7;
	// System.Runtime.Serialization.IFormatterConverter System.Runtime.Serialization.SerializationInfo::m_converter
	RuntimeObject* ___m_converter_8;
	// System.String System.Runtime.Serialization.SerializationInfo::m_fullTypeName
	String_t* ___m_fullTypeName_9;
	// System.String System.Runtime.Serialization.SerializationInfo::m_assemName
	String_t* ___m_assemName_10;
	// System.Type System.Runtime.Serialization.SerializationInfo::objectType
	Type_t* ___objectType_11;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isFullTypeNameSetExplicit
	bool ___isFullTypeNameSetExplicit_12;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isAssemblyNameSetExplicit
	bool ___isAssemblyNameSetExplicit_13;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::requireSameTokenInPartialTrust
	bool ___requireSameTokenInPartialTrust_14;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

// System.Text.StringBuilder
struct StringBuilder_t  : public RuntimeObject
{
	// System.Char[] System.Text.StringBuilder::m_ChunkChars
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___m_ChunkChars_0;
	// System.Text.StringBuilder System.Text.StringBuilder::m_ChunkPrevious
	StringBuilder_t* ___m_ChunkPrevious_1;
	// System.Int32 System.Text.StringBuilder::m_ChunkLength
	int32_t ___m_ChunkLength_2;
	// System.Int32 System.Text.StringBuilder::m_ChunkOffset
	int32_t ___m_ChunkOffset_3;
	// System.Int32 System.Text.StringBuilder::m_MaxCapacity
	int32_t ___m_MaxCapacity_4;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// WebSocketSharp.Net.WebSockets.WebSocketContext
struct WebSocketContext_t864B980CACE6C6D128960E555404BC87E7A4C3F2  : public RuntimeObject
{
};

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0
struct U3CU3Ec__DisplayClass59_0_t68C8CB5E3E41F8A5EDBBDBD218D08119A9B62660  : public RuntimeObject
{
	// System.Runtime.Serialization.SerializationInfo WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0::serializationInfo
	SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* ___serializationInfo_0;
	// System.Int32 WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0::cnt
	int32_t ___cnt_1;
	// WebSocketSharp.Net.WebHeaderCollection WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0::<>4__this
	WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* ___U3CU3E4__this_2;
};

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0
struct U3CU3Ec__DisplayClass70_0_tCB5F1A02C3F28DA93EB6F505D2D49120FFF3B777  : public RuntimeObject
{
	// System.Text.StringBuilder WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0::buff
	StringBuilder_t* ___buff_0;
	// WebSocketSharp.Net.WebHeaderCollection WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0::<>4__this
	WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* ___U3CU3E4__this_1;
};

// System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.Collections.Specialized.NameValueCollection
struct NameValueCollection_t52D1E38AB1D4ADD497A17DA305D663BB77B31DF7  : public NameObjectCollectionBase_tB6400DF2FA3B64660D79586B79016B4A0BA645FC
{
	// System.String[] System.Collections.Specialized.NameValueCollection::_all
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____all_18;
	// System.String[] System.Collections.Specialized.NameValueCollection::_allKeys
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____allKeys_19;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14
struct __StaticArrayInitTypeSizeU3D14_t2E553AA959222D2E314E13D6A80D8DB3835D872F 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D14_t2E553AA959222D2E314E13D6A80D8DB3835D872F__padding[14];
	};
};

// WebSocketSharp.Net.HttpHeaderType
struct HttpHeaderType_tBB46CA9996873CF386C8813F56A3A90DC054B8AF 
{
	// System.Int32 WebSocketSharp.Net.HttpHeaderType::value__
	int32_t ___value___2;
};

// WebSocketSharp.Net.WebHeaderCollection
struct WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331  : public NameValueCollection_t52D1E38AB1D4ADD497A17DA305D663BB77B31DF7
{
	// System.Boolean WebSocketSharp.Net.WebHeaderCollection::_internallyUsed
	bool ____internallyUsed_21;
	// WebSocketSharp.Net.HttpHeaderType WebSocketSharp.Net.WebHeaderCollection::_state
	int32_t ____state_22;
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_tE2E45F09B1224B753B14385A84BC342FCAC9053A_StaticFields
{
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14 <PrivateImplementationDetails>::49BE292FEFD2E3B7218C9123B9A016847C2A5C96
	__StaticArrayInitTypeSizeU3D14_t2E553AA959222D2E314E13D6A80D8DB3835D872F ___49BE292FEFD2E3B7218C9123B9A016847C2A5C96_0;
};

// <PrivateImplementationDetails>

// System.Runtime.Serialization.SerializationInfo

// System.Runtime.Serialization.SerializationInfo

// System.String
struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.String

// System.Text.StringBuilder

// System.Text.StringBuilder

// WebSocketSharp.Net.WebSockets.WebSocketContext

// WebSocketSharp.Net.WebSockets.WebSocketContext

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0

// WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0

// System.Int32

// System.Int32

// System.Collections.Specialized.NameValueCollection

// System.Collections.Specialized.NameValueCollection

// System.Void

// System.Void

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=14

// WebSocketSharp.Net.WebHeaderCollection
struct WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331_StaticFields
{
	// System.Collections.Generic.Dictionary`2<System.String,WebSocketSharp.Net.HttpHeaderInfo> WebSocketSharp.Net.WebHeaderCollection::_headers
	Dictionary_2_t3A90C82D938D47128CF15BBD66A0B8DB06909839* ____headers_20;
};

// WebSocketSharp.Net.WebHeaderCollection
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.String System.Int32::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5 (int32_t* __this, const RuntimeMethod* method) ;
// System.Void System.Runtime.Serialization.SerializationInfo::AddValue(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SerializationInfo_AddValue_m28FE9B110F21DDB8FF5F5E35A0EABD659DB22C2F (SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* __this, String_t* ___0_name, RuntimeObject* ___1_value, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::AppendFormat(System.String,System.Object,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_AppendFormat_mAB076D92DC92723B2224D75987BE463AF1CE7132 (StringBuilder_t* __this, String_t* ___0_format, RuntimeObject* ___1_arg0, RuntimeObject* ___2_arg1, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass59_0__ctor_m2EA18FD3DA2E67B647B8D71376ED57C58B07B549 (U3CU3Ec__DisplayClass59_0_t68C8CB5E3E41F8A5EDBBDBD218D08119A9B62660* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Void WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass59_0::<GetObjectData>b__0(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass59_0_U3CGetObjectDataU3Eb__0_mA08AB46328C390074D94C3737E2A2EB152E9CCE6 (U3CU3Ec__DisplayClass59_0_t68C8CB5E3E41F8A5EDBBDBD218D08119A9B62660* __this, int32_t ___0_i, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* L_0 = __this->___serializationInfo_0;
		String_t* L_1;
		L_1 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5((&___0_i), NULL);
		WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* L_2 = __this->___U3CU3E4__this_2;
		int32_t L_3 = ___0_i;
		NullCheck(L_2);
		String_t* L_4;
		L_4 = VirtualFuncInvoker1< String_t*, int32_t >::Invoke(21 /* System.String System.Collections.Specialized.NameValueCollection::GetKey(System.Int32) */, L_2, L_3);
		NullCheck(L_0);
		SerializationInfo_AddValue_m28FE9B110F21DDB8FF5F5E35A0EABD659DB22C2F(L_0, L_1, L_4, NULL);
		SerializationInfo_t3C47F63E24BEB9FCE2DC6309E027F238DC5C5E37* L_5 = __this->___serializationInfo_0;
		int32_t L_6 = __this->___cnt_1;
		int32_t L_7 = ___0_i;
		V_0 = ((int32_t)il2cpp_codegen_add(L_6, L_7));
		String_t* L_8;
		L_8 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5((&V_0), NULL);
		WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* L_9 = __this->___U3CU3E4__this_2;
		int32_t L_10 = ___0_i;
		NullCheck(L_9);
		String_t* L_11;
		L_11 = VirtualFuncInvoker1< String_t*, int32_t >::Invoke(20 /* System.String System.Collections.Specialized.NameValueCollection::Get(System.Int32) */, L_9, L_10);
		NullCheck(L_5);
		SerializationInfo_AddValue_m28FE9B110F21DDB8FF5F5E35A0EABD659DB22C2F(L_5, L_8, L_11, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass70_0__ctor_mC938EAD50FB9809CCA4EC8A9CDF4E247812F33B8 (U3CU3Ec__DisplayClass70_0_tCB5F1A02C3F28DA93EB6F505D2D49120FFF3B777* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Void WebSocketSharp.Net.WebHeaderCollection/<>c__DisplayClass70_0::<ToString>b__0(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass70_0_U3CToStringU3Eb__0_mB6CBCBED18E8861AB1467A9417A1010C5296C83F (U3CU3Ec__DisplayClass70_0_tCB5F1A02C3F28DA93EB6F505D2D49120FFF3B777* __this, int32_t ___0_i, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral95C5AE48F5DB42D8A787E2092C983C3F77EB5182);
		s_Il2CppMethodInitialized = true;
	}
	{
		StringBuilder_t* L_0 = __this->___buff_0;
		WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* L_1 = __this->___U3CU3E4__this_1;
		int32_t L_2 = ___0_i;
		NullCheck(L_1);
		String_t* L_3;
		L_3 = VirtualFuncInvoker1< String_t*, int32_t >::Invoke(21 /* System.String System.Collections.Specialized.NameValueCollection::GetKey(System.Int32) */, L_1, L_2);
		WebHeaderCollection_t5F2516004C02E89600B6BBC627D4C3EFF1144331* L_4 = __this->___U3CU3E4__this_1;
		int32_t L_5 = ___0_i;
		NullCheck(L_4);
		String_t* L_6;
		L_6 = VirtualFuncInvoker1< String_t*, int32_t >::Invoke(20 /* System.String System.Collections.Specialized.NameValueCollection::Get(System.Int32) */, L_4, L_5);
		NullCheck(L_0);
		StringBuilder_t* L_7;
		L_7 = StringBuilder_AppendFormat_mAB076D92DC92723B2224D75987BE463AF1CE7132(L_0, _stringLiteral95C5AE48F5DB42D8A787E2092C983C3F77EB5182, L_3, L_6, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif

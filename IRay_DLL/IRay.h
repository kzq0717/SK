#pragma once

#define IRay_DLL_CLASS_EXPORTS


#include "../IRay_DLL/IRay.h"



using namespace System;

namespace IRay
{
	
	public ref class CHyvStream
	{
		CHyvStream();

		~CHyvStream();

		static void InitSdk();
		static void UnInitSdk();
		static CHyvStream *Create();

		void Release();
		void SetVideoCallBack(VideoCallBack pVideoCallBack, void *pContext);
		void SetOtherCallBack(OtherCallBack pOtherCallBack, void *pContext);
		void SetMsgCallBack(MsgCallBack pMsgCallBack, void *pContext);

		void SetTransType(int iTransType);
		void SetDecvType(int iDecvType);
		bool Start(char *strUrl);   //������Ƶ
		void Stop();                //ֹͣ��Ƶ

		void GetVideoSize(int &iWidth, int &iHeight);//��ȡ������Ƶ���


	private:
		CHyvStream *m_HyvStream;
	}
}
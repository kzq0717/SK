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
		bool Start(char *strUrl);   //播放视频
		void Stop();                //停止视频

		void GetVideoSize(int &iWidth, int &iHeight);//获取解码视频宽高


	private:
		CHyvStream *m_HyvStream;
	}
}
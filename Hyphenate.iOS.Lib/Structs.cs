using System;
using ObjCRuntime;

namespace Hyphenate.iOS.Lib
{
    public enum EMConnectionState : long
	{
		Connected = 0,
		Disconnected
	}

	[Native]
	public enum EMMultiDevicesEvent : long
	{
		Unknow = -1,
		ContactRemove = 2,
		ContactAccept = 3,
		ContactDecline = 4,
		ContactBan = 5,
		ContactAllow = 6,
		GroupCreate = 10,
		GroupDestroy = 11,
		GroupJoin = 12,
		GroupLeave = 13,
		GroupApply = 14,
		GroupApplyAccept = 15,
		GroupApplyDecline = 16,
		GroupInvite = 17,
		GroupInviteAccept = 18,
		GroupInviteDecline = 19,
		GroupKick = 20,
		GroupBan = 21,
		GroupAllow = 22,
		GroupBlock = 23,
		GroupUnBlock = 24,
		GroupAssignOwner = 25,
		GroupAddAdmin = 26,
		GroupRemoveAdmin = 27,
		GroupAddMute = 28,
		GroupRemoveMute = 29
	}

	public enum EMLogLevel : uint
	{
		Debug = 0,
		Warning,
		Error
	}

	public enum EMPushDisplayStyle : uint
	{
		SimpleBanner = 0,
		MessageSummary
	}

	public enum EMPushNoDisturbStatus : uint
	{
		Day = 0,
		Custom,
		Close
	}

	public enum EMErrorCode : uint
	{
		General = 1,
		NetworkUnavailable,
		DatabaseOperationFailed,
		ExceedServiceLimit,
		InvalidAppkey = 100,
		InvalidUsername,
		InvalidPassword,
		InvalidURL,
		InvalidToken,
		UserAlreadyLogin = 200,
		UserNotLogin,
		UserAuthenticationFailed,
		UserAlreadyExist,
		UserNotFound,
		UserIllegalArgument,
		UserLoginOnAnotherDevice,
		UserRemoved,
		UserRegisterFailed,
		UpdateApnsConfigsFailed,
		UserPermissionDenied,
		UserBindDeviceTokenFailed,
		UserUnbindDeviceTokenFailed,
		UserBindAnotherDevice,
		UserLoginTooManyDevices,
		UserMuted,
		UserKickedByChangePassword,
		UserKickedByOtherDevice,
		ServerNotReachable = 300,
		ServerTimeout,
		ServerBusy,
		ServerUnknownError,
		ServerGetDNSConfigFailed,
		ServerServingForbidden,
		FileNotFound = 400,
		FileInvalid,
		FileUploadFailed,
		FileDownloadFailed,
		FileDeleteFailed,
		FileTooLarge,
		MessageInvalid = 500,
		MessageIncludeIllegalContent,
		MessageTrafficLimit,
		MessageEncryption,
		MessageRecallTimeLimit,
		GroupInvalidId = 600,
		GroupAlreadyJoined,
		GroupNotJoined,
		GroupPermissionDenied,
		GroupMembersFull,
		GroupNotExist,
		GroupSharedFileInvalidId,
		ChatroomInvalidId = 700,
		ChatroomAlreadyJoined,
		ChatroomNotJoined,
		ChatroomPermissionDenied,
		ChatroomMembersFull,
		ChatroomNotExist,
		CallInvalidId = 800,
		CallBusy,
		CallRemoteOffline,
		CallConnectFailed,
		CallCreateFailed,
		CallCancel,
		CallAlreadyJoined,
		CallAlreadyPub,
		CallAlreadySub,
		CallNotExist,
		CallNoPublish,
		CallNoSubscribe,
		CallNoStream,
		CallInvalidTicket,
		CallTicketExpired,
		CallSessionExpired
	}

	public enum EMMessageBodyType : uint
	{
		Text = 1,
		Image,
		Video,
		Location,
		Voice,
		File,
		Cmd
	}

	public enum EMConversationType : uint
	{
		Chat = 0,
		GroupChat,
		ChatRoom
	}

	public enum EMMessageSearchDirection : uint
	{
		Up = 0,
		Down
	}

	public enum EMChatType : uint
	{
		Chat = 0,
		GroupChat,
		ChatRoom
	}

	public enum EMMessageStatus : uint
	{
		Pending = 0,
		Delivering,
		Succeed,
		Failed
	}

	public enum EMMessageDirection : uint
	{
		Send = 0,
		Receive
	}

	public enum EMDownloadStatus : uint
	{
		Downloading = 0,
		Succeed,
		Failed,
		Pending,
		Successed = Succeed
	}

	public enum EMGroupLeaveReason : uint
	{
		BeRemoved = 0,
		UserLeave,
		Destroyed
	}

	public enum EMGroupStyle : uint
	{
		rivateOnlyOwnerInvite = 0,
		rivateMemberCanInvite,
		ublicJoinNeedApproval,
		ublicOpenJoin
	}

	public enum EMGroupPermissionType
	{
		None = -1,
		Member = 0,
		Admin,
		Owner
	}

	public enum EMChatroomBeKickedReason : uint
	{
		BeRemoved = 0,
		Destroyed,
		Offline
	}

	public enum EMChatroomPermissionType
	{
		None = -1,
		Member = 0,
		Admin,
		Owner
	}

	public enum EMServerCheckType : uint
	{
		AccountValidation = 0,
		GetDNSListFromServer,
		GetTokenFromServer,
		DoLogin,
		DoLogout
	}

	public enum EMCallSessionStatus : uint
	{
		Disconnected = 0,
		Connecting = 2,
		Connected,
		Accepted
	}

	public enum EMCallType : uint
	{
		oice = 0,
		ideo
	}

	public enum EMCallEndReason : uint
	{
		Hangup = 0,
		NoResponse,
		Decline,
		Busy,
		Failed,
		Unsupported,
		RemoteOffline,
		LoginOtherDevice,
		Destroy
	}

	public enum EMCallConnectType : uint
	{
		None = 0,
		Direct,
		Relay
	}

	public enum EMCallStreamingStatus : uint
	{
		oicePause = 0,
		oiceResume,
		ideoPause,
		ideoResume
	}

	public enum EMCallNetworkStatus : uint
	{
		Normal = 0,
		Unstable,
		NoData
	}

	public enum EMCallVideoResolution : uint
	{
		Adaptive = 0,
		EMCallVideoResolution352_288,
		EMCallVideoResolution640_480,
		EMCallVideoResolution1280_720
	}

	public enum EMCallVideoFormat : uint
	{
		Nv12 = 842094158,
		Bgra = 1095911234,
		Argb = 1111970369
	}

	public enum EMCallStreamControlType : uint
	{
		oicePause = 0,
		oiceResume,
		ideoPause,
		ideoResume
	}

	public enum EMCallViewScaleMode : uint
	{
		t = 0,
		ll = 1
	}

	//[Native]
	public enum EMConferenceRole : uint
	{
		None = 0,
		Audience = 1,
		Speaker = 3,
		Admin = 7
	}

	[Native]
    public enum EMConferenceType : long
	{
		Communication = 10,
		LargeCommunication,
		Live
	}

	public enum EMStreamType : uint
	{
		Normal = 0,
		Desktop
	}

	public enum EMConferenceMode : uint
	{
		Normal = 0,
		Large
	}
}

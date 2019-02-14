using System;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Hyphenate.iOS.Lib
{
    partial interface IEMClientDelegate {}

    // @protocol EMClientDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMClientDelegate
	{
		// @optional -(void)connectionStateDidChange:(EMConnectionState)aConnectionState;
		[Export ("connectionStateDidChange:")]
		void ConnectionStateDidChange (EMConnectionState aConnectionState);

		// @optional -(void)autoLoginDidCompleteWithError:(EMError *)aError;
		[Export ("autoLoginDidCompleteWithError:")]
		void AutoLoginDidCompleteWithError (EMError aError);

		// @optional -(void)userAccountDidLoginFromOtherDevice;
		[Export ("userAccountDidLoginFromOtherDevice")]
		void UserAccountDidLoginFromOtherDevice ();

		// @optional -(void)userAccountDidRemoveFromServer;
		[Export ("userAccountDidRemoveFromServer")]
		void UserAccountDidRemoveFromServer ();

		// @optional -(void)userDidForbidByServer;
		[Export ("userDidForbidByServer")]
		void UserDidForbidByServer ();

		// @optional -(void)userAccountDidForcedToLogout:(EMError *)aError;
		[Export ("userAccountDidForcedToLogout:")]
		void UserAccountDidForcedToLogout (EMError aError);

		// @optional -(void)didConnectionStateChanged:(EMConnectionState)aConnectionState __attribute__((deprecated("Use -connectionStateDidChange:")));
		[Export ("didConnectionStateChanged:")]
		void DidConnectionStateChanged (EMConnectionState aConnectionState);

		// @optional -(void)didAutoLoginWithError:(EMError *)aError __attribute__((deprecated("Use -autoLoginDidCompleteWithError:")));
		[Export ("didAutoLoginWithError:")]
		void DidAutoLoginWithError (EMError aError);

		// @optional -(void)didLoginFromOtherDevice __attribute__((deprecated("Use -userAccountDidLoginFromOtherDevice")));
		[Export ("didLoginFromOtherDevice")]
		void DidLoginFromOtherDevice ();

		// @optional -(void)didRemovedFromServer __attribute__((deprecated("Use -userAccountDidRemoveFromServer")));
		[Export ("didRemovedFromServer")]
		void DidRemovedFromServer ();
	}

    partial interface IEMMultiDevicesDelegate {}

    // @protocol EMMultiDevicesDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMMultiDevicesDelegate
	{
		// @optional -(void)multiDevicesContactEventDidReceive:(EMMultiDevicesEvent)aEvent username:(NSString *)aUsername ext:(NSString *)aExt;
		[Export ("multiDevicesContactEventDidReceive:username:ext:")]
		void MultiDevicesContactEventDidReceive (EMMultiDevicesEvent aEvent, string aUsername, string aExt);

		// @optional -(void)multiDevicesGroupEventDidReceive:(EMMultiDevicesEvent)aEvent groupId:(NSString *)aGroupId ext:(id)aExt;
		[Export ("multiDevicesGroupEventDidReceive:groupId:ext:")]
		void MultiDevicesGroupEventDidReceive (EMMultiDevicesEvent aEvent, string aGroupId, NSObject aExt);
	}

	// @interface EMOptions : NSObject
	[BaseType (typeof(NSObject))]
	partial interface EMOptions
	{
		// @property (readonly, copy, nonatomic) NSString * appkey;
		[Export ("appkey")]
		string Appkey { get; }

		// @property (assign, nonatomic) BOOL enableConsoleLog;
		[Export ("enableConsoleLog")]
		bool EnableConsoleLog { get; set; }

		// @property (assign, nonatomic) EMLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		EMLogLevel LogLevel { get; set; }

		// @property (assign, nonatomic) BOOL usingHttpsOnly;
		[Export ("usingHttpsOnly")]
		bool UsingHttpsOnly { get; set; }

		// @property (assign, nonatomic) BOOL isAutoLogin;
		[Export ("isAutoLogin")]
		bool IsAutoLogin { get; set; }

		// @property (assign, nonatomic) BOOL isDeleteMessagesWhenExitGroup;
		[Export ("isDeleteMessagesWhenExitGroup")]
		bool IsDeleteMessagesWhenExitGroup { get; set; }

		// @property (assign, nonatomic) BOOL isDeleteMessagesWhenExitChatRoom;
		[Export ("isDeleteMessagesWhenExitChatRoom")]
		bool IsDeleteMessagesWhenExitChatRoom { get; set; }

		// @property (assign, nonatomic) BOOL isChatroomOwnerLeaveAllowed;
		[Export ("isChatroomOwnerLeaveAllowed")]
		bool IsChatroomOwnerLeaveAllowed { get; set; }

		// @property (assign, nonatomic) BOOL isAutoAcceptGroupInvitation;
		[Export ("isAutoAcceptGroupInvitation")]
		bool IsAutoAcceptGroupInvitation { get; set; }

		// @property (assign, nonatomic) BOOL isAutoAcceptFriendInvitation;
		[Export ("isAutoAcceptFriendInvitation")]
		bool IsAutoAcceptFriendInvitation { get; set; }

		// @property (assign, nonatomic) BOOL isAutoDownloadThumbnail;
		[Export ("isAutoDownloadThumbnail")]
		bool IsAutoDownloadThumbnail { get; set; }

		// @property (assign, nonatomic) BOOL enableDeliveryAck;
		[Export ("enableDeliveryAck")]
		bool EnableDeliveryAck { get; set; }

		// @property (assign, nonatomic) BOOL sortMessageByServerTime;
		[Export ("sortMessageByServerTime")]
		bool SortMessageByServerTime { get; set; }

		// @property (assign, nonatomic) BOOL isAutoTransferMessageAttachments;
		[Export ("isAutoTransferMessageAttachments")]
		bool IsAutoTransferMessageAttachments { get; set; }

		// @property (copy, nonatomic) NSString * apnsCertName;
		[Export ("apnsCertName")]
		string ApnsCertName { get; set; }

		// +(instancetype)optionsWithAppkey:(NSString *)aAppkey;
		[Static]
		[Export ("optionsWithAppkey:")]
		EMOptions OptionsWithAppkey (string aAppkey);

		// @property (assign, nonatomic) BOOL isSandboxMode __attribute__((deprecated("")));
		[Export ("isSandboxMode")]
		bool IsSandboxMode { get; set; }

		// @property (assign, nonatomic) BOOL usingHttps __attribute__((deprecated("")));
		[Export ("usingHttps")]
		bool UsingHttps { get; set; }
	}

    // @interface PrivateDeploy (EMOptions)
    // [Category]
    // [BaseType (typeof(EMOptions))]
    partial interface EMOptions//_PrivateDeploy
    {
        // @property (assign, nonatomic) BOOL enableDnsConfig;
        [Export ("enableDnsConfig")]
        bool EnableDnsConfig { get; set; }

        // @property (assign, nonatomic) int chatPort;
        [Export ("chatPort")]
        int ChatPort { get; set; }

        // @property (copy, nonatomic) NSString * chatServer;
        [Export ("chatServer")]
        string ChatServer { get; set; }

        // @property (copy, nonatomic) NSString * restServer;
        [Export ("restServer")]
        string RestServer { get; set; }

        // @property (copy, nonatomic) NSString * dnsURL;
        [Export ("dnsURL")]
        string DnsURL { get; set; }

        // @property (nonatomic, strong) NSDictionary * extension;
        [Export ("extension", ArgumentSemantic.Strong)]
        NSDictionary Extension { get; set; }
    }

	// @interface EMPushOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface EMPushOptions
	{
		// @property (copy, nonatomic) NSString * displayName;
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (nonatomic) EMPushDisplayStyle displayStyle;
		[Export ("displayStyle", ArgumentSemantic.Assign)]
		EMPushDisplayStyle DisplayStyle { get; set; }

		// @property (nonatomic) EMPushNoDisturbStatus noDisturbStatus;
		[Export ("noDisturbStatus", ArgumentSemantic.Assign)]
		EMPushNoDisturbStatus NoDisturbStatus { get; set; }

		// @property (nonatomic) NSInteger noDisturbingStartH;
		[Export ("noDisturbingStartH")]
		nint NoDisturbingStartH { get; set; }

		// @property (nonatomic) NSInteger noDisturbingEndH;
		[Export ("noDisturbingEndH")]
		nint NoDisturbingEndH { get; set; }

		// @property (copy, nonatomic) NSString * nickname __attribute__((deprecated("Use - displayName")));
		[Export ("nickname")]
		string Nickname { get; set; }
	}

	// @interface EMError : NSObject
	[BaseType (typeof(NSObject))]
	interface EMError
	{
		// @property (nonatomic) EMErrorCode code;
		[Export ("code", ArgumentSemantic.Assign)]
		EMErrorCode Code { get; set; }

		// @property (copy, nonatomic) NSString * errorDescription;
		[Export ("errorDescription")]
		string ErrorDescription { get; set; }

		// -(instancetype)initWithDescription:(NSString *)aDescription code:(EMErrorCode)aCode;
		[Export ("initWithDescription:code:")]
		IntPtr Constructor (string aDescription, EMErrorCode aCode);

		// +(instancetype)errorWithDescription:(NSString *)aDescription code:(EMErrorCode)aCode;
		[Static]
		[Export ("errorWithDescription:code:")]
		EMError ErrorWithDescription (string aDescription, EMErrorCode aCode);
	}

    partial interface IEMChatManagerDelegate {}

    // @protocol EMChatManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMChatManagerDelegate
	{
		// @optional -(void)conversationListDidUpdate:(NSArray *)aConversationList;
		[Export ("conversationListDidUpdate:")]
		//[Verify (StronglyTypedNSArray)]
		void ConversationListDidUpdate (NSObject[] aConversationList);

		// @optional -(void)messagesDidReceive:(NSArray *)aMessages;
		[Export ("messagesDidReceive:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidReceive (NSObject[] aMessages);

		// @optional -(void)cmdMessagesDidReceive:(NSArray *)aCmdMessages;
		[Export ("cmdMessagesDidReceive:")]
		//[Verify (StronglyTypedNSArray)]
		void CmdMessagesDidReceive (NSObject[] aCmdMessages);

		// @optional -(void)messagesDidRead:(NSArray *)aMessages;
		[Export ("messagesDidRead:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidRead (NSObject[] aMessages);

		// @optional -(void)messagesDidDeliver:(NSArray *)aMessages;
		[Export ("messagesDidDeliver:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidDeliver (NSObject[] aMessages);

		// @optional -(void)messagesDidRecall:(NSArray *)aMessages;
		[Export ("messagesDidRecall:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidRecall (NSObject[] aMessages);

		// @optional -(void)messageStatusDidChange:(EMMessage *)aMessage error:(EMError *)aError;
		[Export ("messageStatusDidChange:error:")]
		void MessageStatusDidChange (EMMessage aMessage, EMError aError);

		// @optional -(void)messageAttachmentStatusDidChange:(EMMessage *)aMessage error:(EMError *)aError;
		[Export ("messageAttachmentStatusDidChange:error:")]
		void MessageAttachmentStatusDidChange (EMMessage aMessage, EMError aError);

		// @optional -(void)didUpdateConversationList:(NSArray *)aConversationList __attribute__((deprecated("Use -conversationListDidUpdate:")));
		[Export ("didUpdateConversationList:")]
		//[Verify (StronglyTypedNSArray)]
		void DidUpdateConversationList (NSObject[] aConversationList);

		// @optional -(void)didReceiveMessages:(NSArray *)aMessages __attribute__((deprecated("Use -messagesDidReceive:")));
		[Export ("didReceiveMessages:")]
		//[Verify (StronglyTypedNSArray)]
		void DidReceiveMessages (NSObject[] aMessages);

		// @optional -(void)didReceiveCmdMessages:(NSArray *)aCmdMessages __attribute__((deprecated("Use -cmdMessagesDidReceive:")));
		[Export ("didReceiveCmdMessages:")]
		//[Verify (StronglyTypedNSArray)]
		void DidReceiveCmdMessages (NSObject[] aCmdMessages);

		// @optional -(void)didReceiveHasReadAcks:(NSArray *)aMessages __attribute__((deprecated("Use -messagesDidRead:")));
		[Export ("didReceiveHasReadAcks:")]
		//[Verify (StronglyTypedNSArray)]
		void DidReceiveHasReadAcks (NSObject[] aMessages);

		// @optional -(void)didReceiveHasDeliveredAcks:(NSArray *)aMessages __attribute__((deprecated("Use -messagesDidDeliver:")));
		[Export ("didReceiveHasDeliveredAcks:")]
		//[Verify (StronglyTypedNSArray)]
		void DidReceiveHasDeliveredAcks (NSObject[] aMessages);

		// @optional -(void)didMessageStatusChanged:(EMMessage *)aMessage error:(EMError *)aError __attribute__((deprecated("Use -messageStatusDidChange:error")));
		[Export ("didMessageStatusChanged:error:")]
		void DidMessageStatusChanged (EMMessage aMessage, EMError aError);

		// @optional -(void)didMessageAttachmentsStatusChanged:(EMMessage *)aMessage error:(EMError *)aError __attribute__((deprecated("Use -messageAttachmentStatusDidChange:error")));
		[Export ("didMessageAttachmentsStatusChanged:error:")]
		void DidMessageAttachmentsStatusChanged (EMMessage aMessage, EMError aError);
	}

	// @interface EMMessageBody : NSObject
	[BaseType (typeof(NSObject))]
	interface EMMessageBody
	{
		// @property (readonly, nonatomic) EMMessageBodyType type;
		[Export ("type")]
		EMMessageBodyType Type { get; }
	}

	// @interface EMConversation : NSObject
	[BaseType (typeof(NSObject))]
	interface EMConversation
	{
		// @property (readonly, copy, nonatomic) NSString * conversationId;
		[Export ("conversationId")]
		string ConversationId { get; }

		// @property (readonly, assign, nonatomic) EMConversationType type;
		[Export ("type", ArgumentSemantic.Assign)]
		EMConversationType Type { get; }

		// @property (readonly, assign, nonatomic) int unreadMessagesCount;
		[Export ("unreadMessagesCount")]
		int UnreadMessagesCount { get; }

		// @property (copy, nonatomic) NSDictionary * ext;
		[Export ("ext", ArgumentSemantic.Copy)]
		NSDictionary Ext { get; set; }

		// @property (readonly, nonatomic, strong) EMMessage * latestMessage;
		[Export ("latestMessage", ArgumentSemantic.Strong)]
		EMMessage LatestMessage { get; }

		// -(EMMessage *)lastReceivedMessage;
		[Export ("lastReceivedMessage")]
		//[Verify (MethodToProperty)]
		EMMessage LastReceivedMessage { get; }

		// -(void)insertMessage:(EMMessage *)aMessage error:(EMError **)pError;
		[Export ("insertMessage:error:")]
		void InsertMessage (EMMessage aMessage, out EMError pError);

		// -(void)appendMessage:(EMMessage *)aMessage error:(EMError **)pError;
		[Export ("appendMessage:error:")]
		void AppendMessage (EMMessage aMessage, out EMError pError);

		// -(void)deleteMessageWithId:(NSString *)aMessageId error:(EMError **)pError;
		[Export ("deleteMessageWithId:error:")]
		void DeleteMessageWithId (string aMessageId, out EMError pError);

		// -(void)deleteAllMessages:(EMError **)pError;
		[Export ("deleteAllMessages:")]
		void SetDeleteAllMessages (out EMError pError);

		// -(void)updateMessageChange:(EMMessage *)aMessage error:(EMError **)pError;
		[Export ("updateMessageChange:error:")]
		void UpdateMessageChange (EMMessage aMessage, out EMError pError);

		// -(void)markMessageAsReadWithId:(NSString *)aMessageId error:(EMError **)pError;
		[Export ("markMessageAsReadWithId:error:")]
		void MarkMessageAsReadWithId (string aMessageId, out EMError pError);

		// -(void)markAllMessagesAsRead:(EMError **)pError;
		[Export ("markAllMessagesAsRead:")]
		void SetMarkAllMessagesAsRead (out EMError pError);

		// -(EMMessage *)loadMessageWithId:(NSString *)aMessageId error:(EMError **)pError;
		[Export ("loadMessageWithId:error:")]
		EMMessage LoadMessageWithId (string aMessageId, out EMError pError);

		// -(void)loadMessagesStartFromId:(NSString *)aMessageId count:(int)aCount searchDirection:(EMMessageSearchDirection)aDirection completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Export ("loadMessagesStartFromId:count:searchDirection:completion:")]
		void LoadMessagesStartFromId (string aMessageId, int aCount, EMMessageSearchDirection aDirection, Action<NSArray, EMError> aCompletionBlock);

		// -(void)loadMessagesWithType:(EMMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aUsername searchDirection:(EMMessageSearchDirection)aDirection completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithType (EMMessageBodyType aType, long aTimestamp, int aCount, string aUsername, EMMessageSearchDirection aDirection, Action<NSArray, EMError> aCompletionBlock);

		// -(void)loadMessagesWithKeyword:(NSString *)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aSender searchDirection:(EMMessageSearchDirection)aDirection completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithKeyword (string aKeyword, long aTimestamp, int aCount, string aSender, EMMessageSearchDirection aDirection, Action<NSArray, EMError> aCompletionBlock);

		// -(void)loadMessagesFrom:(long long)aStartTimestamp to:(long long)aEndTimestamp count:(int)aCount completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Export ("loadMessagesFrom:to:count:completion:")]
		void LoadMessagesFrom (long aStartTimestamp, long aEndTimestamp, int aCount, Action<NSArray, EMError> aCompletionBlock);

		// -(BOOL)insertMessage:(EMMessage *)aMessage __attribute__((deprecated("Use -insertMessage:error:")));
		[Export ("insertMessage:")]
		bool InsertMessage (EMMessage aMessage);

		// -(BOOL)appendMessage:(EMMessage *)aMessage __attribute__((deprecated("Use -appendMessage:error:")));
		[Export ("appendMessage:")]
		bool AppendMessage (EMMessage aMessage);

		// -(BOOL)deleteMessageWithId:(NSString *)aMessageId __attribute__((deprecated("Use -deleteMessageWithId:error:")));
		[Export ("deleteMessageWithId:")]
		bool DeleteMessageWithId (string aMessageId);

		// -(BOOL)deleteAllMessages __attribute__((deprecated("Use -deleteAllMessages:")));
		[Export ("deleteAllMessages")]
		//[Verify (MethodToProperty)]
		bool DeleteAllMessages { get; }

		// -(BOOL)updateMessage:(EMMessage *)aMessage __attribute__((deprecated("Use -updateMessageChange:error:")));
		[Export ("updateMessage:")]
		bool UpdateMessage (EMMessage aMessage);

		// -(BOOL)markMessageAsReadWithId:(NSString *)aMessageId __attribute__((deprecated("Use -markMessageAsReadWithId:error:")));
		[Export ("markMessageAsReadWithId:")]
		bool MarkMessageAsReadWithId (string aMessageId);

		// -(BOOL)markAllMessagesAsRead __attribute__((deprecated("Use -markAllMessagesAsRead:")));
		[Export ("markAllMessagesAsRead")]
		//[Verify (MethodToProperty)]
		bool MarkAllMessagesAsRead { get; }

		// -(BOOL)updateConversationExtToDB __attribute__((deprecated("setExt: will update extend properties to DB")));
		[Export ("updateConversationExtToDB")]
		//[Verify (MethodToProperty)]
		bool UpdateConversationExtToDB { get; }

		// -(EMMessage *)loadMessageWithId:(NSString *)aMessageId __attribute__((deprecated("Use -loadMessageWithId:error:")));
		[Export ("loadMessageWithId:")]
		EMMessage LoadMessageWithId (string aMessageId);

		// -(NSArray *)loadMoreMessagesFromId:(NSString *)aMessageId limit:(int)aLimit direction:(EMMessageSearchDirection)aDirection __attribute__((deprecated("Use -loadMessagesStartFromId:count:searchDirection:completion:")));
		[Export ("loadMoreMessagesFromId:limit:direction:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] LoadMoreMessagesFromId (string aMessageId, int aLimit, EMMessageSearchDirection aDirection);

		// -(NSArray *)loadMoreMessagesWithType:(EMMessageBodyType)aType before:(long long)aTimestamp limit:(int)aLimit from:(NSString *)aSender direction:(EMMessageSearchDirection)aDirection __attribute__((deprecated("Use -loadMessagesWithType:timestamp:count:fromUser:searchDirection:completion:")));
		[Export ("loadMoreMessagesWithType:before:limit:from:direction:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] LoadMoreMessagesWithType (EMMessageBodyType aType, long aTimestamp, int aLimit, string aSender, EMMessageSearchDirection aDirection);

		// -(NSArray *)loadMoreMessagesContain:(NSString *)aKeywords before:(long long)aTimestamp limit:(int)aLimit from:(NSString *)aSender direction:(EMMessageSearchDirection)aDirection __attribute__((deprecated("Use -loadMessagesContainKeywords:timestamp:count:fromUser:searchDirection:completion:")));
		[Export ("loadMoreMessagesContain:before:limit:from:direction:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] LoadMoreMessagesContain (string aKeywords, long aTimestamp, int aLimit, string aSender, EMMessageSearchDirection aDirection);

		// -(NSArray *)loadMoreMessagesFrom:(long long)aStartTimestamp to:(long long)aEndTimestamp maxCount:(int)aMaxCount __attribute__((deprecated("Use -loadMessagesFrom:to:count:completion:")));
		[Export ("loadMoreMessagesFrom:to:maxCount:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] LoadMoreMessagesFrom (long aStartTimestamp, long aEndTimestamp, int aMaxCount);

		// -(EMMessage *)latestMessageFromOthers __attribute__((deprecated("Use -lastReceivedMessage")));
		[Export ("latestMessageFromOthers")]
		//[Verify (MethodToProperty)]
		EMMessage LatestMessageFromOthers { get; }
	}

	// @interface EMMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface EMMessage
	{
		// @property (copy, nonatomic) NSString * messageId;
		[Export ("messageId")]
		string MessageId { get; set; }

		// @property (copy, nonatomic) NSString * conversationId;
		[Export ("conversationId")]
		string ConversationId { get; set; }

		// @property (nonatomic) EMMessageDirection direction;
		[Export ("direction", ArgumentSemantic.Assign)]
		EMMessageDirection Direction { get; set; }

		// @property (copy, nonatomic) NSString * from;
		[Export ("from")]
		string From { get; set; }

		// @property (copy, nonatomic) NSString * to;
		[Export ("to")]
		string To { get; set; }

		// @property (nonatomic) long long timestamp;
		[Export ("timestamp")]
		long Timestamp { get; set; }

		// @property (nonatomic) long long localTime;
		[Export ("localTime")]
		long LocalTime { get; set; }

		// @property (nonatomic) EMChatType chatType;
		[Export ("chatType", ArgumentSemantic.Assign)]
		EMChatType ChatType { get; set; }

		// @property (nonatomic) EMMessageStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		EMMessageStatus Status { get; set; }

		// @property (nonatomic) BOOL isReadAcked;
		[Export ("isReadAcked")]
		bool IsReadAcked { get; set; }

		// @property (nonatomic) BOOL isDeliverAcked;
		[Export ("isDeliverAcked")]
		bool IsDeliverAcked { get; set; }

		// @property (nonatomic) BOOL isRead;
		[Export ("isRead")]
		bool IsRead { get; set; }

		// @property (nonatomic, strong) EMMessageBody * body;
		[Export ("body", ArgumentSemantic.Strong)]
		EMMessageBody Body { get; set; }

		// @property (copy, nonatomic) NSDictionary * ext;
		[Export ("ext", ArgumentSemantic.Copy)]
		NSDictionary Ext { get; set; }

		// -(id)initWithConversationID:(NSString *)aConversationId from:(NSString *)aFrom to:(NSString *)aTo body:(EMMessageBody *)aBody ext:(NSDictionary *)aExt;
		[Export ("initWithConversationID:from:to:body:ext:")]
		IntPtr Constructor (string aConversationId, string aFrom, string aTo, EMMessageBody aBody, NSDictionary aExt);
	}

	// @interface EMTextMessageBody : EMMessageBody
	[BaseType (typeof(EMMessageBody))]
	interface EMTextMessageBody
	{
		// @property (readonly, copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; }

		// -(instancetype)initWithText:(NSString *)aText;
		[Export ("initWithText:")]
		IntPtr Constructor (string aText);
	}

	// @interface EMLocationMessageBody : EMMessageBody
	[BaseType (typeof(EMMessageBody))]
	interface EMLocationMessageBody
	{
		// @property (nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; set; }

		// @property (nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; set; }

		// @property (copy, nonatomic) NSString * address;
		[Export ("address")]
		string Address { get; set; }

		// -(instancetype)initWithLatitude:(double)aLatitude longitude:(double)aLongitude address:(NSString *)aAddress;
		[Export ("initWithLatitude:longitude:address:")]
		IntPtr Constructor (double aLatitude, double aLongitude, string aAddress);
	}

	// @interface EMCmdMessageBody : EMMessageBody
	[BaseType (typeof(EMMessageBody))]
	interface EMCmdMessageBody
	{
		// @property (copy, nonatomic) NSString * action;
		[Export ("action")]
		string Action { get; set; }

		// @property (copy, nonatomic) NSArray * params;
		[Export ("params", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Params { get; set; }

		// @property (nonatomic) BOOL isDeliverOnlineOnly;
		[Export ("isDeliverOnlineOnly")]
		bool IsDeliverOnlineOnly { get; set; }

		// -(instancetype)initWithAction:(NSString *)aAction;
		[Export ("initWithAction:")]
		IntPtr Constructor (string aAction);
	}

	// @interface EMFileMessageBody : EMMessageBody
	[BaseType (typeof(EMMessageBody))]
	interface EMFileMessageBody
	{
		// @property (copy, nonatomic) NSString * displayName;
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic) NSString * localPath;
		[Export ("localPath")]
		string LocalPath { get; set; }

		// @property (copy, nonatomic) NSString * remotePath;
		[Export ("remotePath")]
		string RemotePath { get; set; }

		// @property (copy, nonatomic) NSString * secretKey;
		[Export ("secretKey")]
		string SecretKey { get; set; }

		// @property (nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; set; }

		// @property (nonatomic) EMDownloadStatus downloadStatus;
		[Export ("downloadStatus", ArgumentSemantic.Assign)]
		EMDownloadStatus DownloadStatus { get; set; }

		// -(instancetype)initWithLocalPath:(NSString *)aLocalPath displayName:(NSString *)aDisplayName;
		[Export ("initWithLocalPath:displayName:")]
		IntPtr Constructor (string aLocalPath, string aDisplayName);

		// -(instancetype)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
		[Export ("initWithData:displayName:")]
		IntPtr Constructor (NSData aData, string aDisplayName);
	}

	// @interface EMImageMessageBody : EMFileMessageBody
	[BaseType (typeof(EMFileMessageBody))]
	interface EMImageMessageBody
	{
		// @property (nonatomic) CGSize size;
		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; set; }

		// @property (nonatomic) CGFloat compressionRatio;
		[Export ("compressionRatio")]
		nfloat CompressionRatio { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailDisplayName;
		[Export ("thumbnailDisplayName")]
		string ThumbnailDisplayName { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailLocalPath;
		[Export ("thumbnailLocalPath")]
		string ThumbnailLocalPath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailRemotePath;
		[Export ("thumbnailRemotePath")]
		string ThumbnailRemotePath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailSecretKey;
		[Export ("thumbnailSecretKey")]
		string ThumbnailSecretKey { get; set; }

		// @property (nonatomic) CGSize thumbnailSize;
		[Export ("thumbnailSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailSize { get; set; }

		// @property (nonatomic) long long thumbnailFileLength;
		[Export ("thumbnailFileLength")]
		long ThumbnailFileLength { get; set; }

		// @property (nonatomic) EMDownloadStatus thumbnailDownloadStatus;
		[Export ("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
		EMDownloadStatus ThumbnailDownloadStatus { get; set; }

		// -(instancetype)initWithData:(NSData *)aData thumbnailData:(NSData *)aThumbnailData;
		[Export ("initWithData:thumbnailData:")]
		IntPtr Constructor (NSData aData, NSData aThumbnailData);

        // -(instancetype)initWithLocalPath:(NSString *)aLocalPath displayName:(NSString *)aDisplayName;
        [Export("initWithLocalPath:displayName:")]
        IntPtr Constructor(string aLocalPath, string aDisplayName);

        // -(instancetype)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);

        // @property (nonatomic) CGFloat compressRatio __attribute__((deprecated("Use - compressionRatio")));
        [Export ("compressRatio")]
		nfloat CompressRatio { get; set; }
	}

	// @interface EMVoiceMessageBody : EMFileMessageBody
	[BaseType (typeof(EMFileMessageBody))]
	interface EMVoiceMessageBody
	{
		// @property (nonatomic) int duration;
		[Export ("duration")]
		int Duration { get; set; }

        // -(instancetype)initWithLocalPath:(NSString *)aLocalPath displayName:(NSString *)aDisplayName;
        [Export("initWithLocalPath:displayName:")]
        IntPtr Constructor(string aLocalPath, string aDisplayName);

        // -(instancetype)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);
    }

	// @interface EMVideoMessageBody : EMFileMessageBody
	[BaseType (typeof(EMFileMessageBody))]
	interface EMVideoMessageBody
	{
		// @property (nonatomic) int duration;
		[Export ("duration")]
		int Duration { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailLocalPath;
		[Export ("thumbnailLocalPath")]
		string ThumbnailLocalPath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailRemotePath;
		[Export ("thumbnailRemotePath")]
		string ThumbnailRemotePath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailSecretKey;
		[Export ("thumbnailSecretKey")]
		string ThumbnailSecretKey { get; set; }

		// @property (nonatomic) CGSize thumbnailSize;
		[Export ("thumbnailSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailSize { get; set; }

		// @property (nonatomic) EMDownloadStatus thumbnailDownloadStatus;
		[Export ("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
		EMDownloadStatus ThumbnailDownloadStatus { get; set; }

        // -(instancetype)initWithLocalPath:(NSString *)aLocalPath displayName:(NSString *)aDisplayName;
        [Export("initWithLocalPath:displayName:")]
        IntPtr Constructor(string aLocalPath, string aDisplayName);

        // -(instancetype)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);
    }

	// @interface EMCursorResult : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCursorResult
	{
		// @property (nonatomic, strong) NSArray * list;
		[Export ("list", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] List { get; set; }

		// @property (copy, nonatomic) NSString * cursor;
		[Export ("cursor")]
		string Cursor { get; set; }

		// +(instancetype)cursorResultWithList:(NSArray *)aList andCursor:(NSString *)aCusror;
		[Static]
		[Export ("cursorResultWithList:andCursor:")]
		//[Verify (StronglyTypedNSArray)]
		EMCursorResult CursorResultWithList (NSObject[] aList, string aCusror);
	}

    partial interface IIEMChatManager {}

    // @protocol IEMChatManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMChatManager
	{
		// @required -(void)addDelegate:(id<EMChatManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMChatManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<EMChatManagerDelegate>)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (IEMChatManagerDelegate aDelegate);

		// @required -(NSArray *)getAllConversations;
		[Abstract]
		[Export ("getAllConversations")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllConversations { get; }

		// @required -(EMConversation *)getConversation:(NSString *)aConversationId type:(EMConversationType)aType createIfNotExist:(BOOL)aIfCreate;
		[Abstract]
		[Export ("getConversation:type:createIfNotExist:")]
		EMConversation GetConversation (string aConversationId, EMConversationType aType, bool aIfCreate);

		// @required -(void)deleteConversation:(NSString *)aConversationId isDeleteMessages:(BOOL)aIsDeleteMessages completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("deleteConversation:isDeleteMessages:completion:")]
		void DeleteConversation (string aConversationId, bool aIsDeleteMessages, Action<NSString, EMError> aCompletionBlock);

		// @required -(void)deleteConversations:(NSArray *)aConversations isDeleteMessages:(BOOL)aIsDeleteMessages completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("deleteConversations:isDeleteMessages:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void DeleteConversations (NSObject[] aConversations, bool aIsDeleteMessages, Action<EMError> aCompletionBlock);

		// @required -(void)importConversations:(NSArray *)aConversations completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("importConversations:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void ImportConversations (NSObject[] aConversations, Action<EMError> aCompletionBlock);

		// @required -(NSString *)getMessageAttachmentPath:(NSString *)aConversationId;
		[Abstract]
		[Export ("getMessageAttachmentPath:")]
		string GetMessageAttachmentPath (string aConversationId);

		// @required -(void)importMessages:(NSArray *)aMessages completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("importMessages:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void ImportMessages (NSObject[] aMessages, Action<EMError> aCompletionBlock);

		// @required -(void)updateMessage:(EMMessage *)aMessage completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateMessage:completion:")]
		void UpdateMessage (EMMessage aMessage, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)sendMessageReadAck:(EMMessage *)aMessage completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("sendMessageReadAck:completion:")]
		void SendMessageReadAck (EMMessage aMessage, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)recallMessage:(EMMessage *)aMessage completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("recallMessage:completion:")]
		void RecallMessage (EMMessage aMessage, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)sendMessage:(EMMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("sendMessage:progress:completion:")]
		void SendMessage (EMMessage aMessage, Action<int> aProgressBlock, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)resendMessage:(EMMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("resendMessage:progress:completion:")]
		void ResendMessage (EMMessage aMessage, Action<int> aProgressBlock, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)downloadMessageThumbnail:(EMMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("downloadMessageThumbnail:progress:completion:")]
		void DownloadMessageThumbnail (EMMessage aMessage, Action<int> aProgressBlock, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(void)downloadMessageAttachment:(EMMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(EMMessage *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("downloadMessageAttachment:progress:completion:")]
		void DownloadMessageAttachment (EMMessage aMessage, Action<int> aProgressBlock, Action<EMMessage, EMError> aCompletionBlock);

		// @required -(EMCursorResult *)fetchHistoryMessagesFromServer:(NSString *)aConversationId conversationType:(EMConversationType)aConversationType startMessageId:(NSString *)aStartMessageId pageSize:(int)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("fetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:error:")]
		EMCursorResult FetchHistoryMessagesFromServer (string aConversationId, EMConversationType aConversationType, string aStartMessageId, int aPageSize, out EMError pError);

		// @required -(void)asyncFetchHistoryMessagesFromServer:(NSString *)aConversationId conversationType:(EMConversationType)aConversationType startMessageId:(NSString *)aStartMessageId pageSize:(int)aPageSize completion:(void (^)(EMCursorResult *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("asyncFetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:completion:")]
		void AsyncFetchHistoryMessagesFromServer (string aConversationId, EMConversationType aConversationType, string aStartMessageId, int aPageSize, Action<EMCursorResult, EMError> aCompletionBlock);

		// @required -(void)addDelegate:(id<EMChatManagerDelegate>)aDelegate __attribute__((deprecated("")));
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (IEMChatManagerDelegate aDelegate);

		// @required -(NSArray *)loadAllConversationsFromDB __attribute__((deprecated("Use -getAllConversations")));
		[Abstract]
		[Export ("loadAllConversationsFromDB")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] LoadAllConversationsFromDB { get; }

		// @required -(BOOL)deleteConversation:(NSString *)aConversationId deleteMessages:(BOOL)aDeleteMessage __attribute__((deprecated("Use -deleteConversation:isDeleteMessages:completion:")));
		[Abstract]
		[Export ("deleteConversation:deleteMessages:")]
		bool DeleteConversation (string aConversationId, bool aDeleteMessage);

		// @required -(BOOL)deleteConversations:(NSArray *)aConversations deleteMessages:(BOOL)aDeleteMessage __attribute__((deprecated("Use -deleteConversations:isDeleteMessages:completion:")));
		[Abstract]
		[Export ("deleteConversations:deleteMessages:")]
		//[Verify (StronglyTypedNSArray)]
		bool DeleteConversations (NSObject[] aConversations, bool aDeleteMessage);

		// @required -(BOOL)importConversations:(NSArray *)aConversations __attribute__((deprecated("Use -importConversations:completion:")));
		[Abstract]
		[Export ("importConversations:")]
		//[Verify (StronglyTypedNSArray)]
		bool ImportConversations (NSObject[] aConversations);

		// @required -(BOOL)importMessages:(NSArray *)aMessages __attribute__((deprecated("Use -importMessages:completion:")));
		[Abstract]
		[Export ("importMessages:")]
		//[Verify (StronglyTypedNSArray)]
		bool ImportMessages (NSObject[] aMessages);

		// @required -(BOOL)updateMessage:(EMMessage *)aMessage __attribute__((deprecated("Use -updateMessage:completion:")));
		[Abstract]
		[Export ("updateMessage:")]
		bool UpdateMessage (EMMessage aMessage);

		// @required -(void)asyncSendReadAckForMessage:(EMMessage *)aMessage __attribute__((deprecated("Use -sendMessageReadAck:completion:")));
		[Abstract]
		[Export ("asyncSendReadAckForMessage:")]
		void AsyncSendReadAckForMessage (EMMessage aMessage);

		// @required -(void)asyncSendMessage:(EMMessage *)aMessage progress:(void (^)(int))aProgressCompletion completion:(void (^)(EMMessage *, EMError *))aCompletion __attribute__((deprecated("Use -sendMessage:progress:completion:")));
		[Abstract]
		[Export ("asyncSendMessage:progress:completion:")]
		void AsyncSendMessage (EMMessage aMessage, Action<int> aProgressCompletion, Action<EMMessage, EMError> aCompletion);

		// @required -(void)asyncResendMessage:(EMMessage *)aMessage progress:(void (^)(int))aProgressCompletion completion:(void (^)(EMMessage *, EMError *))aCompletion __attribute__((deprecated("Use -resendMessage:progress:completion:")));
		[Abstract]
		[Export ("asyncResendMessage:progress:completion:")]
		void AsyncResendMessage (EMMessage aMessage, Action<int> aProgressCompletion, Action<EMMessage, EMError> aCompletion);

		// @required -(void)asyncDownloadMessageThumbnail:(EMMessage *)aMessage progress:(void (^)(int))aProgressCompletion completion:(void (^)(EMMessage *, EMError *))aCompletion __attribute__((deprecated("Use -downloadMessageThumbnail:progress:completion:")));
		[Abstract]
		[Export ("asyncDownloadMessageThumbnail:progress:completion:")]
		void AsyncDownloadMessageThumbnail (EMMessage aMessage, Action<int> aProgressCompletion, Action<EMMessage, EMError> aCompletion);

		// @required -(void)asyncDownloadMessageAttachments:(EMMessage *)aMessage progress:(void (^)(int))aProgressCompletion completion:(void (^)(EMMessage *, EMError *))aCompletion __attribute__((deprecated("Use -downloadMessageAttachment:progress:completion")));
		[Abstract]
		[Export ("asyncDownloadMessageAttachments:progress:completion:")]
		void AsyncDownloadMessageAttachments (EMMessage aMessage, Action<int> aProgressCompletion, Action<EMMessage, EMError> aCompletion);
	}

    partial interface IEMContactManagerDelegate {}

    // @protocol EMContactManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMContactManagerDelegate
	{
		// @optional -(void)friendRequestDidApproveByUser:(NSString *)aUsername;
		[Export ("friendRequestDidApproveByUser:")]
		void FriendRequestDidApproveByUser (string aUsername);

		// @optional -(void)friendRequestDidDeclineByUser:(NSString *)aUsername;
		[Export ("friendRequestDidDeclineByUser:")]
		void FriendRequestDidDeclineByUser (string aUsername);

		// @optional -(void)friendshipDidRemoveByUser:(NSString *)aUsername;
		[Export ("friendshipDidRemoveByUser:")]
		void FriendshipDidRemoveByUser (string aUsername);

		// @optional -(void)friendshipDidAddByUser:(NSString *)aUsername;
		[Export ("friendshipDidAddByUser:")]
		void FriendshipDidAddByUser (string aUsername);

		// @optional -(void)friendRequestDidReceiveFromUser:(NSString *)aUsername message:(NSString *)aMessage;
		[Export ("friendRequestDidReceiveFromUser:message:")]
		void FriendRequestDidReceiveFromUser (string aUsername, string aMessage);

		// @optional -(void)didReceiveAgreedFromUsername:(NSString *)aUsername __attribute__((deprecated("Use -friendRequestDidApproveByUser:")));
		[Export ("didReceiveAgreedFromUsername:")]
		void DidReceiveAgreedFromUsername (string aUsername);

		// @optional -(void)didReceiveDeclinedFromUsername:(NSString *)aUsername __attribute__((deprecated("Use -friendRequestDidDeclineByUser:")));
		[Export ("didReceiveDeclinedFromUsername:")]
		void DidReceiveDeclinedFromUsername (string aUsername);

		// @optional -(void)didReceiveDeletedFromUsername:(NSString *)aUsername __attribute__((deprecated("Use -friendshipDidRemoveByUser:")));
		[Export ("didReceiveDeletedFromUsername:")]
		void DidReceiveDeletedFromUsername (string aUsername);

		// @optional -(void)didReceiveAddedFromUsername:(NSString *)aUsername __attribute__((deprecated("Use -friendshipDidAddByUser:")));
		[Export ("didReceiveAddedFromUsername:")]
		void DidReceiveAddedFromUsername (string aUsername);

		// @optional -(void)didReceiveFriendInvitationFromUsername:(NSString *)aUsername message:(NSString *)aMessage __attribute__((deprecated("Use -friendRequestDidReceiveFromUser:message:")));
		[Export ("didReceiveFriendInvitationFromUsername:message:")]
		void DidReceiveFriendInvitationFromUsername (string aUsername, string aMessage);
	}

    partial interface IIEMContactManager {}

    // @protocol IEMContactManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMContactManager
	{
		// @required -(void)addDelegate:(id<EMContactManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMContactManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// @required -(NSArray *)getContacts;
		[Abstract]
		[Export ("getContacts")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Contacts { get; }

		// @required -(void)getContactsFromServerWithCompletion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getContactsFromServerWithCompletion:")]
		void GetContactsFromServerWithCompletion (Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getContactsFromServerWithError:(EMError **)pError;
		[Abstract]
		[Export ("getContactsFromServerWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetContactsFromServerWithError (out EMError pError);

		// @required -(EMError *)addContact:(NSString *)aUsername message:(NSString *)aMessage;
		[Abstract]
		[Export ("addContact:message:")]
		EMError AddContact (string aUsername, string aMessage);

		// @required -(void)addContact:(NSString *)aUsername message:(NSString *)aMessage completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("addContact:message:completion:")]
		void AddContact (string aUsername, string aMessage, Action<NSString, EMError> aCompletionBlock);

		// @required -(EMError *)deleteContact:(NSString *)aUsername isDeleteConversation:(BOOL)aIsDeleteConversation;
		[Abstract]
		[Export ("deleteContact:isDeleteConversation:")]
		EMError DeleteContact (string aUsername, bool aIsDeleteConversation);

		// @required -(void)deleteContact:(NSString *)aUsername isDeleteConversation:(BOOL)aIsDeleteConversation completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("deleteContact:isDeleteConversation:completion:")]
		void DeleteContact (string aUsername, bool aIsDeleteConversation, Action<NSString, EMError> aCompletionBlock);

		// @required -(void)approveFriendRequestFromUser:(NSString *)aUsername completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("approveFriendRequestFromUser:completion:")]
		void ApproveFriendRequestFromUser (string aUsername, Action<NSString, EMError> aCompletionBlock);

		// @required -(void)declineFriendRequestFromUser:(NSString *)aUsername completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("declineFriendRequestFromUser:completion:")]
		void DeclineFriendRequestFromUser (string aUsername, Action<NSString, EMError> aCompletionBlock);

		// @required -(NSArray *)getBlackList;
		[Abstract]
		[Export ("getBlackList")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] BlackList { get; }

		// @required -(void)getBlackListFromServerWithCompletion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getBlackListFromServerWithCompletion:")]
		void GetBlackListFromServerWithCompletion (Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getBlackListFromServerWithError:(EMError **)pError;
		[Abstract]
		[Export ("getBlackListFromServerWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetBlackListFromServerWithError (out EMError pError);

		// @required -(EMError *)addUserToBlackList:(NSString *)aUsername relationshipBoth:(BOOL)aBoth;
		[Abstract]
		[Export ("addUserToBlackList:relationshipBoth:")]
		EMError AddUserToBlackList (string aUsername, bool aBoth);

		// @required -(void)addUserToBlackList:(NSString *)aUsername completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("addUserToBlackList:completion:")]
		void AddUserToBlackList (string aUsername, Action<NSString, EMError> aCompletionBlock);

		// @required -(EMError *)removeUserFromBlackList:(NSString *)aUsername;
		[Abstract]
		[Export ("removeUserFromBlackList:")]
		EMError RemoveUserFromBlackList (string aUsername);

		// @required -(void)removeUserFromBlackList:(NSString *)aUsername completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeUserFromBlackList:completion:")]
		void RemoveUserFromBlackList (string aUsername, Action<NSString, EMError> aCompletionBlock);

		// @required -(EMError *)acceptInvitationForUsername:(NSString *)aUsername;
		[Abstract]
		[Export ("acceptInvitationForUsername:")]
		EMError AcceptInvitationForUsername (string aUsername);

		// @required -(EMError *)declineInvitationForUsername:(NSString *)aUsername;
		[Abstract]
		[Export ("declineInvitationForUsername:")]
		EMError DeclineInvitationForUsername (string aUsername);

		// @required -(NSArray *)getSelfIdsOnOtherPlatformWithError:(EMError **)pError;
		[Abstract]
		[Export ("getSelfIdsOnOtherPlatformWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetSelfIdsOnOtherPlatformWithError (out EMError pError);

		// @required -(void)getSelfIdsOnOtherPlatformWithCompletion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getSelfIdsOnOtherPlatformWithCompletion:")]
		void GetSelfIdsOnOtherPlatformWithCompletion (Action<NSArray, EMError> aCompletionBlock);

		// @required -(void)addDelegate:(id<EMContactManagerDelegate>)aDelegate __attribute__((deprecated("")));
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (IEMContactManagerDelegate aDelegate);

		// @required -(NSArray *)getContactsFromDB __attribute__((deprecated("Use -getContacts")));
		[Abstract]
		[Export ("getContactsFromDB")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] ContactsFromDB { get; }

		// @required -(NSArray *)getBlackListFromDB __attribute__((deprecated("Use -getBlackList")));
		[Abstract]
		[Export ("getBlackListFromDB")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] BlackListFromDB { get; }

		// @required -(void)asyncGetContactsFromServer:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getContactsFromServerWithCompletion:")));
		[Abstract]
		[Export ("asyncGetContactsFromServer:failure:")]
		void AsyncGetContactsFromServer (Action<NSArray> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAddContact:(NSString *)aUsername message:(NSString *)aMessage success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -addContact:message:completion:")));
		[Abstract]
		[Export ("asyncAddContact:message:success:failure:")]
		void AsyncAddContact (string aUsername, string aMessage, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(EMError *)deleteContact:(NSString *)aUsername __attribute__((deprecated("Use -deleteContact:username:isDeleteConversation:")));
		[Abstract]
		[Export ("deleteContact:")]
		EMError DeleteContact (string aUsername);

		// @required -(void)deleteContact:(NSString *)aUsername completion:(void (^)(NSString *, EMError *))aCompletionBlock __attribute__((deprecated("Use -deleteContact:username:isDeleteConversation:")));
		[Abstract]
		[Export ("deleteContact:completion:")]
		void DeleteContact (string aUsername, Action<NSString, EMError> aCompletionBlock);

		// @required -(void)asyncDeleteContact:(NSString *)aUsername success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -deleteContact:completion:")));
		[Abstract]
		[Export ("asyncDeleteContact:success:failure:")]
		void AsyncDeleteContact (string aUsername, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncGetBlackListFromServer:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getBlackListFromServerWithCompletion:")));
		[Abstract]
		[Export ("asyncGetBlackListFromServer:failure:")]
		void AsyncGetBlackListFromServer (Action<NSArray> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAddUserToBlackList:(NSString *)aUsername relationshipBoth:(BOOL)aBoth success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -addUserToBlackList:completion:")));
		[Abstract]
		[Export ("asyncAddUserToBlackList:relationshipBoth:success:failure:")]
		void AsyncAddUserToBlackList (string aUsername, bool aBoth, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncRemoveUserFromBlackList:(NSString *)aUsername success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -removeUserFromBlackList:completion:")));
		[Abstract]
		[Export ("asyncRemoveUserFromBlackList:success:failure:")]
		void AsyncRemoveUserFromBlackList (string aUsername, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAcceptInvitationForUsername:(NSString *)aUsername success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -approveFriendRequestFromUser:completion:")));
		[Abstract]
		[Export ("asyncAcceptInvitationForUsername:success:failure:")]
		void AsyncAcceptInvitationForUsername (string aUsername, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncDeclineInvitationForUsername:(NSString *)aUsername success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -declineFriendRequestFromUser:completion:")));
		[Abstract]
		[Export ("asyncDeclineInvitationForUsername:success:failure:")]
		void AsyncDeclineInvitationForUsername (string aUsername, Action aSuccessBlock, Action<EMError> aFailureBlock);
	}

    partial interface IEMGroupManagerDelegate {}

    // @protocol EMGroupManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMGroupManagerDelegate
	{
		// @optional -(void)groupInvitationDidReceive:(NSString *)aGroupId inviter:(NSString *)aInviter message:(NSString *)aMessage;
		[Export ("groupInvitationDidReceive:inviter:message:")]
		void GroupInvitationDidReceive (string aGroupId, string aInviter, string aMessage);

		// @optional -(void)groupInvitationDidAccept:(EMGroup *)aGroup invitee:(NSString *)aInvitee;
		[Export ("groupInvitationDidAccept:invitee:")]
		void GroupInvitationDidAccept (EMGroup aGroup, string aInvitee);

		// @optional -(void)groupInvitationDidDecline:(EMGroup *)aGroup invitee:(NSString *)aInvitee reason:(NSString *)aReason;
		[Export ("groupInvitationDidDecline:invitee:reason:")]
		void GroupInvitationDidDecline (EMGroup aGroup, string aInvitee, string aReason);

		// @optional -(void)didJoinGroup:(EMGroup *)aGroup inviter:(NSString *)aInviter message:(NSString *)aMessage;
		[Export ("didJoinGroup:inviter:message:")]
		void DidJoinGroup (EMGroup aGroup, string aInviter, string aMessage);

		// @optional -(void)didLeaveGroup:(EMGroup *)aGroup reason:(EMGroupLeaveReason)aReason;
		[Export ("didLeaveGroup:reason:")]
		void DidLeaveGroup (EMGroup aGroup, EMGroupLeaveReason aReason);

		// @optional -(void)joinGroupRequestDidReceive:(EMGroup *)aGroup user:(NSString *)aUsername reason:(NSString *)aReason;
		[Export ("joinGroupRequestDidReceive:user:reason:")]
		void JoinGroupRequestDidReceive (EMGroup aGroup, string aUsername, string aReason);

		// @optional -(void)joinGroupRequestDidDecline:(NSString *)aGroupId reason:(NSString *)aReason;
		[Export ("joinGroupRequestDidDecline:reason:")]
		void JoinGroupRequestDidDecline (string aGroupId, string aReason);

		// @optional -(void)joinGroupRequestDidApprove:(EMGroup *)aGroup;
		[Export ("joinGroupRequestDidApprove:")]
		void JoinGroupRequestDidApprove (EMGroup aGroup);

		// @optional -(void)groupListDidUpdate:(NSArray *)aGroupList;
		[Export ("groupListDidUpdate:")]
		//[Verify (StronglyTypedNSArray)]
		void GroupListDidUpdate (NSObject[] aGroupList);

		// @optional -(void)groupMuteListDidUpdate:(EMGroup *)aGroup addedMutedMembers:(NSArray *)aMutedMembers muteExpire:(NSInteger)aMuteExpire;
		[Export ("groupMuteListDidUpdate:addedMutedMembers:muteExpire:")]
		//[Verify (StronglyTypedNSArray)]
		void GroupMuteListDidUpdate (EMGroup aGroup, NSObject[] aMutedMembers, nint aMuteExpire);

		// @optional -(void)groupMuteListDidUpdate:(EMGroup *)aGroup removedMutedMembers:(NSArray *)aMutedMembers;
		[Export ("groupMuteListDidUpdate:removedMutedMembers:")]
		//[Verify (StronglyTypedNSArray)]
		void GroupMuteListDidUpdate (EMGroup aGroup, NSObject[] aMutedMembers);

		// @optional -(void)groupAdminListDidUpdate:(EMGroup *)aGroup addedAdmin:(NSString *)aAdmin;
		[Export ("groupAdminListDidUpdate:addedAdmin:")]
		void GroupAdminListDidUpdateAndAddedAdmin (EMGroup aGroup, string aAdmin);

		// @optional -(void)groupAdminListDidUpdate:(EMGroup *)aGroup removedAdmin:(NSString *)aAdmin;
		[Export ("groupAdminListDidUpdate:removedAdmin:")]
		void GroupAdminListDidUpdateAndRemovedAdmin (EMGroup aGroup, string aAdmin);

		// @optional -(void)groupOwnerDidUpdate:(EMGroup *)aGroup newOwner:(NSString *)aNewOwner oldOwner:(NSString *)aOldOwner;
		[Export ("groupOwnerDidUpdate:newOwner:oldOwner:")]
		void GroupOwnerDidUpdateAndNewOwnerWithOldOwner (EMGroup aGroup, string aNewOwner, string aOldOwner);

		// @optional -(void)userDidJoinGroup:(EMGroup *)aGroup user:(NSString *)aUsername;
		[Export ("userDidJoinGroup:user:")]
		void UserDidJoinGroup (EMGroup aGroup, string aUsername);

		// @optional -(void)userDidLeaveGroup:(EMGroup *)aGroup user:(NSString *)aUsername;
		[Export ("userDidLeaveGroup:user:")]
		void UserDidLeaveGroup (EMGroup aGroup, string aUsername);

		// @optional -(void)groupAnnouncementDidUpdate:(EMGroup *)aGroup announcement:(NSString *)aAnnouncement;
		[Export ("groupAnnouncementDidUpdate:announcement:")]
		void GroupAnnouncementDidUpdate (EMGroup aGroup, string aAnnouncement);

		// @optional -(void)groupFileListDidUpdate:(EMGroup *)aGroup addedSharedFile:(EMGroupSharedFile *)aSharedFile;
		[Export ("groupFileListDidUpdate:addedSharedFile:")]
		void GroupFileListDidUpdate (EMGroup aGroup, EMGroupSharedFile aSharedFile);

		// @optional -(void)groupFileListDidUpdate:(EMGroup *)aGroup removedSharedFile:(NSString *)aFileId;
		[Export ("groupFileListDidUpdate:removedSharedFile:")]
		void GroupFileListDidUpdate (EMGroup aGroup, string aFileId);

		// @optional -(void)didReceiveGroupInvitation:(NSString *)aGroupId inviter:(NSString *)aInviter message:(NSString *)aMessage __attribute__((deprecated("Use -groupInvitationDidReceive:inviter:message:")));
		[Export ("didReceiveGroupInvitation:inviter:message:")]
		void DidReceiveGroupInvitation (string aGroupId, string aInviter, string aMessage);

		// @optional -(void)didReceiveAcceptedGroupInvitation:(EMGroup *)aGroup invitee:(NSString *)aInvitee __attribute__((deprecated("Use -groupInvitationDidAccept:invitee:")));
		[Export ("didReceiveAcceptedGroupInvitation:invitee:")]
		void DidReceiveAcceptedGroupInvitation (EMGroup aGroup, string aInvitee);

		// @optional -(void)didReceiveDeclinedGroupInvitation:(EMGroup *)aGroup invitee:(NSString *)aInvitee reason:(NSString *)aReason __attribute__((deprecated("Use -groupInvitationDidDecline:invitee:reason:")));
		[Export ("didReceiveDeclinedGroupInvitation:invitee:reason:")]
		void DidReceiveDeclinedGroupInvitation (EMGroup aGroup, string aInvitee, string aReason);

		// @optional -(void)didJoinedGroup:(EMGroup *)aGroup inviter:(NSString *)aInviter message:(NSString *)aMessage __attribute__((deprecated("Use -didJoinGroup:inviter:message:")));
		[Export ("didJoinedGroup:inviter:message:")]
		void DidJoinedGroup (EMGroup aGroup, string aInviter, string aMessage);

		// @optional -(void)didReceiveLeavedGroup:(EMGroup *)aGroup reason:(EMGroupLeaveReason)aReason __attribute__((deprecated("Use -didLeaveGroup:reason:")));
		[Export ("didReceiveLeavedGroup:reason:")]
		void DidReceiveLeavedGroup (EMGroup aGroup, EMGroupLeaveReason aReason);

		// @optional -(void)didReceiveJoinGroupApplication:(EMGroup *)aGroup applicant:(NSString *)aApplicant reason:(NSString *)aReason __attribute__((deprecated("Use -joinGroupRequestDidReceive:user:reason:")));
		[Export ("didReceiveJoinGroupApplication:applicant:reason:")]
		void DidReceiveJoinGroupApplication (EMGroup aGroup, string aApplicant, string aReason);

		// @optional -(void)didReceiveDeclinedJoinGroup:(NSString *)aGroupId reason:(NSString *)aReason __attribute__((deprecated("Use -joinGroupRequestDidDecline:reason:")));
		[Export ("didReceiveDeclinedJoinGroup:reason:")]
		void DidReceiveDeclinedJoinGroup (string aGroupId, string aReason);

		// @optional -(void)didReceiveAcceptedJoinGroup:(EMGroup *)aGroup __attribute__((deprecated("Use -joinGroupRequestDidApprove:")));
		[Export ("didReceiveAcceptedJoinGroup:")]
		void DidReceiveAcceptedJoinGroup (EMGroup aGroup);

		// @optional -(void)didUpdateGroupList:(NSArray *)aGroupList __attribute__((deprecated("Use -groupListDidUpdate:")));
		[Export ("didUpdateGroupList:")]
		//[Verify (StronglyTypedNSArray)]
		void DidUpdateGroupList (NSObject[] aGroupList);
	}

	// @interface EMGroupOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface EMGroupOptions
	{
		// @property (nonatomic) EMGroupStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		EMGroupStyle Style { get; set; }

		// @property (nonatomic) NSInteger maxUsersCount;
		[Export ("maxUsersCount")]
		nint MaxUsersCount { get; set; }

		// @property (nonatomic) BOOL IsInviteNeedConfirm;
		[Export ("IsInviteNeedConfirm")]
		bool IsInviteNeedConfirm { get; set; }

		// @property (nonatomic, strong) NSString * ext;
		[Export ("ext", ArgumentSemantic.Strong)]
		string Ext { get; set; }
	}

	// @interface EMGroup : NSObject
	[BaseType (typeof(NSObject))]
	interface EMGroup
	{
		// @property (readonly, copy, nonatomic) NSString * groupId;
		[Export ("groupId")]
		string GroupId { get; }

		// @property (readonly, copy, nonatomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * description;
		[Export ("description")]
		string GroupDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * announcement;
		[Export ("announcement")]
		string Announcement { get; }

		// @property (readonly, nonatomic, strong) EMGroupOptions * setting;
		[Export ("setting", ArgumentSemantic.Strong)]
		EMGroupOptions Setting { get; }

		// @property (readonly, copy, nonatomic) NSString * owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, copy, nonatomic) NSArray * adminList;
		[Export ("adminList", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] AdminList { get; }

		// @property (readonly, copy, nonatomic) NSArray * memberList;
		[Export ("memberList", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] MemberList { get; }

		// @property (readonly, nonatomic, strong) NSArray * blacklist;
		[Export ("blacklist", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Blacklist { get; }

		// @property (readonly, nonatomic, strong) NSArray * muteList;
		[Export ("muteList", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] MuteList { get; }

		// @property (readonly, nonatomic, strong) NSArray * sharedFileList;
		[Export ("sharedFileList", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] SharedFileList { get; }

		// @property (readonly, nonatomic) BOOL isPushNotificationEnabled;
		[Export ("isPushNotificationEnabled")]
		bool IsPushNotificationEnabled { get; }

		// @property (readonly, nonatomic) BOOL isPublic;
		[Export ("isPublic")]
		bool IsPublic { get; }

		// @property (readonly, nonatomic) BOOL isBlocked;
		[Export ("isBlocked")]
		bool IsBlocked { get; }

		// @property (readonly, nonatomic) EMGroupPermissionType permissionType;
		[Export ("permissionType")]
		EMGroupPermissionType PermissionType { get; }

		// @property (readonly, nonatomic, strong) NSArray * occupants;
		[Export ("occupants", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Occupants { get; }

		// @property (readonly, nonatomic) NSInteger occupantsCount;
		[Export ("occupantsCount")]
		nint OccupantsCount { get; }

		// +(instancetype)groupWithId:(NSString *)aGroupId;
		[Static]
		[Export ("groupWithId:")]
		EMGroup GroupWithId (string aGroupId);

		// @property (readonly, copy, nonatomic) NSArray * members __attribute__((deprecated("")));
		[Export ("members", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Members { get; }

		// @property (readonly, nonatomic, strong) NSArray * blackList __attribute__((deprecated("")));
		[Export ("blackList", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] BlackList { get; }

		// @property (readonly, nonatomic) NSInteger membersCount __attribute__((deprecated("")));
		[Export ("membersCount")]
		nint MembersCount { get; }

		// @property (readonly, nonatomic, strong) NSArray * bans __attribute__((deprecated("Use - blackList")));
		[Export ("bans", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Bans { get; }
	}

	// @interface EMGroupSharedFile : NSObject
	[BaseType (typeof(NSObject))]
	interface EMGroupSharedFile
	{
		// @property (readonly, copy, nonatomic) NSString * fileId;
		[Export ("fileId")]
		string FileId { get; }

		// @property (readonly, copy, nonatomic) NSString * fileName;
		[Export ("fileName")]
		string FileName { get; }

		// @property (readonly, copy, nonatomic) NSString * fileOwner;
		[Export ("fileOwner")]
		string FileOwner { get; }

		// @property (nonatomic) long long createTime;
		[Export ("createTime")]
		long CreateTime { get; set; }

		// @property (nonatomic) long long fileSize;
		[Export ("fileSize")]
		long FileSize { get; set; }

		// +(instancetype)sharedFileWithId:(NSString *)aFileId;
		[Static]
		[Export ("sharedFileWithId:")]
		EMGroupSharedFile SharedFileWithId (string aFileId);
	}

    partial interface IIEMGroupManager {}

    // @protocol IEMGroupManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMGroupManager
	{
		// @required -(void)addDelegate:(id<EMGroupManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMGroupManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// @required -(NSArray *)getJoinedGroups;
		[Abstract]
		[Export ("getJoinedGroups")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] JoinedGroups { get; }

		// @required -(NSArray *)getGroupsWithoutPushNotification:(EMError **)pError;
		[Abstract]
		[Export ("getGroupsWithoutPushNotification:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupsWithoutPushNotification (out EMError pError);

		// @required -(NSArray *)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithPage:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetJoinedGroupsFromServerWithPage (nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithPage:pageSize:completion:")]
		void GetJoinedGroupsFromServerWithPage (nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(EMCursorResult *)getPublicGroupsFromServerWithCursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getPublicGroupsFromServerWithCursor:pageSize:error:")]
		EMCursorResult GetPublicGroupsFromServerWithCursor (string aCursor, nint aPageSize, out EMError pError);

		// @required -(void)getPublicGroupsFromServerWithCursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize completion:(void (^)(EMCursorResult *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getPublicGroupsFromServerWithCursor:pageSize:completion:")]
		void GetPublicGroupsFromServerWithCursor (string aCursor, nint aPageSize, Action<EMCursorResult, EMError> aCompletionBlock);

		// @required -(EMGroup *)searchPublicGroupWithId:(NSString *)aGroundId error:(EMError **)pError;
		[Abstract]
		[Export ("searchPublicGroupWithId:error:")]
		EMGroup SearchPublicGroupWithId (string aGroundId, out EMError pError);

		// @required -(void)searchPublicGroupWithId:(NSString *)aGroundId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("searchPublicGroupWithId:completion:")]
		void SearchPublicGroupWithId (string aGroundId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)createGroupWithSubject:(NSString *)aSubject description:(NSString *)aDescription invitees:(NSArray *)aInvitees message:(NSString *)aMessage setting:(EMGroupOptions *)aSetting error:(EMError **)pError;
		[Abstract]
		[Export ("createGroupWithSubject:description:invitees:message:setting:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup CreateGroupWithSubject (string aSubject, string aDescription, NSObject[] aInvitees, string aMessage, EMGroupOptions aSetting, out EMError pError);

		// @required -(void)createGroupWithSubject:(NSString *)aSubject description:(NSString *)aDescription invitees:(NSArray *)aInvitees message:(NSString *)aMessage setting:(EMGroupOptions *)aSetting completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("createGroupWithSubject:description:invitees:message:setting:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void CreateGroupWithSubject (string aSubject, string aDescription, NSObject[] aInvitees, string aMessage, EMGroupOptions aSetting, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)getGroupSpecificationFromServerWithId:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:error:")]
		EMGroup GetGroupSpecificationFromServerWithId (string aGroupId, out EMError pError);

		// @required -(void)getGroupSpecificationFromServerWithId:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:completion:")]
		void GetGroupSpecificationFromServerWithId (string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMCursorResult *)getGroupMemberListFromServerWithId:(NSString *)aGroupId cursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupMemberListFromServerWithId:cursor:pageSize:error:")]
		EMCursorResult GetGroupMemberListFromServerWithId (string aGroupId, string aCursor, nint aPageSize, out EMError pError);

		// @required -(void)getGroupMemberListFromServerWithId:(NSString *)aGroupId cursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize completion:(void (^)(EMCursorResult *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupMemberListFromServerWithId:cursor:pageSize:completion:")]
		void GetGroupMemberListFromServerWithId (string aGroupId, string aCursor, nint aPageSize, Action<EMCursorResult, EMError> aCompletionBlock);

		// @required -(NSArray *)getGroupBlacklistFromServerWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupBlacklistFromServerWithId:pageNumber:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupBlacklistFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getGroupBlacklistFromServerWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupBlacklistFromServerWithId:pageNumber:pageSize:completion:")]
		void GetGroupBlacklistFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getGroupMuteListFromServerWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupMuteListFromServerWithId:pageNumber:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupMuteListFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getGroupMuteListFromServerWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupMuteListFromServerWithId:pageNumber:pageSize:completion:")]
		void GetGroupMuteListFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getGroupFileListWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupFileListWithId:pageNumber:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupFileListWithId (string aGroupId, nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getGroupFileListWithId:(NSString *)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupFileListWithId:pageNumber:pageSize:completion:")]
		void GetGroupFileListWithId (string aGroupId, nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSString *)getGroupAnnouncementWithId:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("getGroupAnnouncementWithId:error:")]
		string GetGroupAnnouncementWithId (string aGroupId, out EMError pError);

		// @required -(void)getGroupAnnouncementWithId:(NSString *)aGroupId completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getGroupAnnouncementWithId:completion:")]
		void GetGroupAnnouncementWithId (string aGroupId, Action<NSString, EMError> aCompletionBlock);

		// @required -(EMGroup *)addOccupants:(NSArray *)aOccupants toGroup:(NSString *)aGroupId welcomeMessage:(NSString *)aWelcomeMessage error:(EMError **)pError;
		[Abstract]
		[Export ("addOccupants:toGroup:welcomeMessage:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup AddOccupants (NSObject[] aOccupants, string aGroupId, string aWelcomeMessage, out EMError pError);

		// @required -(void)addMembers:(NSArray *)aUsers toGroup:(NSString *)aGroupId message:(NSString *)aMessage completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("addMembers:toGroup:message:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void AddMembers (NSObject[] aUsers, string aGroupId, string aMessage, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)removeOccupants:(NSArray *)aOccupants fromGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("removeOccupants:fromGroup:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup RemoveOccupants (NSObject[] aOccupants, string aGroupId, out EMError pError);

		// @required -(void)removeMembers:(NSArray *)aUsers fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeMembers:fromGroup:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void RemoveMembers (NSObject[] aUsers, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)blockOccupants:(NSArray *)aOccupants fromGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("blockOccupants:fromGroup:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup BlockOccupants (NSObject[] aOccupants, string aGroupId, out EMError pError);

		// @required -(void)blockMembers:(NSArray *)aMembers fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("blockMembers:fromGroup:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void BlockMembers (NSObject[] aMembers, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)unblockOccupants:(NSArray *)aOccupants forGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("unblockOccupants:forGroup:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup UnblockOccupants (NSObject[] aOccupants, string aGroupId, out EMError pError);

		// @required -(void)unblockMembers:(NSArray *)aMembers fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("unblockMembers:fromGroup:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UnblockMembers (NSObject[] aMembers, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)changeGroupSubject:(NSString *)aSubject forGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("changeGroupSubject:forGroup:error:")]
		EMGroup ChangeGroupSubject (string aSubject, string aGroupId, out EMError pError);

		// @required -(void)updateGroupSubject:(NSString *)aSubject forGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupSubject:forGroup:completion:")]
		void UpdateGroupSubject (string aSubject, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)changeDescription:(NSString *)aDescription forGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("changeDescription:forGroup:error:")]
		EMGroup ChangeDescription (string aDescription, string aGroupId, out EMError pError);

		// @required -(void)updateDescription:(NSString *)aDescription forGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateDescription:forGroup:completion:")]
		void UpdateDescription (string aDescription, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(void)leaveGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("leaveGroup:error:")]
		void LeaveGroup (string aGroupId, out EMError pError);

		// @required -(void)leaveGroup:(NSString *)aGroupId completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("leaveGroup:completion:")]
		void LeaveGroup (string aGroupId, Action<EMError> aCompletionBlock);

		// @required -(EMError *)destroyGroup:(NSString *)aGroupId;
		[Abstract]
		[Export ("destroyGroup:")]
		EMError DestroyGroup (string aGroupId);

		// @required -(void)destroyGroup:(NSString *)aGroupId finishCompletion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("destroyGroup:finishCompletion:")]
		void DestroyGroup (string aGroupId, Action<EMError> aCompletionBlock);

		// @required -(EMGroup *)blockGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("blockGroup:error:")]
		EMGroup BlockGroup (string aGroupId, out EMError pError);

		// @required -(void)blockGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("blockGroup:completion:")]
		void BlockGroup (string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)unblockGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("unblockGroup:error:")]
		EMGroup UnblockGroup (string aGroupId, out EMError pError);

		// @required -(void)unblockGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("unblockGroup:completion:")]
		void UnblockGroup (string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)updateGroupOwner:(NSString *)aGroupId newOwner:(NSString *)aNewOwner error:(EMError **)pError;
		[Abstract]
		[Export ("updateGroupOwner:newOwner:error:")]
		EMGroup UpdateGroupOwner (string aGroupId, string aNewOwner, out EMError pError);

		// @required -(void)updateGroupOwner:(NSString *)aGroupId newOwner:(NSString *)aNewOwner completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupOwner:newOwner:completion:")]
		void UpdateGroupOwner (string aGroupId, string aNewOwner, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)addAdmin:(NSString *)aAdmin toGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("addAdmin:toGroup:error:")]
		EMGroup AddAdmin (string aAdmin, string aGroupId, out EMError pError);

		// @required -(void)addAdmin:(NSString *)aAdmin toGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("addAdmin:toGroup:completion:")]
		void AddAdmin (string aAdmin, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)removeAdmin:(NSString *)aAdmin fromGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("removeAdmin:fromGroup:error:")]
		EMGroup RemoveAdmin (string aAdmin, string aGroupId, out EMError pError);

		// @required -(void)removeAdmin:(NSString *)aAdmin fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeAdmin:fromGroup:completion:")]
		void RemoveAdmin (string aAdmin, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)muteMembers:(NSArray *)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromGroup:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup MuteMembers (NSObject[] aMuteMembers, nint aMuteMilliseconds, string aGroupId, out EMError pError);

		// @required -(void)muteMembers:(NSArray *)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromGroup:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void MuteMembers (NSObject[] aMuteMembers, nint aMuteMilliseconds, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)unmuteMembers:(NSArray *)aMembers fromGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("unmuteMembers:fromGroup:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMGroup UnmuteMembers (NSObject[] aMembers, string aGroupId, out EMError pError);

		// @required -(void)unmuteMembers:(NSArray *)aMembers fromGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("unmuteMembers:fromGroup:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UnmuteMembers (NSObject[] aMembers, string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(void)uploadGroupSharedFileWithId:(NSString *)aGroupId filePath:(NSString *)aFilePath progress:(void (^)(int))aProgressBlock completion:(void (^)(EMGroupSharedFile *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("uploadGroupSharedFileWithId:filePath:progress:completion:")]
		void UploadGroupSharedFileWithId (string aGroupId, string aFilePath, Action<int> aProgressBlock, Action<EMGroupSharedFile, EMError> aCompletionBlock);

		// @required -(void)downloadGroupSharedFileWithId:(NSString *)aGroupId filePath:(NSString *)aFilePath sharedFileId:(NSString *)aSharedFileId progress:(void (^)(int))aProgressBlock completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("downloadGroupSharedFileWithId:filePath:sharedFileId:progress:completion:")]
		void DownloadGroupSharedFileWithId (string aGroupId, string aFilePath, string aSharedFileId, Action<int> aProgressBlock, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)removeGroupSharedFileWithId:(NSString *)aGroupId sharedFileId:(NSString *)aSharedFileId error:(EMError **)pError;
		[Abstract]
		[Export ("removeGroupSharedFileWithId:sharedFileId:error:")]
		EMGroup RemoveGroupSharedFileWithId (string aGroupId, string aSharedFileId, out EMError pError);

		// @required -(void)removeGroupSharedFileWithId:(NSString *)aGroupId sharedFileId:(NSString *)aSharedFileId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeGroupSharedFileWithId:sharedFileId:completion:")]
		void RemoveGroupSharedFileWithId (string aGroupId, string aSharedFileId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)updateGroupAnnouncementWithId:(NSString *)aGroupId announcement:(NSString *)aAnnouncement error:(EMError **)pError;
		[Abstract]
		[Export ("updateGroupAnnouncementWithId:announcement:error:")]
		EMGroup UpdateGroupAnnouncementWithId (string aGroupId, string aAnnouncement, out EMError pError);

		// @required -(void)updateGroupAnnouncementWithId:(NSString *)aGroupId announcement:(NSString *)aAnnouncement completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupAnnouncementWithId:announcement:completion:")]
		void UpdateGroupAnnouncementWithId (string aGroupId, string aAnnouncement, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)updateGroupExtWithId:(NSString *)aGroupId ext:(NSString *)aExt error:(EMError **)pError;
		[Abstract]
		[Export ("updateGroupExtWithId:ext:error:")]
		EMGroup UpdateGroupExtWithId (string aGroupId, string aExt, out EMError pError);

		// @required -(void)updateGroupExtWithId:(NSString *)aGroupId ext:(NSString *)aExt completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupExtWithId:ext:completion:")]
		void UpdateGroupExtWithId (string aGroupId, string aExt, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)joinPublicGroup:(NSString *)aGroupId error:(EMError **)pError;
		[Abstract]
		[Export ("joinPublicGroup:error:")]
		EMGroup JoinPublicGroup (string aGroupId, out EMError pError);

		// @required -(void)joinPublicGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("joinPublicGroup:completion:")]
		void JoinPublicGroup (string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)applyJoinPublicGroup:(NSString *)aGroupId message:(NSString *)aMessage error:(EMError **)pError;
		[Abstract]
		[Export ("applyJoinPublicGroup:message:error:")]
		EMGroup ApplyJoinPublicGroup (string aGroupId, string aMessage, out EMError pError);

		// @required -(void)requestToJoinPublicGroup:(NSString *)aGroupId message:(NSString *)aMessage completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("requestToJoinPublicGroup:message:completion:")]
		void RequestToJoinPublicGroup (string aGroupId, string aMessage, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMError *)acceptJoinApplication:(NSString *)aGroupId applicant:(NSString *)aUsername;
		[Abstract]
		[Export ("acceptJoinApplication:applicant:")]
		EMError AcceptJoinApplication (string aGroupId, string aUsername);

		// @required -(void)approveJoinGroupRequest:(NSString *)aGroupId sender:(NSString *)aUsername completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("approveJoinGroupRequest:sender:completion:")]
		void ApproveJoinGroupRequest (string aGroupId, string aUsername, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMError *)declineJoinApplication:(NSString *)aGroupId applicant:(NSString *)aUsername reason:(NSString *)aReason;
		[Abstract]
		[Export ("declineJoinApplication:applicant:reason:")]
		EMError DeclineJoinApplication (string aGroupId, string aUsername, string aReason);

		// @required -(void)declineJoinGroupRequest:(NSString *)aGroupId sender:(NSString *)aUsername reason:(NSString *)aReason completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("declineJoinGroupRequest:sender:reason:completion:")]
		void DeclineJoinGroupRequest (string aGroupId, string aUsername, string aReason, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMGroup *)acceptInvitationFromGroup:(NSString *)aGroupId inviter:(NSString *)aUsername error:(EMError **)pError;
		[Abstract]
		[Export ("acceptInvitationFromGroup:inviter:error:")]
		EMGroup AcceptInvitationFromGroup (string aGroupId, string aUsername, out EMError pError);

		// @required -(void)acceptInvitationFromGroup:(NSString *)aGroupId inviter:(NSString *)aUsername completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("acceptInvitationFromGroup:inviter:completion:")]
		void AcceptInvitationFromGroup (string aGroupId, string aUsername, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(EMError *)declineInvitationFromGroup:(NSString *)aGroupId inviter:(NSString *)aUsername reason:(NSString *)aReason;
		[Abstract]
		[Export ("declineInvitationFromGroup:inviter:reason:")]
		EMError DeclineInvitationFromGroup (string aGroupId, string aUsername, string aReason);

		// @required -(void)declineGroupInvitation:(NSString *)aGroupId inviter:(NSString *)aInviter reason:(NSString *)aReason completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("declineGroupInvitation:inviter:reason:completion:")]
		void DeclineGroupInvitation (string aGroupId, string aInviter, string aReason, Action<EMError> aCompletionBlock);

		// @required -(EMError *)ignoreGroupPush:(NSString *)aGroupId ignore:(BOOL)aIsIgnore;
		[Abstract]
		[Export ("ignoreGroupPush:ignore:")]
		EMError IgnoreGroupPush (string aGroupId, bool aIsIgnore);

		// @required -(EMError *)ignoreGroupsPush:(NSArray *)aGroupIDs ignore:(BOOL)aIsIgnore;
		[Abstract]
		[Export ("ignoreGroupsPush:ignore:")]
		//[Verify (StronglyTypedNSArray)]
		EMError IgnoreGroupsPush (NSObject[] aGroupIDs, bool aIsIgnore);

		// @required -(void)updatePushServiceForGroup:(NSString *)aGroupId isPushEnabled:(BOOL)aIsEnable completion:(void (^)(EMGroup *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updatePushServiceForGroup:isPushEnabled:completion:")]
		void UpdatePushServiceForGroup (string aGroupId, bool aIsEnable, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(void)updatePushServiceForGroups:(NSArray *)aGroupIDs isPushEnabled:(BOOL)aIsEnable completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updatePushServiceForGroups:isPushEnabled:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UpdatePushServiceForGroups (NSObject[] aGroupIDs, bool aIsEnable, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getMyGroupsFromServerWithError:(EMError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("getMyGroupsFromServerWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetMyGroupsFromServerWithError (out EMError pError);

		// @required -(void)getJoinedGroupsFromServerWithCompletion:(void (^)(NSArray *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithCompletion:")]
		void GetJoinedGroupsFromServerWithCompletion (Action<NSArray, EMError> aCompletionBlock);

		// @required -(EMGroup *)fetchGroupInfo:(NSString *)aGroupId includeMembersList:(BOOL)aIncludeMembersList error:(EMError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("fetchGroupInfo:includeMembersList:error:")]
		EMGroup FetchGroupInfo (string aGroupId, bool aIncludeMembersList, out EMError pError);

		// @required -(void)getGroupSpecificationFromServerByID:(NSString *)aGroupID includeMembersList:(BOOL)aIncludeMembersList completion:(void (^)(EMGroup *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getGroupSpecificationFromServerByID:includeMembersList:completion:")]
		void GetGroupSpecificationFromServerByID (string aGroupID, bool aIncludeMembersList, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(NSArray *)fetchGroupBansList:(NSString *)aGroupId error:(EMError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("fetchGroupBansList:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] FetchGroupBansList (string aGroupId, out EMError pError);

		// @required -(void)getGroupBlackListFromServerByID:(NSString *)aGroupId completion:(void (^)(NSArray *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getGroupBlackListFromServerByID:completion:")]
		void GetGroupBlackListFromServerByID (string aGroupId, Action<NSArray, EMError> aCompletionBlock);

		// @required -(EMGroup *)destroyGroup:(NSString *)aGroupId error:(EMError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("destroyGroup:error:")]
		EMGroup DestroyGroup (string aGroupId, out EMError pError);

		// @required -(void)destroyGroup:(NSString *)aGroupId completion:(void (^)(EMGroup *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("destroyGroup:completion:")]
		void DestroyGroup (string aGroupId, Action<EMGroup, EMError> aCompletionBlock);

		// @required -(void)addDelegate:(id<EMGroupManagerDelegate>)aDelegate __attribute__((deprecated("")));
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (IEMGroupManagerDelegate aDelegate);

		// @required -(NSArray *)getAllGroups __attribute__((deprecated("Use -getJoinedGroups")));
		[Abstract]
		[Export ("getAllGroups")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllGroups { get; }

		// @required -(NSArray *)loadAllMyGroupsFromDB __attribute__((deprecated("Use -getJoinedGroups")));
		[Abstract]
		[Export ("loadAllMyGroupsFromDB")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] LoadAllMyGroupsFromDB { get; }

		// @required -(NSArray *)getAllIgnoredGroupIds __attribute__((deprecated("Use -getGroupsWithoutPushNotification")));
		[Abstract]
		[Export ("getAllIgnoredGroupIds")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllIgnoredGroupIds { get; }

		// @required -(void)asyncGetMyGroupsFromServer:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getJoinedGroupsFromServerWithCompletion:")));
		[Abstract]
		[Export ("asyncGetMyGroupsFromServer:failure:")]
		void AsyncGetMyGroupsFromServer (Action<NSArray> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncGetPublicGroupsFromServerWithCursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize success:(void (^)(EMCursorResult *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getPublicGroupsFromServerWithCursor:pageSize:completion:")));
		[Abstract]
		[Export ("asyncGetPublicGroupsFromServerWithCursor:pageSize:success:failure:")]
		void AsyncGetPublicGroupsFromServerWithCursor (string aCursor, nint aPageSize, Action<EMCursorResult> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncSearchPublicGroupWithId:(NSString *)aGroundId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -searchPublicGroupWithId:completion:")));
		[Abstract]
		[Export ("asyncSearchPublicGroupWithId:success:failure:")]
		void AsyncSearchPublicGroupWithId (string aGroundId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncCreateGroupWithSubject:(NSString *)aSubject description:(NSString *)aDescription invitees:(NSArray *)aInvitees message:(NSString *)aMessage setting:(EMGroupOptions *)aSetting success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -createGroupWithSubject:description:invitees:message:setting:completion")));
		[Abstract]
		[Export ("asyncCreateGroupWithSubject:description:invitees:message:setting:success:failure:")]
		//[Verify (StronglyTypedNSArray)]
		void AsyncCreateGroupWithSubject (string aSubject, string aDescription, NSObject[] aInvitees, string aMessage, EMGroupOptions aSetting, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncFetchGroupInfo:(NSString *)aGroupId includeMembersList:(BOOL)aIncludeMembersList success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getGroupSpecificationFromServerByID:includeMembersList:completion:")));
		[Abstract]
		[Export ("asyncFetchGroupInfo:includeMembersList:success:failure:")]
		void AsyncFetchGroupInfo (string aGroupId, bool aIncludeMembersList, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncFetchGroupBansList:(NSString *)aGroupId success:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getGroupBlackListFromServerByID:completion:")));
		[Abstract]
		[Export ("asyncFetchGroupBansList:success:failure:")]
		void AsyncFetchGroupBansList (string aGroupId, Action<NSArray> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAddOccupants:(NSArray *)aOccupants toGroup:(NSString *)aGroupId welcomeMessage:(NSString *)aWelcomeMessage success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -addMembers:toGroup:message:completion:")));
		[Abstract]
		[Export ("asyncAddOccupants:toGroup:welcomeMessage:success:failure:")]
		//[Verify (StronglyTypedNSArray)]
		void AsyncAddOccupants (NSObject[] aOccupants, string aGroupId, string aWelcomeMessage, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncRemoveOccupants:(NSArray *)aOccupants fromGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -removeMembers:fromGroup:completion:")));
		[Abstract]
		[Export ("asyncRemoveOccupants:fromGroup:success:failure:")]
		//[Verify (StronglyTypedNSArray)]
		void AsyncRemoveOccupants (NSObject[] aOccupants, string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncBlockOccupants:(NSArray *)aOccupants fromGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -blockMembers:fromGroup:completion:")));
		[Abstract]
		[Export ("asyncBlockOccupants:fromGroup:success:failure:")]
		//[Verify (StronglyTypedNSArray)]
		void AsyncBlockOccupants (NSObject[] aOccupants, string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncUnblockOccupants:(NSArray *)aOccupants forGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -unblockMembers:fromGroup:completion:")));
		[Abstract]
		[Export ("asyncUnblockOccupants:forGroup:success:failure:")]
		//[Verify (StronglyTypedNSArray)]
		void AsyncUnblockOccupants (NSObject[] aOccupants, string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncChangeGroupSubject:(NSString *)aSubject forGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -updateGroupSubject:forGroup:completion")));
		[Abstract]
		[Export ("asyncChangeGroupSubject:forGroup:success:failure:")]
		void AsyncChangeGroupSubject (string aSubject, string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncChangeDescription:(NSString *)aDescription forGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -updateDescription:forGroup:completion")));
		[Abstract]
		[Export ("asyncChangeDescription:forGroup:success:failure:")]
		void AsyncChangeDescription (string aDescription, string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncLeaveGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -leaveGroup:completion")));
		[Abstract]
		[Export ("asyncLeaveGroup:success:failure:")]
		void AsyncLeaveGroup (string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncDestroyGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -destroyGroup:completion")));
		[Abstract]
		[Export ("asyncDestroyGroup:success:failure:")]
		void AsyncDestroyGroup (string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncBlockGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -blockGroup:completion:")));
		[Abstract]
		[Export ("asyncBlockGroup:success:failure:")]
		void AsyncBlockGroup (string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncUnblockGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -unblockGroup:completion")));
		[Abstract]
		[Export ("asyncUnblockGroup:success:failure:")]
		void AsyncUnblockGroup (string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncJoinPublicGroup:(NSString *)aGroupId success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -joinPublicGroup:completion")));
		[Abstract]
		[Export ("asyncJoinPublicGroup:success:failure:")]
		void AsyncJoinPublicGroup (string aGroupId, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncApplyJoinPublicGroup:(NSString *)aGroupId message:(NSString *)aMessage success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -requestToJoinPublicGroup:message:completion:")));
		[Abstract]
		[Export ("asyncApplyJoinPublicGroup:message:success:failure:")]
		void AsyncApplyJoinPublicGroup (string aGroupId, string aMessage, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAcceptJoinApplication:(NSString *)aGroupId applicant:(NSString *)aUsername success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -approveJoinGroupRequest:sender:completion:")));
		[Abstract]
		[Export ("asyncAcceptJoinApplication:applicant:success:failure:")]
		void AsyncAcceptJoinApplication (string aGroupId, string aUsername, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncDeclineJoinApplication:(NSString *)aGroupId applicant:(NSString *)aUsername reason:(NSString *)aReason success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -declineJoinGroupRequest:sender:reason:completion:")));
		[Abstract]
		[Export ("asyncDeclineJoinApplication:applicant:reason:success:failure:")]
		void AsyncDeclineJoinApplication (string aGroupId, string aUsername, string aReason, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncAcceptInvitationFromGroup:(NSString *)aGroupId inviter:(NSString *)aUsername success:(void (^)(EMGroup *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -acceptInvitationFromGroup:inviter:completion")));
		[Abstract]
		[Export ("asyncAcceptInvitationFromGroup:inviter:success:failure:")]
		void AsyncAcceptInvitationFromGroup (string aGroupId, string aUsername, Action<EMGroup> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncDeclineInvitationFromGroup:(NSString *)aGroupId inviter:(NSString *)aUsername reason:(NSString *)aReason success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -declineGroupInvitation:inviter:reason:completion:")));
		[Abstract]
		[Export ("asyncDeclineInvitationFromGroup:inviter:reason:success:failure:")]
		void AsyncDeclineInvitationFromGroup (string aGroupId, string aUsername, string aReason, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncIgnoreGroupPush:(NSString *)aGroupId ignore:(BOOL)aIsIgnore success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -updatePushServiceForGroup:isPushEnabled:completion:")));
		[Abstract]
		[Export ("asyncIgnoreGroupPush:ignore:success:failure:")]
		void AsyncIgnoreGroupPush (string aGroupId, bool aIsIgnore, Action aSuccessBlock, Action<EMError> aFailureBlock);
	}

    partial interface IEMChatroomManagerDelegate {}

    // @protocol EMChatroomManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMChatroomManagerDelegate
	{
		// @optional -(void)userDidJoinChatroom:(EMChatroom *)aChatroom user:(NSString *)aUsername;
		[Export ("userDidJoinChatroom:user:")]
		void UserDidJoinChatroom (EMChatroom aChatroom, string aUsername);

		// @optional -(void)userDidLeaveChatroom:(EMChatroom *)aChatroom user:(NSString *)aUsername;
		[Export ("userDidLeaveChatroom:user:")]
		void UserDidLeaveChatroom (EMChatroom aChatroom, string aUsername);

		// @optional -(void)didDismissFromChatroom:(EMChatroom *)aChatroom reason:(EMChatroomBeKickedReason)aReason;
		[Export ("didDismissFromChatroom:reason:")]
		void DidDismissFromChatroom (EMChatroom aChatroom, EMChatroomBeKickedReason aReason);

		// @optional -(void)chatroomMuteListDidUpdate:(EMChatroom *)aChatroom addedMutedMembers:(NSArray *)aMutes muteExpire:(NSInteger)aMuteExpire;
		[Export ("chatroomMuteListDidUpdate:addedMutedMembers:muteExpire:")]
		//[Verify (StronglyTypedNSArray)]
		void ChatroomMuteListDidUpdate (EMChatroom aChatroom, NSObject[] aMutes, nint aMuteExpire);

		// @optional -(void)chatroomMuteListDidUpdate:(EMChatroom *)aChatroom removedMutedMembers:(NSArray *)aMutes;
		[Export ("chatroomMuteListDidUpdate:removedMutedMembers:")]
		//[Verify (StronglyTypedNSArray)]
		void ChatroomMuteListDidUpdate (EMChatroom aChatroom, NSObject[] aMutes);

		// @optional -(void)chatroomAdminListDidUpdate:(EMChatroom *)aChatroom addedAdmin:(NSString *)aAdmin;
		[Export ("chatroomAdminListDidUpdate:addedAdmin:")]
		void ChatroomAdminListDidUpdateAndAddedAdmin (EMChatroom aChatroom, string aAdmin);

		// @optional -(void)chatroomAdminListDidUpdate:(EMChatroom *)aChatroom removedAdmin:(NSString *)aAdmin;
		[Export ("chatroomAdminListDidUpdate:removedAdmin:")]
		void ChatroomAdminListDidUpdateAndRemovedAdmin (EMChatroom aChatroom, string aAdmin);

		// @optional -(void)chatroomOwnerDidUpdate:(EMChatroom *)aChatroom newOwner:(NSString *)aNewOwner oldOwner:(NSString *)aOldOwner;
		[Export ("chatroomOwnerDidUpdate:newOwner:oldOwner:")]
		void ChatroomOwnerDidUpdate (EMChatroom aChatroom, string aNewOwner, string aOldOwner);

		// @optional -(void)chatroomAnnouncementDidUpdate:(EMChatroom *)aChatroom announcement:(NSString *)aAnnouncement;
		[Export ("chatroomAnnouncementDidUpdate:announcement:")]
		void ChatroomAnnouncementDidUpdate (EMChatroom aChatroom, string aAnnouncement);

		// @optional -(void)didReceiveUserJoinedChatroom:(EMChatroom *)aChatroom username:(NSString *)aUsername __attribute__((deprecated("Use -userDidJoinChatroom:user:")));
		[Export ("didReceiveUserJoinedChatroom:username:")]
		void DidReceiveUserJoinedChatroom (EMChatroom aChatroom, string aUsername);

		// @optional -(void)didReceiveUserLeavedChatroom:(EMChatroom *)aChatroom username:(NSString *)aUsername __attribute__((deprecated("Use -userDidLeaveChatroom:reason:")));
		[Export ("didReceiveUserLeavedChatroom:username:")]
		void DidReceiveUserLeavedChatroom (EMChatroom aChatroom, string aUsername);

		// @optional -(void)didReceiveKickedFromChatroom:(EMChatroom *)aChatroom reason:(EMChatroomBeKickedReason)aReason __attribute__((deprecated("Use -didDismissFromChatroom:reason:")));
		[Export ("didReceiveKickedFromChatroom:reason:")]
		void DidReceiveKickedFromChatroom (EMChatroom aChatroom, EMChatroomBeKickedReason aReason);
	}

	// @interface EMChatroomOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface EMChatroomOptions
	{
		// @property (nonatomic) NSInteger maxUsersCount;
		[Export ("maxUsersCount")]
		nint MaxUsersCount { get; set; }
	}

	// @interface EMChatroom : NSObject
	[BaseType (typeof(NSObject))]
	interface EMChatroom
	{
		// @property (readonly, copy, nonatomic) NSString * chatroomId;
		[Export ("chatroomId")]
		string ChatroomId { get; }

		// @property (readonly, copy, nonatomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * description;
		[Export ("description")]
		string RoomDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, copy, nonatomic) NSString * announcement;
		[Export ("announcement")]
		string Announcement { get; }

		// @property (readonly, copy, nonatomic) NSArray * adminList;
		[Export ("adminList", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] AdminList { get; }

		// @property (readonly, copy, nonatomic) NSArray * memberList;
		[Export ("memberList", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] MemberList { get; }

		// @property (readonly, nonatomic, strong) NSArray * blacklist;
		[Export ("blacklist", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Blacklist { get; }

		// @property (readonly, nonatomic, strong) NSArray * muteList;
		[Export ("muteList", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] MuteList { get; }

		// @property (readonly, nonatomic) EMChatroomPermissionType permissionType;
		[Export ("permissionType")]
		EMChatroomPermissionType PermissionType { get; }

		// @property (readonly, nonatomic) NSInteger maxOccupantsCount;
		[Export ("maxOccupantsCount")]
		nint MaxOccupantsCount { get; }

		// @property (readonly, nonatomic) NSInteger occupantsCount;
		[Export ("occupantsCount")]
		nint OccupantsCount { get; }

		// +(instancetype)chatroomWithId:(NSString *)aChatroomId;
		[Static]
		[Export ("chatroomWithId:")]
		EMChatroom ChatroomWithId (string aChatroomId);

		// @property (readonly, copy, nonatomic) NSArray * members __attribute__((deprecated("")));
		[Export ("members", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Members { get; }

		// @property (readonly, nonatomic) NSInteger membersCount __attribute__((deprecated("")));
		[Export ("membersCount")]
		nint MembersCount { get; }

		// @property (readonly, nonatomic) NSInteger maxMembersCount __attribute__((deprecated("")));
		[Export ("maxMembersCount")]
		nint MaxMembersCount { get; }

		// @property (readonly, copy, nonatomic) NSArray * occupants __attribute__((deprecated("Use - members")));
		[Export ("occupants", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Occupants { get; }
	}

	// @interface EMPageResult : NSObject
	[BaseType (typeof(NSObject))]
	interface EMPageResult
	{
		// @property (nonatomic, strong) NSArray * list;
		[Export ("list", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] List { get; set; }

		// @property (nonatomic) NSInteger count;
		[Export ("count")]
		nint Count { get; set; }

		// +(instancetype)pageResultWithList:(NSArray *)aList andCount:(NSInteger)aCount;
		[Static]
		[Export ("pageResultWithList:andCount:")]
		//[Verify (StronglyTypedNSArray)]
		EMPageResult PageResultWithList (NSObject[] aList, nint aCount);
	}

    partial interface IIEMChatroomManager {}

    // @protocol IEMChatroomManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMChatroomManager
	{
		// @required -(void)addDelegate:(id<EMChatroomManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMChatroomManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<EMChatroomManagerDelegate>)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (IEMChatroomManagerDelegate aDelegate);

		// @required -(EMPageResult *)getChatroomsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomsFromServerWithPage:pageSize:error:")]
		EMPageResult GetChatroomsFromServerWithPage (nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getChatroomsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(EMPageResult *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomsFromServerWithPage:pageSize:completion:")]
		void GetChatroomsFromServerWithPage (nint aPageNum, nint aPageSize, Action<EMPageResult, EMError> aCompletionBlock);

		// @required -(EMChatroom *)createChatroomWithSubject:(NSString *)aSubject description:(NSString *)aDescription invitees:(NSArray *)aInvitees message:(NSString *)aMessage maxMembersCount:(NSInteger)aMaxMembersCount error:(EMError **)pError;
		[Abstract]
		[Export ("createChatroomWithSubject:description:invitees:message:maxMembersCount:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom CreateChatroomWithSubject (string aSubject, string aDescription, NSObject[] aInvitees, string aMessage, nint aMaxMembersCount, out EMError pError);

		// @required -(void)createChatroomWithSubject:(NSString *)aSubject description:(NSString *)aDescription invitees:(NSArray *)aInvitees message:(NSString *)aMessage maxMembersCount:(NSInteger)aMaxMembersCount completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("createChatroomWithSubject:description:invitees:message:maxMembersCount:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void CreateChatroomWithSubject (string aSubject, string aDescription, NSObject[] aInvitees, string aMessage, nint aMaxMembersCount, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)joinChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("joinChatroom:error:")]
		EMChatroom JoinChatroom (string aChatroomId, out EMError pError);

		// @required -(void)joinChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("joinChatroom:completion:")]
		void JoinChatroom (string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(void)leaveChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("leaveChatroom:error:")]
		void LeaveChatroom (string aChatroomId, out EMError pError);

		// @required -(void)leaveChatroom:(NSString *)aChatroomId completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("leaveChatroom:completion:")]
		void LeaveChatroom (string aChatroomId, Action<EMError> aCompletionBlock);

		// @required -(EMError *)destroyChatroom:(NSString *)aChatroomId;
		[Abstract]
		[Export ("destroyChatroom:")]
		EMError DestroyChatroom (string aChatroomId);

		// @required -(void)destroyChatroom:(NSString *)aChatroomId completion:(void (^)(EMError *))aCompletionBlock;
		[Abstract]
		[Export ("destroyChatroom:completion:")]
		void DestroyChatroom (string aChatroomId, Action<EMError> aCompletionBlock);

		// @required -(EMChatroom *)getChatroomSpecificationFromServerWithId:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomSpecificationFromServerWithId:error:")]
		EMChatroom GetChatroomSpecificationFromServerWithId (string aChatroomId, out EMError pError);

		// @required -(void)getChatroomSpecificationFromServerWithId:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomSpecificationFromServerWithId:completion:")]
		void GetChatroomSpecificationFromServerWithId (string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMCursorResult *)getChatroomMemberListFromServerWithId:(NSString *)aChatroomId cursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomMemberListFromServerWithId:cursor:pageSize:error:")]
		EMCursorResult GetChatroomMemberListFromServerWithId (string aChatroomId, string aCursor, nint aPageSize, out EMError pError);

		// @required -(void)getChatroomMemberListFromServerWithId:(NSString *)aChatroomId cursor:(NSString *)aCursor pageSize:(NSInteger)aPageSize completion:(void (^)(EMCursorResult *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomMemberListFromServerWithId:cursor:pageSize:completion:")]
		void GetChatroomMemberListFromServerWithId (string aChatroomId, string aCursor, nint aPageSize, Action<EMCursorResult, EMError> aCompletionBlock);

		// @required -(NSArray *)getChatroomBlacklistFromServerWithId:(NSString *)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomBlacklistFromServerWithId:pageNumber:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetChatroomBlacklistFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getChatroomBlacklistFromServerWithId:(NSString *)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomBlacklistFromServerWithId:pageNumber:pageSize:completion:")]
		void GetChatroomBlacklistFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSArray *)getChatroomMuteListFromServerWithId:(NSString *)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomMuteListFromServerWithId:pageNumber:pageSize:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetChatroomMuteListFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, out EMError pError);

		// @required -(void)getChatroomMuteListFromServerWithId:(NSString *)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomMuteListFromServerWithId:pageNumber:pageSize:completion:")]
		void GetChatroomMuteListFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, Action<NSArray, EMError> aCompletionBlock);

		// @required -(NSString *)getChatroomAnnouncementWithId:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("getChatroomAnnouncementWithId:error:")]
		string GetChatroomAnnouncementWithId (string aChatroomId, out EMError pError);

		// @required -(void)getChatroomAnnouncementWithId:(NSString *)aChatroomId completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomAnnouncementWithId:completion:")]
		void GetChatroomAnnouncementWithId (string aChatroomId, Action<NSString, EMError> aCompletionBlock);

		// @required -(EMChatroom *)updateSubject:(NSString *)aSubject forChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("updateSubject:forChatroom:error:")]
		EMChatroom UpdateSubject (string aSubject, string aChatroomId, out EMError pError);

		// @required -(void)updateSubject:(NSString *)aSubject forChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateSubject:forChatroom:completion:")]
		void UpdateSubject (string aSubject, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)updateDescription:(NSString *)aDescription forChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("updateDescription:forChatroom:error:")]
		EMChatroom UpdateDescription (string aDescription, string aChatroomId, out EMError pError);

		// @required -(void)updateDescription:(NSString *)aDescription forChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateDescription:forChatroom:completion:")]
		void UpdateDescription (string aDescription, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)removeMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("removeMembers:fromChatroom:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom RemoveMembers (NSObject[] aMembers, string aChatroomId, out EMError pError);

		// @required -(void)removeMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeMembers:fromChatroom:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void RemoveMembers (NSObject[] aMembers, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)blockMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("blockMembers:fromChatroom:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom BlockMembers (NSObject[] aMembers, string aChatroomId, out EMError pError);

		// @required -(void)blockMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("blockMembers:fromChatroom:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void BlockMembers (NSObject[] aMembers, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)unblockMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("unblockMembers:fromChatroom:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom UnblockMembers (NSObject[] aMembers, string aChatroomId, out EMError pError);

		// @required -(void)unblockMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("unblockMembers:fromChatroom:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UnblockMembers (NSObject[] aMembers, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)updateChatroomOwner:(NSString *)aChatroomId newOwner:(NSString *)aNewOwner error:(EMError **)pError;
		[Abstract]
		[Export ("updateChatroomOwner:newOwner:error:")]
		EMChatroom UpdateChatroomOwner (string aChatroomId, string aNewOwner, out EMError pError);

		// @required -(void)updateChatroomOwner:(NSString *)aChatroomId newOwner:(NSString *)aNewOwner completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateChatroomOwner:newOwner:completion:")]
		void UpdateChatroomOwner (string aChatroomId, string aNewOwner, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)addAdmin:(NSString *)aAdmin toChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("addAdmin:toChatroom:error:")]
		EMChatroom AddAdmin (string aAdmin, string aChatroomId, out EMError pError);

		// @required -(void)addAdmin:(NSString *)aAdmin toChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("addAdmin:toChatroom:completion:")]
		void AddAdmin (string aAdmin, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)removeAdmin:(NSString *)aAdmin fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("removeAdmin:fromChatroom:error:")]
		EMChatroom RemoveAdmin (string aAdmin, string aChatroomId, out EMError pError);

		// @required -(void)removeAdmin:(NSString *)aAdmin fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("removeAdmin:fromChatroom:completion:")]
		void RemoveAdmin (string aAdmin, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)muteMembers:(NSArray *)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromChatroom:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom MuteMembers (NSObject[] aMuteMembers, nint aMuteMilliseconds, string aChatroomId, out EMError pError);

		// @required -(void)muteMembers:(NSArray *)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromChatroom:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void MuteMembers (NSObject[] aMuteMembers, nint aMuteMilliseconds, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)unmuteMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId error:(EMError **)pError;
		[Abstract]
		[Export ("unmuteMembers:fromChatroom:error:")]
		//[Verify (StronglyTypedNSArray)]
		EMChatroom UnmuteMembers (NSObject[] aMembers, string aChatroomId, out EMError pError);

		// @required -(void)unmuteMembers:(NSArray *)aMembers fromChatroom:(NSString *)aChatroomId completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("unmuteMembers:fromChatroom:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UnmuteMembers (NSObject[] aMembers, string aChatroomId, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)updateChatroomAnnouncementWithId:(NSString *)aChatroomId announcement:(NSString *)aAnnouncement error:(EMError **)pError;
		[Abstract]
		[Export ("updateChatroomAnnouncementWithId:announcement:error:")]
		EMChatroom UpdateChatroomAnnouncementWithId (string aChatroomId, string aAnnouncement, out EMError pError);

		// @required -(void)updateChatroomAnnouncementWithId:(NSString *)aChatroomId announcement:(NSString *)aAnnouncement completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock;
		[Abstract]
		[Export ("updateChatroomAnnouncementWithId:announcement:completion:")]
		void UpdateChatroomAnnouncementWithId (string aChatroomId, string aAnnouncement, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(EMChatroom *)fetchChatroomInfo:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList error:(EMError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("fetchChatroomInfo:includeMembersList:error:")]
		EMChatroom FetchChatroomInfo (string aChatroomId, bool aIncludeMembersList, out EMError pError);

		// @required -(void)getChatroomSpecificationFromServerByID:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList completion:(void (^)(EMChatroom *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getChatroomSpecificationFromServerByID:includeMembersList:completion:")]
		void GetChatroomSpecificationFromServerByID (string aChatroomId, bool aIncludeMembersList, Action<EMChatroom, EMError> aCompletionBlock);

		// @required -(void)addDelegate:(id<EMChatroomManagerDelegate>)aDelegate __attribute__((deprecated("")));
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (IEMChatroomManagerDelegate aDelegate);

		// @required -(NSArray *)getAllChatroomsFromServerWithError:(EMError **)pError __attribute__((deprecated("Use -getChatroomsFromServerWithPage")));
		[Abstract]
		[Export ("getAllChatroomsFromServerWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetAllChatroomsFromServerWithError (out EMError pError);

		// @required -(void)getAllChatroomsFromServerWithCompletion:(void (^)(NSArray *, EMError *))aCompletionBlock __attribute__((deprecated("Use -getChatroomsFromServerWithPage")));
		[Abstract]
		[Export ("getAllChatroomsFromServerWithCompletion:")]
		void GetAllChatroomsFromServerWithCompletion (Action<NSArray, EMError> aCompletionBlock);

		// @required -(void)asyncGetAllChatroomsFromServer:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getAllChatroomsFromServerWithCompletion:")));
		[Abstract]
		[Export ("asyncGetAllChatroomsFromServer:failure:")]
		void AsyncGetAllChatroomsFromServer (Action<NSArray> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncJoinChatroom:(NSString *)aChatroomId success:(void (^)(EMChatroom *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -joinChatroom:completion:")));
		[Abstract]
		[Export ("asyncJoinChatroom:success:failure:")]
		void AsyncJoinChatroom (string aChatroomId, Action<EMChatroom> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncLeaveChatroom:(NSString *)aChatroomId success:(void (^)(EMChatroom *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -leaveChatroom:completion:")));
		[Abstract]
		[Export ("asyncLeaveChatroom:success:failure:")]
		void AsyncLeaveChatroom (string aChatroomId, Action<EMChatroom> aSuccessBlock, Action<EMError> aFailureBlock);

		// @required -(void)asyncFetchChatroomInfo:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList success:(void (^)(EMChatroom *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getChatroomSpecificationFromServerByID:includeMembersList:completion:")));
		[Abstract]
		[Export ("asyncFetchChatroomInfo:includeMembersList:success:failure:")]
		void AsyncFetchChatroomInfo (string aChatroomId, bool aIncludeMembersList, Action<EMChatroom> aSuccessBlock, Action<EMError> aFailureBlock);
	}

	// @interface EMDeviceConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface EMDeviceConfig
	{
		// @property (readonly, nonatomic) NSString * resource;
		[Export ("resource")]
		string Resource { get; }

		// @property (readonly, nonatomic) NSString * deviceUUID;
		[Export ("deviceUUID")]
		string DeviceUUID { get; }

		// @property (readonly, nonatomic) NSString * deviceName;
		[Export ("deviceName")]
		string DeviceName { get; }
	}

	// @interface EMClient : NSObject
	[BaseType (typeof(NSObject))]
	partial interface EMClient
	{
		// @property (readonly, nonatomic, strong) NSString * version;
		[Export ("version", ArgumentSemantic.Strong)]
		string Version { get; }

		// @property (readonly, nonatomic, strong) NSString * currentUsername;
		[Export ("currentUsername", ArgumentSemantic.Strong)]
		string CurrentUsername { get; }

		// @property (readonly, nonatomic, strong) EMOptions * options;
		[Export ("options", ArgumentSemantic.Strong)]
		EMOptions Options { get; }

		// @property (readonly, nonatomic, strong) EMPushOptions * pushOptions;
		[Export ("pushOptions", ArgumentSemantic.Strong)]
		EMPushOptions PushOptions { get; }

		// @property (readonly, nonatomic, strong) id<EMChatManager> chatManager;
		[Export ("chatManager", ArgumentSemantic.Strong)]
		IIEMChatManager ChatManager { get; }

		// @property (readonly, nonatomic, strong) id<EMContactManager> contactManager;
		[Export ("contactManager", ArgumentSemantic.Strong)]
        IIEMContactManager ContactManager { get; }

		// @property (readonly, nonatomic, strong) id<EMGroupManager> groupManager;
		[Export ("groupManager", ArgumentSemantic.Strong)]
		IIEMGroupManager GroupManager { get; }

		// @property (readonly, nonatomic, strong) id<EMChatroomManager> roomManager;
		[Export ("roomManager", ArgumentSemantic.Strong)]
		IIEMChatroomManager RoomManager { get; }

		// @property (readonly, nonatomic) BOOL isAutoLogin;
		[Export ("isAutoLogin")]
		bool IsAutoLogin { get; }

		// @property (readonly, nonatomic) BOOL isLoggedIn;
		[Export ("isLoggedIn")]
		bool IsLoggedIn { get; }

		// @property (readonly, nonatomic) BOOL isConnected;
		[Export ("isConnected")]
		bool IsConnected { get; }

		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		EMClient SharedClient ();

		// -(void)addDelegate:(id<EMClientDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMClientDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeDelegate:(id)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// -(void)addMultiDevicesDelegate:(id<EMMultiDevicesDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addMultiDevicesDelegate:delegateQueue:")]
		void AddMultiDevicesDelegate (IEMMultiDevicesDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeMultiDevicesDelegate:(id<EMMultiDevicesDelegate>)aDelegate;
		[Export ("removeMultiDevicesDelegate:")]
		void RemoveMultiDevicesDelegate (IEMMultiDevicesDelegate aDelegate);

		// -(EMError *)initializeSDKWithOptions:(EMOptions *)aOptions;
		[Export ("initializeSDKWithOptions:")]
		EMError InitializeSDKWithOptions (EMOptions aOptions);

		// -(EMError *)changeAppkey:(NSString *)aAppkey;
		[Export ("changeAppkey:")]
		EMError ChangeAppkey (string aAppkey);

		// -(EMError *)registerWithUsername:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("registerWithUsername:password:")]
		EMError RegisterWithUsername (string aUsername, string aPassword);

		// -(void)registerWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("registerWithUsername:password:completion:")]
		void RegisterWithUsername (string aUsername, string aPassword, Action<NSString, EMError> aCompletionBlock);

		// -(void)fetchTokenWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("fetchTokenWithUsername:password:completion:")]
		void FetchTokenWithUsername (string aUsername, string aPassword, Action<NSString, EMError> aCompletionBlock);

		// -(EMError *)loginWithUsername:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("loginWithUsername:password:")]
		EMError LoginWithUsernameAndPassword (string aUsername, string aPassword);

		// -(void)loginWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("loginWithUsername:password:completion:")]
		void LoginWithUsernameAndPasswordAndCompletion (string aUsername, string aPassword, Action<NSString, EMError> aCompletionBlock);

		// -(EMError *)loginWithUsername:(NSString *)aUsername token:(NSString *)aToken;
		[Export ("loginWithUsername:token:")]
		EMError LoginWithUsernameWithToken (string aUsername, string aToken);

		// -(void)loginWithUsername:(NSString *)aUsername token:(NSString *)aToken completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("loginWithUsername:token:completion:")]
		void LoginWithUsernameWithTokenAndCompletion (string aUsername, string aToken, Action<NSString, EMError> aCompletionBlock);

		// -(EMError *)logout:(BOOL)aIsUnbindDeviceToken;
		[Export ("logout:")]
		EMError Logout (bool aIsUnbindDeviceToken);

		// -(void)logout:(BOOL)aIsUnbindDeviceToken completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("logout:completion:")]
		void LogoutWithCompletion (bool aIsUnbindDeviceToken, Action<EMError> aCompletionBlock);

		// -(EMError *)bindDeviceToken:(NSData *)aDeviceToken;
		[Export ("bindDeviceToken:")]
		EMError BindDeviceToken (NSData aDeviceToken);

		// -(void)registerForRemoteNotificationsWithDeviceToken:(NSData *)aDeviceToken completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("registerForRemoteNotificationsWithDeviceToken:completion:")]
		void RegisterForRemoteNotificationsWithDeviceToken (NSData aDeviceToken, Action<EMError> aCompletionBlock);

		// -(EMError *)setApnsNickname:(NSString *)aNickname;
		[Export ("setApnsNickname:")]
		EMError SetApnsNickname (string aNickname);

		// -(void)updatePushNotifiationDisplayName:(NSString *)aDisplayName completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("updatePushNotifiationDisplayName:completion:")]
		void UpdatePushNotifiationDisplayName (string aDisplayName, Action<NSString, EMError> aCompletionBlock);

		// -(EMPushOptions *)getPushOptionsFromServerWithError:(EMError **)pError;
		[Export ("getPushOptionsFromServerWithError:")]
		EMPushOptions GetPushOptionsFromServerWithError (out EMError pError);

		// -(void)getPushNotificationOptionsFromServerWithCompletion:(void (^)(EMPushOptions *, EMError *))aCompletionBlock;
		[Export ("getPushNotificationOptionsFromServerWithCompletion:")]
		void GetPushNotificationOptionsFromServerWithCompletion (Action<EMPushOptions, EMError> aCompletionBlock);

		// -(EMError *)updatePushOptionsToServer;
		[Export ("updatePushOptionsToServer")]
		//[Verify (MethodToProperty)]
		EMError UpdatePushOptionsToServer { get; }

		// -(void)updatePushNotificationOptionsToServerWithCompletion:(void (^)(EMError *))aCompletionBlock;
		[Export ("updatePushNotificationOptionsToServerWithCompletion:")]
		void UpdatePushNotificationOptionsToServerWithCompletion (Action<EMError> aCompletionBlock);

		// -(EMError *)uploadLogToServer;
		[Export ("uploadLogToServer")]
		//[Verify (MethodToProperty)]
		EMError UploadLogToServer { get; }

		// -(void)uploadDebugLogToServerWithCompletion:(void (^)(EMError *))aCompletionBlock;
		[Export ("uploadDebugLogToServerWithCompletion:")]
		void UploadDebugLogToServerWithCompletion (Action<EMError> aCompletionBlock);

		// -(NSString *)getLogFilesPath:(EMError **)pError;
		[Export ("getLogFilesPath:")]
		string GetLogFilesPath (out EMError pError);

		// -(void)getLogFilesPathWithCompletion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("getLogFilesPathWithCompletion:")]
		void GetLogFilesPathWithCompletion (Action<NSString, EMError> aCompletionBlock);

		// -(NSArray *)getLoggedInDevicesFromServerWithUsername:(NSString *)aUsername password:(NSString *)aPassword error:(EMError **)pError;
		[Export ("getLoggedInDevicesFromServerWithUsername:password:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, out EMError pError);

		// -(void)getLoggedInDevicesFromServerWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(NSArray *, EMError *))aCompletionBlock;
		[Export ("getLoggedInDevicesFromServerWithUsername:password:completion:")]
		void GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, Action<NSArray, EMError> aCompletionBlock);

		// -(EMError *)kickDevice:(EMDeviceConfig *)aDevice username:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("kickDevice:username:password:")]
		EMError KickDevice (EMDeviceConfig aDevice, string aUsername, string aPassword);

		// -(void)kickDevice:(EMDeviceConfig *)aDevice username:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("kickDevice:username:password:completion:")]
		void KickDevice (EMDeviceConfig aDevice, string aUsername, string aPassword, Action<EMError> aCompletionBlock);

		// -(EMError *)kickAllDevicesWithUsername:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("kickAllDevicesWithUsername:password:")]
		EMError KickAllDevicesWithUsername (string aUsername, string aPassword);

		// -(void)kickAllDevicesWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("kickAllDevicesWithUsername:password:completion:")]
		void KickAllDevicesWithUsername (string aUsername, string aPassword, Action<EMError> aCompletionBlock);

		// -(BOOL)migrateDatabaseToLatestSDK;
		[Export ("migrateDatabaseToLatestSDK")]
		//[Verify (MethodToProperty)]
		bool MigrateDatabaseToLatestSDK { get; }

		// -(void)applicationDidEnterBackground:(id)aApplication;
		[Export ("applicationDidEnterBackground:")]
		void ApplicationDidEnterBackground (NSObject aApplication);

		// -(void)applicationWillEnterForeground:(id)aApplication;
		[Export ("applicationWillEnterForeground:")]
		void ApplicationWillEnterForeground (NSObject aApplication);

		// -(void)application:(id)application didReceiveRemoteNotification:(NSDictionary *)userInfo;
		[Export ("application:didReceiveRemoteNotification:")]
		void Application (NSObject application, NSDictionary userInfo);

		// -(void)serviceCheckWithUsername:(NSString *)aUsername password:(NSString *)aPassword completion:(void (^)(EMServerCheckType, EMError *))aCompletionBlock;
		[Export ("serviceCheckWithUsername:password:completion:")]
		void ServiceCheckWithUsername (string aUsername, string aPassword, Action<EMServerCheckType, EMError> aCompletionBlock);

		// -(void)addDelegate:(id<EMClientDelegate>)aDelegate __attribute__((deprecated("")));
		[Export ("addDelegate:")]
		void AddDelegate (IEMClientDelegate aDelegate);

		// -(void)asyncRegisterWithUsername:(NSString *)aUsername password:(NSString *)aPassword success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -registerWithUsername:password:completion:")));
		[Export ("asyncRegisterWithUsername:password:success:failure:")]
		void AsyncRegisterWithUsername (string aUsername, string aPassword, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncLoginWithUsername:(NSString *)aUsername password:(NSString *)aPassword success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -loginWithUsername:password:completion")));
		[Export ("asyncLoginWithUsername:password:success:failure:")]
		void AsyncLoginWithUsername (string aUsername, string aPassword, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncLogout:(BOOL)aIsUnbindDeviceToken success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -logout:completion:")));
		[Export ("asyncLogout:success:failure:")]
		void AsyncLogout (bool aIsUnbindDeviceToken, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncBindDeviceToken:(NSData *)aDeviceToken success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -registerForRemoteNotificationsWithDeviceToken:completion:")));
		[Export ("asyncBindDeviceToken:success:failure:")]
		void AsyncBindDeviceToken (NSData aDeviceToken, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncSetApnsNickname:(NSString *)aNickname success:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -updatePushNotifiationDisplayName:copletion")));
		[Export ("asyncSetApnsNickname:success:failure:")]
		void AsyncSetApnsNickname (string aNickname, Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncGetPushOptionsFromServer:(void (^)(EMPushOptions *))aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -getPushOptionsFromServerWithCompletion:")));
		[Export ("asyncGetPushOptionsFromServer:failure:")]
		void AsyncGetPushOptionsFromServer (Action<EMPushOptions> aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncUpdatePushOptionsToServer:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -updatePushNotificationOptionsToServerWithCompletion:")));
		[Export ("asyncUpdatePushOptionsToServer:failure:")]
		void AsyncUpdatePushOptionsToServer (Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(void)asyncUploadLogToServer:(void (^)())aSuccessBlock failure:(void (^)(EMError *))aFailureBlock __attribute__((deprecated("Use -uploadDebugLogToServerWithCompletion:")));
		[Export ("asyncUploadLogToServer:failure:")]
		void AsyncUploadLogToServer (Action aSuccessBlock, Action<EMError> aFailureBlock);

		// -(BOOL)dataMigrationTo3 __attribute__((deprecated("Use -migrateDatabaseToLatestSDK")));
		[Export ("dataMigrationTo3")]
		//[Verify (MethodToProperty)]
		bool DataMigrationTo3 { get; }
	}

	// @interface EMCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCallOptions
	{
		// @property (nonatomic) int pingInterval;
		[Export ("pingInterval")]
		int PingInterval { get; set; }

		// @property (assign, nonatomic) BOOL isSendPushIfOffline;
		[Export ("isSendPushIfOffline")]
		bool IsSendPushIfOffline { get; set; }

		// @property (nonatomic, strong) NSString * offlineMessageText;
		[Export ("offlineMessageText", ArgumentSemantic.Strong)]
		string OfflineMessageText { get; set; }

		// @property (assign, nonatomic) EMCallVideoResolution videoResolution;
		[Export ("videoResolution", ArgumentSemantic.Assign)]
		EMCallVideoResolution VideoResolution { get; set; }

		// @property (assign, nonatomic) long maxVideoKbps;
		[Export ("maxVideoKbps")]
		nint MaxVideoKbps { get; set; }

		// @property (assign, nonatomic) int minVideoKbps;
		[Export ("minVideoKbps")]
		int MinVideoKbps { get; set; }

		// @property (assign, nonatomic) BOOL isFixedVideoResolution;
		[Export ("isFixedVideoResolution")]
		bool IsFixedVideoResolution { get; set; }

		// @property (assign, nonatomic) int maxVideoFrameRate;
		[Export ("maxVideoFrameRate")]
		int MaxVideoFrameRate { get; set; }

		// @property (assign, nonatomic) long maxAudioKbps;
		[Export ("maxAudioKbps")]
		nint MaxAudioKbps { get; set; }

		// @property (nonatomic) BOOL enableCustomizeVideoData;
		[Export ("enableCustomizeVideoData")]
		bool EnableCustomizeVideoData { get; set; }

		// @property (nonatomic) BOOL enableReportQuality;
		[Export ("enableReportQuality")]
		bool EnableReportQuality { get; set; }

		// @property (assign, nonatomic) long videoKbps __attribute__((deprecated("")));
		[Export ("videoKbps")]
		nint VideoKbps { get; set; }
	}

	// @interface EMCallLocalView : UIView
	[BaseType (typeof(UIView))]
	interface EMCallLocalView
	{
		// @property (assign, nonatomic) EMCallViewScaleMode scaleMode;
		[Export ("scaleMode", ArgumentSemantic.Assign)]
		EMCallViewScaleMode ScaleMode { get; set; }

		// @property (assign, nonatomic) BOOL previewDirectly;
		[Export ("previewDirectly")]
		bool PreviewDirectly { get; set; }

		// @property (assign, nonatomic) BOOL autoGesture;
		[Export ("autoGesture")]
		bool AutoGesture { get; set; }

		// -(CGPoint)layerPointFromRatioPoint:(CGPoint)aPointOfRatio fromRemote:(BOOL)aFromRemote;
		[Export ("layerPointFromRatioPoint:fromRemote:")]
		CGPoint LayerPointFromRatioPoint (CGPoint aPointOfRatio, bool aFromRemote);

		// -(CGPoint)viewPointFromLayerPoint:(CGPoint)aPointOfLayer;
		[Export ("viewPointFromLayerPoint:")]
		CGPoint ViewPointFromLayerPoint (CGPoint aPointOfLayer);

		// -(CGPoint)devicePointFromLayerPoint:(CGPoint)aPointOfLayer;
		[Export ("devicePointFromLayerPoint:")]
		CGPoint DevicePointFromLayerPoint (CGPoint aPointOfLayer);
	}

	// @interface EMCallRemoteView : UIView
	[BaseType (typeof(UIView))]
	interface EMCallRemoteView
	{
		// @property (assign, nonatomic) EMCallViewScaleMode scaleMode;
		[Export ("scaleMode", ArgumentSemantic.Assign)]
		EMCallViewScaleMode ScaleMode { get; set; }

		// @property (assign, nonatomic) BOOL previewDirectly;
		[Export ("previewDirectly")]
		bool PreviewDirectly { get; set; }

		// -(CGPoint)getInterestForUIPoint:(CGPoint)aPoint;
		[Export ("getInterestForUIPoint:")]
		CGPoint GetInterestForUIPoint (CGPoint aPoint);
	}

	// @interface EMCallSession : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCallSession
	{
		// @property (readonly, nonatomic, strong) NSString * callId;
		[Export ("callId", ArgumentSemantic.Strong)]
		string CallId { get; }

		// @property (readonly, nonatomic, strong) NSString * localName;
		[Export ("localName", ArgumentSemantic.Strong)]
		string LocalName { get; }

		// @property (readonly, nonatomic) EMCallType type;
		[Export ("type")]
		EMCallType Type { get; }

		// @property (readonly, nonatomic) BOOL isCaller;
		[Export ("isCaller")]
		bool IsCaller { get; }

		// @property (readonly, nonatomic, strong) NSString * remoteName;
		[Export ("remoteName", ArgumentSemantic.Strong)]
		string RemoteName { get; }

		// @property (readonly, nonatomic) EMCallSessionStatus status;
		[Export ("status")]
		EMCallSessionStatus Status { get; }

		// @property (nonatomic, strong) EMCallLocalView * localVideoView;
		[Export ("localVideoView", ArgumentSemantic.Strong)]
		EMCallLocalView LocalVideoView { get; set; }

		// @property (nonatomic, strong) EMCallRemoteView * remoteVideoView;
		[Export ("remoteVideoView", ArgumentSemantic.Strong)]
		EMCallRemoteView RemoteVideoView { get; set; }

		// @property (readonly, nonatomic) EMCallConnectType connectType;
		[Export ("connectType")]
		EMCallConnectType ConnectType { get; }

		// @property (readonly, nonatomic) int videoLatency;
		[Export ("videoLatency")]
		int VideoLatency { get; }

		// @property (readonly, nonatomic) int localVideoFrameRate;
		[Export ("localVideoFrameRate")]
		int LocalVideoFrameRate { get; }

		// @property (readonly, nonatomic) int remoteVideoFrameRate;
		[Export ("remoteVideoFrameRate")]
		int RemoteVideoFrameRate { get; }

		// @property (readonly, nonatomic) int localVideoBitrate;
		[Export ("localVideoBitrate")]
		int LocalVideoBitrate { get; }

		// @property (readonly, nonatomic) int remoteVideoBitrate;
		[Export ("remoteVideoBitrate")]
		int RemoteVideoBitrate { get; }

		// @property (readonly, nonatomic) int localVideoLostRateInPercent;
		[Export ("localVideoLostRateInPercent")]
		int LocalVideoLostRateInPercent { get; }

		// @property (readonly, nonatomic) int remoteVideoLostRateInPercent;
		[Export ("remoteVideoLostRateInPercent")]
		int RemoteVideoLostRateInPercent { get; }

		// @property (readonly, nonatomic) CGSize remoteVideoResolution;
		[Export ("remoteVideoResolution")]
		CGSize RemoteVideoResolution { get; }

		// @property (readonly, nonatomic) NSString * ext;
		[Export ("ext")]
		string Ext { get; }

		// -(EMError *)pauseVoice;
		[Export ("pauseVoice")]
		//[Verify (MethodToProperty)]
		EMError PauseVoice { get; }

		// -(EMError *)resumeVoice;
		[Export ("resumeVoice")]
		//[Verify (MethodToProperty)]
		EMError ResumeVoice { get; }

		// -(EMError *)pauseVideo;
		[Export ("pauseVideo")]
		//[Verify (MethodToProperty)]
		EMError PauseVideo { get; }

		// -(EMError *)resumeVideo;
		[Export ("resumeVideo")]
		//[Verify (MethodToProperty)]
		EMError ResumeVideo { get; }

		// -(void)switchCameraPosition:(BOOL)aIsFrontCamera;
		[Export ("switchCameraPosition:")]
		void SwitchCameraPosition (bool aIsFrontCamera);
	}

    partial interface IEMCallManagerDelegate {}

    // @protocol EMCallManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMCallManagerDelegate
	{
		// @optional -(void)callDidReceive:(EMCallSession *)aSession;
		[Export ("callDidReceive:")]
		void CallDidReceive (EMCallSession aSession);

		// @optional -(void)callDidConnect:(EMCallSession *)aSession;
		[Export ("callDidConnect:")]
		void CallDidConnect (EMCallSession aSession);

		// @optional -(void)callDidAccept:(EMCallSession *)aSession;
		[Export ("callDidAccept:")]
		void CallDidAccept (EMCallSession aSession);

		// @optional -(void)callDidEnd:(EMCallSession *)aSession reason:(EMCallEndReason)aReason error:(EMError *)aError;
		[Export ("callDidEnd:reason:error:")]
		void CallDidEnd (EMCallSession aSession, EMCallEndReason aReason, EMError aError);

		// @optional -(void)callStateDidChange:(EMCallSession *)aSession type:(EMCallStreamingStatus)aType;
		[Export ("callStateDidChange:type:")]
		void CallStateDidChange (EMCallSession aSession, EMCallStreamingStatus aType);

		// @optional -(void)callNetworkDidChange:(EMCallSession *)aSession status:(EMCallNetworkStatus)aStatus;
		[Export ("callNetworkDidChange:status:")]
		void CallNetworkDidChange (EMCallSession aSession, EMCallNetworkStatus aStatus);

		// @optional -(void)callDidCustomAudioSessionCategoryOptionsWithCategory:(NSString *)aCategory;
		[Export ("callDidCustomAudioSessionCategoryOptionsWithCategory:")]
		void CallDidCustomAudioSessionCategoryOptionsWithCategory (string aCategory);
	}

    partial interface IEMCallBuilderDelegate {}

    // @protocol EMCallBuilderDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMCallBuilderDelegate
	{
		// @optional -(void)callRemoteOffline:(NSString *)aRemoteName;
		[Export ("callRemoteOffline:")]
		void CallRemoteOffline (string aRemoteName);
	}

    partial interface IIEMCallManager {}

    // @protocol IEMCallManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMCallManager
	{
		// @optional -(void)addDelegate:(id<EMCallManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMCallManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @optional -(void)removeDelegate:(id<EMCallManagerDelegate>)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (IEMCallManagerDelegate aDelegate);

		// @optional -(void)setBuilderDelegate:(id<>)aDelegate;
		[Export ("setBuilderDelegate:")]
		void SetBuilderDelegate (IEMCallBuilderDelegate aDelegate);

		// @optional -(void)setCallOptions:(EMCallOptions *)aOptions;
		[Export ("setCallOptions:")]
		void SetCallOptions (EMCallOptions aOptions);

		// @optional -(EMCallOptions *)getCallOptions;
		[Export ("getCallOptions")]
		//[Verify (MethodToProperty)]
		EMCallOptions CallOptions { get; }

		// @optional -(void)startCall:(EMCallType)aType remoteName:(NSString *)aRemoteName ext:(NSString *)aExt completion:(void (^)(EMCallSession *, EMError *))aCompletionBlock;
		[Export ("startCall:remoteName:ext:completion:")]
		void StartCall (EMCallType aType, string aRemoteName, string aExt, Action<EMCallSession, EMError> aCompletionBlock);

		// @optional -(EMError *)answerIncomingCall:(NSString *)aCallId;
		[Export ("answerIncomingCall:")]
		EMError AnswerIncomingCall (string aCallId);

		// @optional -(EMError *)endCall:(NSString *)aCallId reason:(EMCallEndReason)aReason;
		[Export ("endCall:reason:")]
		EMError EndCall (string aCallId, EMCallEndReason aReason);

		// @optional -(void)forceEndAllCall;
		[Export ("forceEndAllCall")]
		void ForceEndAllCall ();

		// @optional -(void)inputVideoSampleBuffer:(CMSampleBufferRef)aSampleBuffer callId:(NSString *)aCallId format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoSampleBuffer:callId:format:rotation:completion:")]
		unsafe void InputVideoSampleBuffer (CMSampleBuffer aSampleBuffer, string aCallId, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional -(void)inputVideoPixelBuffer:(CVPixelBufferRef)aPixelBuffer callId:(NSString *)aCallId format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoPixelBuffer:callId:format:rotation:completion:")]
		unsafe void InputVideoPixelBuffer (CVPixelBuffer aPixelBuffer, string aCallId, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional -(void)inputVideoData:(NSData *)aData callId:(NSString *)aCallId widthInPixels:(size_t)aWidth heightInPixels:(size_t)aHeight format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoData:callId:widthInPixels:heightInPixels:format:rotation:completion:")]
		void InputVideoData (NSData aData, string aCallId, nuint aWidth, nuint aHeight, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional -(void)startVoiceCall:(NSString *)aUsername completion:(void (^)(EMCallSession *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Export ("startVoiceCall:completion:")]
		void StartVoiceCall (string aUsername, Action<EMCallSession, EMError> aCompletionBlock);

		// @optional -(void)startVideoCall:(NSString *)aUsername completion:(void (^)(EMCallSession *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Export ("startVideoCall:completion:")]
		void StartVideoCall (string aUsername, Action<EMCallSession, EMError> aCompletionBlock);
	}

	// @interface Call (EMClient)
	// [Category]
	// [BaseType (typeof(EMClient))]
	partial interface EMClient
	{
        // @property (readonly, nonatomic, strong) id<EMCallManager> callManager;
        [Export("callManager", ArgumentSemantic.Strong)]
        IIEMCallManager CallManager { get; }
	}

	// @interface EMCallMember : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCallMember
	{
		// @property (readonly, nonatomic, strong) NSString * memberId;
		[Export ("memberId", ArgumentSemantic.Strong)]
		string MemberId { get; }

		// @property (readonly, nonatomic, strong) NSString * memberName;
		[Export ("memberName", ArgumentSemantic.Strong)]
		string MemberName { get; }

		// @property (readonly, nonatomic, strong) NSString * ext;
		[Export ("ext", ArgumentSemantic.Strong)]
		string Ext { get; }
	}

	// @interface EMCallConference : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCallConference
	{
		// @property (readonly, nonatomic, strong) NSString * callId;
		[Export ("callId", ArgumentSemantic.Strong)]
		string CallId { get; }

		// @property (readonly, nonatomic, strong) NSString * confId;
		[Export ("confId", ArgumentSemantic.Strong)]
		string ConfId { get; }

		// @property (readonly, nonatomic, strong) NSString * localName;
		[Export ("localName", ArgumentSemantic.Strong)]
		string LocalName { get; }

		// @property (nonatomic) EMConferenceType type;
		[Export ("type", ArgumentSemantic.Assign)]
		EMConferenceType Type { get; set; }

		// @property (nonatomic) EMConferenceRole role;
		[Export ("role", ArgumentSemantic.Assign)]
		EMConferenceRole Role { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * adminIds;
		[Export ("adminIds", ArgumentSemantic.Strong)]
		string[] AdminIds { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * speakerIds;
		[Export ("speakerIds", ArgumentSemantic.Strong)]
		string[] SpeakerIds { get; set; }

		// @property (nonatomic) NSInteger memberCount;
		[Export ("memberCount")]
		nint MemberCount { get; set; }
	}

	// @interface EMCallStream : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCallStream
	{
		// @property (readonly, nonatomic, strong) NSString * streamId;
		[Export ("streamId", ArgumentSemantic.Strong)]
		string StreamId { get; }

		// @property (readonly, nonatomic, strong) NSString * streamName;
		[Export ("streamName", ArgumentSemantic.Strong)]
		string StreamName { get; }

		// @property (readonly, nonatomic, strong) NSString * memberName;
		[Export ("memberName", ArgumentSemantic.Strong)]
		string MemberName { get; }

		// @property (readonly, nonatomic, strong) NSString * userName;
		[Export ("userName", ArgumentSemantic.Strong)]
		string UserName { get; }

		// @property (readonly, nonatomic) BOOL enableVoice;
		[Export ("enableVoice")]
		bool EnableVoice { get; }

		// @property (readonly, nonatomic) BOOL enableVideo;
		[Export ("enableVideo")]
		bool EnableVideo { get; }

		// @property (readonly, nonatomic, strong) NSString * ext;
		[Export ("ext", ArgumentSemantic.Strong)]
		string Ext { get; }

		// @property (nonatomic) EMStreamType type;
		[Export ("type", ArgumentSemantic.Assign)]
		EMStreamType Type { get; set; }
	}

	// @interface EMStreamParam : NSObject
	[BaseType (typeof(NSObject))]
	interface EMStreamParam
	{
		// @property (copy, nonatomic) NSString * streamName;
		[Export ("streamName")]
		string StreamName { get; set; }

		// @property (nonatomic) EMStreamType type;
		[Export ("type", ArgumentSemantic.Assign)]
		EMStreamType Type { get; set; }

		// @property (nonatomic) BOOL enableVideo;
		[Export ("enableVideo")]
		bool EnableVideo { get; set; }

		// @property (nonatomic) BOOL isMute;
		[Export ("isMute")]
		bool IsMute { get; set; }

		// @property (copy, nonatomic) NSString * ext;
		[Export ("ext")]
		string Ext { get; set; }

		// @property (nonatomic) BOOL enableCustomizeVideoData;
		[Export ("enableCustomizeVideoData")]
		bool EnableCustomizeVideoData { get; set; }

		// @property (assign, nonatomic) BOOL isBackCamera;
		[Export ("isBackCamera")]
		bool IsBackCamera { get; set; }

		// @property (assign, nonatomic) BOOL isFixedVideoResolution;
		[Export ("isFixedVideoResolution")]
		bool IsFixedVideoResolution { get; set; }

		// @property (assign, nonatomic) int maxVideoKbps;
		[Export ("maxVideoKbps")]
		int MaxVideoKbps { get; set; }

		// @property (assign, nonatomic) int minVideoKbps;
		[Export ("minVideoKbps")]
		int MinVideoKbps { get; set; }

		// @property (assign, nonatomic) int maxAudioKbps;
		[Export ("maxAudioKbps")]
		int MaxAudioKbps { get; set; }

		// @property (assign, nonatomic) EMCallVideoResolution videoResolution;
		[Export ("videoResolution", ArgumentSemantic.Assign)]
		EMCallVideoResolution VideoResolution { get; set; }

		// @property (nonatomic, strong) EMCallLocalView * localView;
		[Export ("localView", ArgumentSemantic.Strong)]
		EMCallLocalView LocalView { get; set; }

		// @property (nonatomic, strong) UIView * desktopView;
		[Export ("desktopView", ArgumentSemantic.Strong)]
		UIView DesktopView { get; set; }

		// -(instancetype)initWithStreamName:(NSString *)aStreamName;
		[Export ("initWithStreamName:")]
		IntPtr Constructor (string aStreamName);
	}

    partial interface IEMConferenceManagerDelegate {}

    // @protocol EMConferenceManagerDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMConferenceManagerDelegate
	{
		// @optional -(void)memberDidJoin:(EMCallConference *)aConference member:(EMCallMember *)aMember;
		[Export ("memberDidJoin:member:")]
		void MemberDidJoin (EMCallConference aConference, EMCallMember aMember);

		// @optional -(void)memberDidLeave:(EMCallConference *)aConference member:(EMCallMember *)aMember;
		[Export ("memberDidLeave:member:")]
		void MemberDidLeave (EMCallConference aConference, EMCallMember aMember);

		// @optional -(void)roleDidChanged:(EMCallConference *)aConference;
		[Export ("roleDidChanged:")]
		void RoleDidChanged (EMCallConference aConference);

		// @optional -(void)streamDidUpdate:(EMCallConference *)aConference addStream:(EMCallStream *)aStream;
		[Export ("streamDidUpdate:addStream:")]
		void StreamDidUpdateAndAddStream (EMCallConference aConference, EMCallStream aStream);

		// @optional -(void)streamDidUpdate:(EMCallConference *)aConference removeStream:(EMCallStream *)aStream;
		[Export ("streamDidUpdate:removeStream:")]
		void StreamDidUpdateAndRemoveStream (EMCallConference aConference, EMCallStream aStream);

		// @optional -(void)streamDidUpdate:(EMCallConference *)aConference stream:(EMCallStream *)aStream;
		[Export ("streamDidUpdate:stream:")]
		void StreamDidUpdateAndStream (EMCallConference aConference, EMCallStream aStream);

		// @optional -(void)conferenceDidEnd:(EMCallConference *)aConference reason:(EMCallEndReason)aReason error:(EMError *)aError;
		[Export ("conferenceDidEnd:reason:error:")]
		void ConferenceDidEnd (EMCallConference aConference, EMCallEndReason aReason, EMError aError);

		// @optional -(void)streamStartTransmitting:(EMCallConference *)aConference streamId:(NSString *)aStreamId;
		[Export ("streamStartTransmitting:streamId:")]
		void StreamStartTransmitting (EMCallConference aConference, string aStreamId);

		// @optional -(void)conferenceNetworkDidChange:(EMCallConference *)aConference status:(EMCallNetworkStatus)aStatus;
		[Export ("conferenceNetworkDidChange:status:")]
		void ConferenceNetworkDidChange (EMCallConference aConference, EMCallNetworkStatus aStatus);

		// @optional -(void)conferenceSpeakerDidChange:(EMCallConference *)aConference speakingStreamIds:(NSArray *)aStreamIds;
		[Export ("conferenceSpeakerDidChange:speakingStreamIds:")]
		//[Verify (StronglyTypedNSArray)]
		void ConferenceSpeakerDidChange (EMCallConference aConference, NSObject[] aStreamIds);

		// @optional -(void)userDidJoin:(EMCallConference *)aConference user:(NSString *)aUserName __attribute__((deprecated("")));
		[Export ("userDidJoin:user:")]
		void UserDidJoin (EMCallConference aConference, string aUserName);

		// @optional -(void)userDidLeave:(EMCallConference *)aConference user:(NSString *)aUserName __attribute__((deprecated("")));
		[Export ("userDidLeave:user:")]
		void UserDidLeave (EMCallConference aConference, string aUserName);

		// @optional -(void)userDidRecvInvite:(NSString *)aConfId password:(NSString *)aPassword ext:(NSString *)aExt __attribute__((deprecated("")));
		[Export ("userDidRecvInvite:password:ext:")]
		void UserDidRecvInvite (string aConfId, string aPassword, string aExt);
	}

    partial interface IIEMConferenceManager {}

    // @protocol IEMConferenceManager <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IEMConferenceManager
	{
		// @optional -(void)addDelegate:(id<EMConferenceManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (IEMConferenceManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @optional -(void)removeDelegate:(id<EMConferenceManagerDelegate>)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (IEMConferenceManagerDelegate aDelegate);

		// @optional -(void)setAppkey:(NSString *)aAppkey username:(NSString *)aUsername token:(NSString *)aToken;
		[Export ("setAppkey:username:token:")]
		void SetAppkey (string aAppkey, string aUsername, string aToken);

		// @optional -(NSString *)getMemberNameWithAppkey:(NSString *)aAppkey username:(NSString *)aUserName;
		[Export ("getMemberNameWithAppkey:username:")]
		string GetMemberNameWithAppkey (string aAppkey, string aUserName);

		// @optional -(void)getConference:(NSString *)aConfId password:(NSString *)aPassword completion:(void (^)(EMCallConference *, EMError *))aCompletionBlock;
		[Export ("getConference:password:completion:")]
		void GetConference (string aConfId, string aPassword, Action<EMCallConference, EMError> aCompletionBlock);

		// @optional -(void)createAndJoinConferenceWithType:(EMConferenceType)aType password:(NSString *)aPassword completion:(void (^)(EMCallConference *, NSString *, EMError *))aCompletionBlock;
		[Export ("createAndJoinConferenceWithType:password:completion:")]
		void CreateAndJoinConferenceWithType (EMConferenceType aType, string aPassword, Action<EMCallConference, NSString, EMError> aCompletionBlock);

		// @optional -(void)joinConferenceWithConfId:(NSString *)aConfId password:(NSString *)aPassword completion:(void (^)(EMCallConference *, EMError *))aCompletionBlock;
		[Export ("joinConferenceWithConfId:password:completion:")]
		void JoinConferenceWithConfId (string aConfId, string aPassword, Action<EMCallConference, EMError> aCompletionBlock);

		// @optional -(void)joinConferenceWithTicket:(NSString *)aTicket completion:(void (^)(EMCallConference *, EMError *))aCompletionBlock;
		[Export ("joinConferenceWithTicket:completion:")]
		void JoinConferenceWithTicket (string aTicket, Action<EMCallConference, EMError> aCompletionBlock);

		// @optional -(void)publishConference:(EMCallConference *)aCall streamParam:(EMStreamParam *)aStreamParam completion:(void (^)(NSString *, EMError *))aCompletionBlock;
		[Export ("publishConference:streamParam:completion:")]
		void PublishConference (EMCallConference aCall, EMStreamParam aStreamParam, Action<NSString, EMError> aCompletionBlock);

		// @optional -(void)unpublishConference:(EMCallConference *)aCall streamId:(NSString *)aStreamId completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("unpublishConference:streamId:completion:")]
		void UnpublishConference (EMCallConference aCall, string aStreamId, Action<EMError> aCompletionBlock);

		// @optional -(void)subscribeConference:(EMCallConference *)aCall streamId:(NSString *)aStreamId remoteVideoView:(EMCallRemoteView *)aRemoteView completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("subscribeConference:streamId:remoteVideoView:completion:")]
		void SubscribeConference (EMCallConference aCall, string aStreamId, EMCallRemoteView aRemoteView, Action<EMError> aCompletionBlock);

		// @optional -(void)unsubscribeConference:(EMCallConference *)aCall streamId:(NSString *)aStreamId completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("unsubscribeConference:streamId:completion:")]
		void UnsubscribeConference (EMCallConference aCall, string aStreamId, Action<EMError> aCompletionBlock);

		// @optional -(void)changeMemberRoleWithConfId:(NSString *)aConfId memberNames:(NSArray<NSString *> *)aMemberNameList role:(EMConferenceRole)aRole completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("changeMemberRoleWithConfId:memberNames:role:completion:")]
		void ChangeMemberRoleWithConfId (string aConfId, string[] aMemberNameList, EMConferenceRole aRole, Action<EMError> aCompletionBlock);

		// @optional -(void)kickMemberWithConfId:(NSString *)aConfId memberNames:(NSArray<NSString *> *)aMemberNameList completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("kickMemberWithConfId:memberNames:completion:")]
		void KickMemberWithConfId (string aConfId, string[] aMemberNameList, Action<EMError> aCompletionBlock);

		// @optional -(void)destroyConferenceWithId:(NSString *)aConfId completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("destroyConferenceWithId:completion:")]
		void DestroyConferenceWithId (string aConfId, Action<EMError> aCompletionBlock);

		// @optional -(void)leaveConference:(EMCallConference *)aCall completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("leaveConference:completion:")]
		void LeaveConference (EMCallConference aCall, Action<EMError> aCompletionBlock);

		// @optional -(void)startMonitorSpeaker:(EMCallConference *)aCall timeInterval:(long long)aTimeMillisecond completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("startMonitorSpeaker:timeInterval:completion:")]
		void StartMonitorSpeaker (EMCallConference aCall, long aTimeMillisecond, Action<EMError> aCompletionBlock);

		// @optional -(void)stopMonitorSpeaker:(EMCallConference *)aCall;
		[Export ("stopMonitorSpeaker:")]
		void StopMonitorSpeaker (EMCallConference aCall);

		// @optional -(void)updateConferenceWithSwitchCamera:(EMCallConference *)aCall;
		[Export ("updateConferenceWithSwitchCamera:")]
		void UpdateConferenceWithSwitchCamera (EMCallConference aCall);

		// @optional -(void)updateConference:(EMCallConference *)aCall isMute:(BOOL)aIsMute;
		[Export ("updateConference:isMute:")]
		void UpdateConferenceWithIsMute (EMCallConference aCall, bool aIsMute);

		// @optional -(void)updateConference:(EMCallConference *)aCall enableVideo:(BOOL)aEnableVideo;
		[Export ("updateConference:enableVideo:")]
		void UpdateConferenceWithEnableVideo (EMCallConference aCall, bool aEnableVideo);

		// @optional -(void)updateConference:(EMCallConference *)aCall streamId:(NSString *)aStreamId remoteVideoView:(EMCallRemoteView *)aRemoteView completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("updateConference:streamId:remoteVideoView:completion:")]
		void UpdateConferenceWithRemoteVideoViewAndCompletion (EMCallConference aCall, string aStreamId, EMCallRemoteView aRemoteView, Action<EMError> aCompletionBlock);

		// @optional -(void)updateConference:(EMCallConference *)aCall maxVideoKbps:(int)aMaxVideoKbps;
		[Export ("updateConference:maxVideoKbps:")]
		void UpdateConferenceWithMaxVideoKbps (EMCallConference aCall, int aMaxVideoKbps);

		// @optional -(void)inputVideoSampleBuffer:(CMSampleBufferRef)aSampleBuffer conference:(EMCallConference *)aCall publishedStreamId:(NSString *)aPubStreamId format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoSampleBuffer:conference:publishedStreamId:format:rotation:completion:")]
		unsafe void InputVideoSampleBuffer (CMSampleBuffer aSampleBuffer, EMCallConference aCall, string aPubStreamId, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional -(void)inputVideoPixelBuffer:(CVPixelBufferRef)aPixelBuffer conference:(EMCallConference *)aCall publishedStreamId:(NSString *)aPubStreamId format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoPixelBuffer:conference:publishedStreamId:format:rotation:completion:")]
		unsafe void InputVideoPixelBuffer (CVPixelBuffer aPixelBuffer, EMCallConference aCall, string aPubStreamId, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional -(void)inputVideoData:(NSData *)aData conference:(EMCallConference *)aCall publishedStreamId:(NSString *)aPubStreamId widthInPixels:(size_t)aWidth heightInPixels:(size_t)aHeight format:(EMCallVideoFormat)aFormat rotation:(int)aRotation completion:(void (^)(EMError *))aCompletionBlock;
		[Export ("inputVideoData:conference:publishedStreamId:widthInPixels:heightInPixels:format:rotation:completion:")]
		void InputVideoData (NSData aData, EMCallConference aCall, string aPubStreamId, nuint aWidth, nuint aHeight, EMCallVideoFormat aFormat, int aRotation, Action<EMError> aCompletionBlock);

		// @optional @property (nonatomic) EMConferenceMode mode __attribute__((deprecated("")));
		[Export ("mode", ArgumentSemantic.Assign)]
		EMConferenceMode Mode { get; set; }

		// @optional -(void)createAndJoinConferenceWithPassword:(NSString *)aPassword completion:(void (^)(EMCallConference *, NSString *, EMError *))aCompletionBlock __attribute__((deprecated("")));
		[Export ("createAndJoinConferenceWithPassword:completion:")]
		void CreateAndJoinConferenceWithPassword (string aPassword, Action<EMCallConference, NSString, EMError> aCompletionBlock);

		// @optional -(void)inviteUserToJoinConference:(EMCallConference *)aCall userName:(NSString *)aUserName password:(NSString *)aPassword ext:(NSString *)aExt error:(EMError **)pError __attribute__((deprecated("")));
		[Export ("inviteUserToJoinConference:userName:password:ext:error:")]
		void InviteUserToJoinConference (EMCallConference aCall, string aUserName, string aPassword, string aExt, out EMError pError);
	}

	// @interface Conference (EMClient)
	 //[Category]
	 //[BaseType (typeof(EMClient))]
	partial interface EMClient
	{
        // @property (readonly, nonatomic, strong) id<EMConferenceManager> conferenceManager;
        [Export("conferenceManager", ArgumentSemantic.Strong)]
        IIEMConferenceManager ConferenceManager { get; }
    }
}

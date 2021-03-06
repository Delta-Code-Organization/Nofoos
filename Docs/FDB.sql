USE [FDB]
GO
/****** Object:  Table [dbo].[AccountPermissions]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountPermissions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[PermissionGroup] [int] NULL,
 CONSTRAINT [PK_AccountPermissions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountPermissions] ON
INSERT [dbo].[AccountPermissions] ([ID], [AccountID], [PermissionGroup]) VALUES (2, 1, 1)
INSERT [dbo].[AccountPermissions] ([ID], [AccountID], [PermissionGroup]) VALUES (3, 2, 1)
SET IDENTITY_INSERT [dbo].[AccountPermissions] OFF
/****** Object:  Table [dbo].[Certificates]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NULL,
	[CertificateDate] [date] NULL,
	[ValidationDate] [date] NULL,
	[CertificateName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[PhotocopyLink] [nvarchar](max) NULL,
 CONSTRAINT [PK_Certificates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Certificates] ON
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (7, 6, CAST(0x75250B00 AS Date), CAST(0xDB3A0B00 AS Date), N'hhhhhhh', N'gdfgdfgf', N'dgdgdfgf')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (8, 6, CAST(0x75250B00 AS Date), CAST(0xDB3A0B00 AS Date), N'hhhhhhh', N'gdfgdfgf', N'dgdgdfgf')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (9, 6, CAST(0x75250B00 AS Date), CAST(0xDB3A0B00 AS Date), N'hhhhhhh', N'gdfgdfgf', N'dgdgdfgf')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (10, 6, CAST(0x75250B00 AS Date), CAST(0xDB3A0B00 AS Date), N'hhhhhhh', N'gdfgdfgf', N'dgdgdfgf')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (11, 1, CAST(0x6B370B00 AS Date), CAST(0x6B370B00 AS Date), N'Certificate Name 10', N'Desc', N'PhotoLink')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (12, 1, CAST(0x6B370B00 AS Date), CAST(0x6B370B00 AS Date), N'Certificate Name', N'Desc', N'PhotoLink')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (13, 1, CAST(0x6B370B00 AS Date), CAST(0x6B370B00 AS Date), N'Certificate Name', N'Desc', N'PhotoLink')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (14, 1, CAST(0xA4370B00 AS Date), CAST(0xA4370B00 AS Date), N'aaaaaaaaaaaaaaaaaaa', N'aaaaaaaaaaaaaaaaaaaaaaaa', N'C:\fakepath\edit.jpg')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (15, 1, CAST(0xA4370B00 AS Date), CAST(0xA4370B00 AS Date), N'aaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'C:\fakepath\edit.jpg')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (37, 18, CAST(0xBE370B00 AS Date), CAST(0xBE370B00 AS Date), N'con los terrorta', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'/images/UsersImgs/18-con los terrorta.jpg')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (38, 18, CAST(0xBE370B00 AS Date), CAST(0xBE370B00 AS Date), N'dddddddddddddddddddddddddd', N'ddddddddddddddddddddddddddddddddd', N'/images/UsersImgs/18-dddddddddddddddddddddddddd.jpg')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (39, 6, CAST(0xBF370B00 AS Date), CAST(0xBF370B00 AS Date), N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'sssssssssssssssssssssssssssssssssssssssssssssss', N'')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (40, 6, CAST(0xBF370B00 AS Date), CAST(0xBF370B00 AS Date), N'Certificates', N'sssssssssssssssssssssssssssssssssssssssssssssss', N'')
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (41, 17, CAST(0xCC370B00 AS Date), CAST(0xCC370B00 AS Date), N'دكتوراة الطب النفسي', N'دكتوراة في الطب النفسي جامعة اوكسفورد', N'')
SET IDENTITY_INSERT [dbo].[Certificates] OFF
/****** Object:  Table [dbo].[KnowledgeBase]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KnowledgeBase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[ImageURL] [nvarchar](max) NULL,
	[VideoURL] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_KnowledgeBase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [int] NULL,
 CONSTRAINT [PK_LookUps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionRates]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionRates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[SessionID] [int] NULL,
	[Rate] [float] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_GroupRates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TherapistID] [int] NULL,
	[Date] [datetime] NULL,
	[Duration] [int] NULL,
	[SP] [int] NULL,
	[Price] [float] NULL,
	[Type] [int] NULL,
	[Status] [int] NULL,
	[ElapsedTime] [int] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (1, 1, CAST(0x0000A28400A4CB80 AS DateTime), 1, 1, 60, 1, 4, 1)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (2, 1, CAST(0x0000A285004A2860 AS DateTime), 50, 1, 60, 1, 10, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (3, 2, CAST(0x0000A29500C5C100 AS DateTime), 50, 5, 40, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (4, 1, CAST(0x0000A281003DCC50 AS DateTime), 50, 2, 60, 1, 11, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (5, 1, CAST(0x0000A285004A2860 AS DateTime), 80, 1, 100, 1, 11, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (6, 3, CAST(0x0000A2860107AC00 AS DateTime), 50, 1, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (7, 3, CAST(0x0000A282010E89D0 AS DateTime), 50, 1, 50, 1, 8, 0)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
/****** Object:  Table [dbo].[SessionUser]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NULL,
	[OTSessionID] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_UserSessions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SessionUser] ON
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (2, 1, N'1_MX4zMzEyMjQ3Mn5-U2F0IE5vdiAyMyAwMjo0NzowNyBQU1QgMjAxM34wLjA3NjE4MjYwNH4', 1, 2)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (3, 3, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (4, 5, N'', 1, 11)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (5, 6, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (6, 7, N'', 1, 10)
SET IDENTITY_INSERT [dbo].[SessionUser] OFF
/****** Object:  Table [dbo].[Therapist]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Therapist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[ProfileImageLink] [nvarchar](max) NULL,
	[Title] [nvarchar](50) NULL,
	[Bio] [nvarchar](max) NULL,
	[TotalSession] [int] NULL,
	[TotalScore] [float] NULL,
	[CostPercentage] [float] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[status] [int] NULL,
	[LastLogin] [datetime] NULL,
	[sessionInfo] [nvarchar](max) NULL,
	[SP1] [int] NULL,
	[SP2] [int] NULL,
	[SP3] [int] NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Doctors_Admins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Therapist] ON
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone]) VALUES (1, N'Mohammed', N'Hegab', N'/content/img/UserImages/Doctors/3.jpg', N'Therapist', NULL, 15, 250, 10, N'hegab@deltacode.co', N'123456', 1, CAST(0x0000A27A00000000 AS DateTime), N's', 1, 2, 3, N'0123456789')
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone]) VALUES (2, N'Ahmed', N'Mahmoud', N'/content/img/UserImages/Doctors/2.jpg', N'Therapist', NULL, 15, 250, 10, N'hegab1@deltacode.co', N'123456', 1, CAST(0x0000A27A00000000 AS DateTime), N's', 1, 2, 3, N'0123456789')
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone]) VALUES (3, N'mohamed', N'Abogazya', N'/content/img/UserImages/Doctors/abogazya@delta.co.png', N'Therapist', N'My bio is awesome', 0, 0, 0, N'abogazya@delta.co', N'123123', 1, CAST(0x0000A28200E18B74 AS DateTime), N'', 1, 2, 5, N'01008822660')
SET IDENTITY_INSERT [dbo].[Therapist] OFF
/****** Object:  Table [dbo].[SystemAccounts]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemAccounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[LastLogin] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_SystemAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SystemAccounts] ON
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (1, N'ziad', N'123456', CAST(0x2C370B00 AS Date), 1)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (2, N'ahmed', N'111111', CAST(0x2D370B00 AS Date), 1)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (3, N'sasa', N'New Password', CAST(0x3C370B00 AS Date), 1)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (4, N'sasa123', N'123123', CAST(0x3C370B00 AS Date), 0)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (5, N'SystemAdminUsername', N'Password', CAST(0x6D370B00 AS Date), 0)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (6, N'Hegab', N'12345', CAST(0xDA370B00 AS Date), 1)
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (7, N'Abogazya', N'123123', CAST(0xDD370B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[SystemAccounts] OFF
/****** Object:  Table [dbo].[UserPayments]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPayments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Amount] [float] NULL,
	[UserID] [int] NULL,
	[SessionID] [int] NULL,
	[PaymentReferenceCode] [nvarchar](50) NULL,
	[PaymentDescription] [nvarchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_UserPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/26/2013 17:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[ProfileImageLink] [nvarchar](max) NULL,
	[DateofBirth] [datetime] NULL,
	[Gender] [int] NULL,
	[Country] [int] NULL,
	[Language] [int] NULL,
	[Password] [nvarchar](max) NULL,
	[LastLogin] [datetime] NULL,
	[Status] [int] NULL,
	[SecretQuestion] [int] NULL,
	[SecretAnswer] [nvarchar](200) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [Username], [FirstName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [LastName]) VALUES (1, N'Hegab', N'Mohammed', N'/content/img/UserImages/Doctors/3.jpg', CAST(0x0000816D00000000 AS DateTime), 0, 1, 2, N'123456', CAST(0x0000A27A00000000 AS DateTime), 1, 1, N'a', N'Hegab')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  StoredProcedure [dbo].[AdvancedSessionSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AdvancedSessionSearch]
@Date datetime = null,
@DoctorID int = null,
@UserID int = null,
@Status int = null
as
select * from UserSessions
where
(UserSessions.StartDate = @Date or @Date is null)
AND
(UserSessions.DoctorID = @DoctorID or @DoctorID is null)
And
(UserSessions.UserID = @UserID or @UserID is null)
And
(UserSessions.status = @Status or @Status is null)
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Users]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UsersUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersUpdate] 
    @ID int,
    @Username nvarchar(50),
    @FirstName nvarchar(50),
    @ProfileImageLink nvarchar(MAX),
    @DateofBirth datetime,
    @Gender int,
    @Country int,
    @Language int,
    @Password nvarchar(MAX),
    @LastLogin datetime,
    @Status int,
    @SecretQuestion int,
    @SecretAnswer nvarchar(200),
    @LastName nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Users]
	SET    [Username] = @Username, [FirstName] = @FirstName, [ProfileImageLink] = @ProfileImageLink, [DateofBirth] = @DateofBirth, [Gender] = @Gender, [Country] = @Country, [Language] = @Language, [Password] = @Password, [LastLogin] = @LastLogin, [Status] = @Status, [SecretQuestion] = @SecretQuestion, [SecretAnswer] = @SecretAnswer, [LastName] = @LastName
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [FirstName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [LastName]
	FROM   [dbo].[Users]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UsersSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [Username], [FirstName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [LastName] 
	FROM   [dbo].[Users] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UsersSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersSearch]
       @ID int = null
      ,@Username nvarchar(50)=null
      ,@FirstName nvarchar(50) = null
      ,@LastName nvarchar(50) = null
      ,@ProfileImageLink nvarchar(50)=null
      ,@DateOfBirthFrom date=null
      ,@DateOfBirthTo datetime=null
      ,@Gender int=null
      ,@Country int=null
      ,@Language int=null
      ,@Balance float=null
      ,@Password nvarchar(max)=null
      ,@LastLoginFrom datetime = null
      ,@LastLoginTo datetime = null
      ,@Status int = null
      ,@SecretQuestion int = null
      ,@SecretAnswer nvarchar(200) = null
    AS
    BEGIN
    SELECT Users.* FROM Users  
    WHERE 
    (Users.ID=@ID OR @ID IS NULL) AND
    (Users.Password=@Password OR @Password IS NULL) AND
    (Users.Username LIKE '%'+@Username+'%' OR @Username IS NULL) AND
    (Users.FirstName LIKE '%'+@FirstName+'%' OR @FirstName IS NULL) AND
    (Users.LastName LIKE '%'+@LastName+'%' OR @LastName IS NULL) AND
    (Users.ProfileImageLink LIKE '%'+@ProfileImageLink+'%' OR @ProfileImageLink IS NULL) AND
    (Users.DateofBirth between @DateOfBirthFrom AND @DateOfBirthTo OR @DateOfBirthFrom IS NULL OR @DateOfBirthTo IS NULL) AND
    (Users.Gender=@Gender OR @Gender IS NULL) AND
    (Users.Country=@Country OR @Country IS NULL) AND
    (Users.Language=@Language OR @Language IS NULL) AND
    (Users.LastLogin between @LastLoginFrom and @LastLoginTo or @LastLoginFrom is null or @LastLoginTo is null) AND
    (Users.Status = @Status or @Status is null) AND
    (Users.SecretQuestion = @SecretQuestion or @SecretQuestion is null) AND
    (Users.SecretAnswer = @SecretAnswer or @SecretAnswer is null)

    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[UsersInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersInsert] 
    @Username nvarchar(50),
    @FirstName nvarchar(50),
    @ProfileImageLink nvarchar(MAX),
    @DateofBirth datetime,
    @Gender int,
    @Country int,
    @Language int,
    @Password nvarchar(MAX),
    @LastLogin datetime,
    @Status int,
    @SecretQuestion int,
    @SecretAnswer nvarchar(200),
    @LastName nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Users] ([Username], [FirstName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [LastName])
	SELECT @Username, @FirstName, @ProfileImageLink, @DateofBirth, @Gender, @Country, @Language, @Password, @LastLogin, @Status, @SecretQuestion, @SecretAnswer, @LastName
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [FirstName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [LastName]
	FROM   [dbo].[Users]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UserPaymentsUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserPaymentsUpdate] 
    @ID int,
    @Date datetime,
    @Amount float,
    @UserID int,
    @SessionID int,
    @PaymentReferenceCode nvarchar(50),
    @PaymentDescription nvarchar(MAX),
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[UserPayments]
	SET    [Date] = @Date, [Amount] = @Amount, [UserID] = @UserID, [SessionID] = @SessionID, [PaymentReferenceCode] = @PaymentReferenceCode, [PaymentDescription] = @PaymentDescription, [Status] = @Status
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Date], [Amount], [UserID], [SessionID], [PaymentReferenceCode], [PaymentDescription], [Status]
	FROM   [dbo].[UserPayments]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UserPaymentsSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserPaymentsSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [Date], [Amount], [UserID], [SessionID], [PaymentReferenceCode], [PaymentDescription], [Status] 
	FROM   [dbo].[UserPayments] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UserPaymentsInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserPaymentsInsert] 
    @Date datetime,
    @Amount float,
    @UserID int,
    @SessionID int,
    @PaymentReferenceCode nvarchar(50),
    @PaymentDescription nvarchar(MAX),
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[UserPayments] ([Date], [Amount], [UserID], [SessionID], [PaymentReferenceCode], [PaymentDescription], [Status])
	SELECT @Date, @Amount, @UserID, @SessionID, @PaymentReferenceCode, @PaymentDescription, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Date], [Amount], [UserID], [SessionID], [PaymentReferenceCode], [PaymentDescription], [Status]
	FROM   [dbo].[UserPayments]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UserPaymentsDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserPaymentsDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[UserPayments]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UpdateDoctorStatus]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateDoctorStatus]
@Status int,
@ID int
as
update Therapist
set
status = @Status
where
ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[TherapistUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TherapistUpdate] 
    @ID int,
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @ProfileImageLink nvarchar(MAX),
    @Title nvarchar(50),
    @Bio nvarchar(MAX),
    @TotalSession int,
    @TotalScore float,
    @CostPercentage float,
    @Username nvarchar(50),
    @Password nvarchar(MAX),
    @status int,
    @LastLogin datetime,
    @sessionInfo nvarchar(MAX),
    @SP1 int,
    @SP2 int,
    @SP3 int,
    @Phone nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Therapist]
	SET    [FirstName] = @FirstName, [LastName] = @LastName, [ProfileImageLink] = @ProfileImageLink, [Title] = @Title, [Bio] = @Bio, [TotalSession] = @TotalSession, [TotalScore] = @TotalScore, [CostPercentage] = @CostPercentage, [Username] = @Username, [Password] = @Password, [status] = @status, [LastLogin] = @LastLogin, [sessionInfo] = @sessionInfo, [SP1] = @SP1, [SP2] = @SP2, [SP3] = @SP3, [Phone] = @Phone
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone]
	FROM   [dbo].[Therapist]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TherapistSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone] 
	FROM   [dbo].[Therapist] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[TherapistSearch]
       @ID int = null
      ,@FirstName nvarchar(50)=null
      ,@LastName nvarchar(50)=null
      ,@ProfileImageLink nvarchar(max)=null
      ,@title nvarchar(50)=null
      ,@bio nvarchar(max)=null
      ,@TotalSessions int=null
      ,@TotalScore float=null
      ,@CostPercentage float=null
      ,@Username nvarchar(50)=null
      ,@Password Nvarchar(MAX) =null
      ,@Status int=null
      ,@SP1 int=null
      ,@SP2 int=null
      ,@SP3 int=null
      ,@Phone nvarchar(50)=null
    AS
    BEGIN
    SELECT * FROM Therapist 
    WHERE 
    (Therapist.ID=@ID OR @ID IS NULL) AND
    (Therapist.SP1 = @SP1 or @SP1 is null) AND
    (Therapist.SP2 = @SP2 or @SP2 is null) AND
    (Therapist.SP3 = @SP3 or @SP3 is null) AND
    (Therapist.Phone = @Phone or @Phone is null)AND
    (Therapist.FirstName like @FirstName OR @FirstName IS NULL) AND
    (Therapist.LastName like @LastName OR @LastName IS NULL) AND
    (Therapist.ProfileImageLink=@ProfileImageLink OR @ProfileImageLink IS NULL) AND
    (Therapist.Title LIKE @title OR @title IS NULL) AND
    (Therapist.Bio LIKE @bio OR @bio IS NULL) AND
    (Therapist.TotalScore=@TotalScore OR @TotalScore IS NULL) AND
    (Therapist.status=@Status OR @Status IS NULL) AND
    (Therapist.Username=@Username OR @Username IS NULL) AND
    (Therapist.Password=@Password OR @Password IS NULL) AND
    (Therapist.TotalSession=@TotalSessions OR @TotalSessions IS NULL) AND
    (Therapist.CostPercentage=@CostPercentage OR @CostPercentage IS NULL)
    
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[TherapistInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TherapistInsert] 
    @FirstName nvarchar(50)=null,
    @LastName nvarchar(50)=null,
    @ProfileImageLink nvarchar(MAX)=null,
    @Title nvarchar(50)=null,
    @Bio nvarchar(MAX)=null,
    @TotalSession int=null,
    @TotalScore float=null,
    @CostPercentage float=null,
    @Username nvarchar(50)=null,
    @Password nvarchar(MAX)=null,
    @status int=null,
    @LastLogin datetime=null,
    @sessionInfo nvarchar(MAX)=null,
    @SP1 int=null,
    @SP2 int=null,
    @SP3 int=null,
    @Phone nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Therapist] ([FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone])
	SELECT @FirstName, @LastName, @ProfileImageLink, @Title, @Bio, @TotalSession, @TotalScore, @CostPercentage, @Username, @Password, @status, @LastLogin, @sessionInfo, @SP1, @SP2, @SP3, @Phone
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone]
	FROM   [dbo].[Therapist]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TherapistDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Therapist]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionUserUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionUserUpdate] 
    @ID int,
    @SessionID int,
    @OTSessionID nvarchar(MAX),
    @UserID int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[SessionUser]
	SET    [SessionID] = @SessionID, [OTSessionID] = @OTSessionID, [UserID] = @UserID, [Status] = @Status
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [SessionID], [OTSessionID], [UserID], [Status]
	FROM   [dbo].[SessionUser]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionUserSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionUserSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [SessionID], [OTSessionID], [UserID], [Status] 
	FROM   [dbo].[SessionUser] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionUserSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SessionUserSearch]
@ID int = null,
@SessionID int = null,
@UserID int = null,
@Status int = null
as
select * from SessionUser
where
(ID = @ID or @ID is null)and
(SessionID = @SessionID or @SessionID is null)and
(UserID = @UserID or @UserID is null)and
(Status = @Status or @Status is null)
GO
/****** Object:  StoredProcedure [dbo].[SessionUserInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionUserInsert] 
    @SessionID int,
    @OTSessionID nvarchar(MAX),
    @UserID int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[SessionUser] ([SessionID], [OTSessionID], [UserID], [Status])
	SELECT @SessionID, @OTSessionID, @UserID, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [SessionID], [OTSessionID], [UserID], [Status]
	FROM   [dbo].[SessionUser]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionUserDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionUserDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[SessionUser]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SystemAccountsUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SystemAccountsUpdate] 
    @ID int,
    @Username nvarchar(50),
    @Password nvarchar(MAX),
    @LastLogin date,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[SystemAccounts]
	SET    [Username] = @Username, [Password] = @Password, [LastLogin] = @LastLogin, [Status] = @Status
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [Password], [LastLogin], [Status]
	FROM   [dbo].[SystemAccounts]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SystemAccountsSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SystemAccountsSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [Username], [Password], [LastLogin], [Status] 
	FROM   [dbo].[SystemAccounts] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SystemAccountsSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SystemAccountsSearch]
       @ID int = null
      ,@Username nvarchar(50)=null
      ,@Password nvarchar(50)=null
      ,@LastLoginFrom Date=null 
      ,@LastLoginTo Date=null
    AS
    BEGIN
    SELECT * FROM SystemAccounts 
    WHERE 
    (SystemAccounts.ID=@ID OR @ID IS NULL) AND
    (SystemAccounts.LastLogin between @LastLoginFrom and @LastLoginTo  or @LastLoginFrom is null or @LastLoginTo is null) AND
    (SystemAccounts.Username = @Username or @Username is null) AND
    (SystemAccounts.Password=@Password or @Password is null)
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[SystemAccountsInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SystemAccountsInsert] 
    @Username nvarchar(50),
    @Password nvarchar(MAX),
    @LastLogin date,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[SystemAccounts] ([Username], [Password], [LastLogin], [Status])
	SELECT @Username, @Password, @LastLogin, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [Password], [LastLogin], [Status]
	FROM   [dbo].[SystemAccounts]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SystemAccountsDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SystemAccountsDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[SystemAccounts]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionsUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionsUpdate] 
    @ID int,
    @TherapistID int,
    @Date datetime,
    @Duration int,
    @SP int,
    @Price float,
    @Type int,
    @Status int,
    @ElapsedTime int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Sessions]
	SET    [TherapistID] = @TherapistID, [Date] = @Date, [Duration] = @Duration, [SP] = @SP, [Price] = @Price, [Type] = @Type, [Status] = @Status, [ElapsedTime] = @ElapsedTime
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]
	FROM   [dbo].[Sessions]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionsSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionsSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime] 
	FROM   [dbo].[Sessions] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionsSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SessionsSearch]
@ID int = null,
@TherapistID int = null,
@Date datetime = null,
@Duration int = null,
@SP int = null,
@Price float = null,
@Type int = null,
@Status int = null,
@ElapsedTime int = null
as
select * from Sessions 
where
(ID = @ID or @ID is null) and
(TherapistID = @TherapistID or @TherapistID is null) and
(Date = @Date or @Date is null) and
(Duration = @Duration or @Duration is null) and
(SP = @SP or @SP is null)and
(Price = @Price or @Price is null) and
(Type = @Type or @Type is null) and
(Status = @Status or @Status is null) and
(ElapsedTime = @ElapsedTime or @ElapsedTime is null)

order by Date asc
GO
/****** Object:  StoredProcedure [dbo].[SessionsInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionsInsert] 
    @TherapistID int,
    @Date datetime,
    @Duration int,
    @SP int,
    @Price float,
    @Type int,
    @Status int,
    @ElapsedTime int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Sessions] ([TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime])
	SELECT @TherapistID, @Date, @Duration, @SP, @Price, @Type, @Status, @ElapsedTime
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]
	FROM   [dbo].[Sessions]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionsDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionsDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Sessions]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionRatesUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionRatesUpdate] 
    @ID int,
    @UserID int,
    @SessionID int,
    @Rate float,
    @Date datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[SessionRates]
	SET    [UserID] = @UserID, [SessionID] = @SessionID, [Rate] = @Rate, [Date] = @Date
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [UserID], [SessionID], [Rate], [Date]
	FROM   [dbo].[SessionRates]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionRatesSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionRatesSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [UserID], [SessionID], [Rate], [Date] 
	FROM   [dbo].[SessionRates] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionRatesInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionRatesInsert] 
    @UserID int,
    @SessionID int,
    @Rate float,
    @Date datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[SessionRates] ([UserID], [SessionID], [Rate], [Date])
	SELECT @UserID, @SessionID, @Rate, @Date
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [UserID], [SessionID], [Rate], [Date]
	FROM   [dbo].[SessionRates]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SessionRatesDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SessionRatesDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[SessionRates]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[SelectByID]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectByID]
@ID int = null
as
select * from Users
where
Users.ID = @ID or @ID is null
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectAllUsers]
as
select * from Users
GO
/****** Object:  StoredProcedure [dbo].[SelectAllSessions]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectAllSessions]
as
select * from SessionUser
where
(SessionUser.status = 2)
or
(SessionUser.status = 4)
or
(SessionUser.status = 10)
GO
/****** Object:  StoredProcedure [dbo].[SelectAllDoctors]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectAllDoctors]
as
select * from Therapist
GO
/****** Object:  StoredProcedure [dbo].[LookupsUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LookupsUpdate] 
    @ID int,
    @Name nvarchar(50),
    @Tag int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Lookups]
	SET    [ID] = @ID, [Name] = @Name, [Tag] = @Tag
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Name], [Tag]
	FROM   [dbo].[Lookups]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[LookupsSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LookupsSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [Name], [Tag] 
	FROM   [dbo].[Lookups] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[LookupsSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LookupsSearch]
       @ID int = null
      ,@Name nvarchar(50) = null
      ,@Tag int = null

   
     
    AS
    BEGIN
    SELECT * FROM Lookups   
    WHERE 
    (Lookups.ID=@ID OR @ID IS NULL) AND
    (Lookups.Name LIKE '%'+@Name+'%' OR @Name IS NULL) AND
    (Lookups.Tag = @Tag OR @Tag IS NULL)
    
    
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[LookupsInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LookupsInsert] 
    @ID int,
    @Name nvarchar(50),
    @Tag int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Lookups] ([ID], [Name], [Tag])
	SELECT @ID, @Name, @Tag
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Name], [Tag]
	FROM   [dbo].[Lookups]
	WHERE  [ID] = @ID
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[LookupsDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LookupsDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Lookups]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[KnowledgeBaseUpdate] 
    @ID int,
    @Type int,
    @ImageURL nvarchar(MAX),
    @VideoURL nvarchar(MAX),
    @Text nvarchar(MAX),
    @Title nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[KnowledgeBase]
	SET    [Type] = @Type, [ImageURL] = @ImageURL, [VideoURL] = @VideoURL, [Text] = @Text, [Title] = @Title
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Type], [ImageURL], [VideoURL], [Text], [Title]
	FROM   [dbo].[KnowledgeBase]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[KnowledgeBaseSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [Type], [ImageURL], [VideoURL], [Text], [Title] 
	FROM   [dbo].[KnowledgeBase] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[KnowledgeBaseInsert] 
    @Type int,
    @ImageURL nvarchar(MAX),
    @VideoURL nvarchar(MAX),
    @Text nvarchar(MAX),
    @Title nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[KnowledgeBase] ([Type], [ImageURL], [VideoURL], [Text], [Title])
	SELECT @Type, @ImageURL, @VideoURL, @Text, @Title
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Type], [ImageURL], [VideoURL], [Text], [Title]
	FROM   [dbo].[KnowledgeBase]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[KnowledgeBaseDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[KnowledgeBase]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[GetLastResSession]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetLastResSession]
as
select * from Sessions
where
Sessions.Status = 11
order by Sessions.ID desc
GO
/****** Object:  StoredProcedure [dbo].[GetFirstFiveDoctors]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFirstFiveDoctors]
as
select top 5 * from Therapist
GO
/****** Object:  StoredProcedure [dbo].[GetAllSessions]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllSessions]
as
select * from Sessions
GO
/****** Object:  StoredProcedure [dbo].[GetAllBlogs]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
creATE procedure [dbo].[GetAllBlogs]
as
select * from KnowledgeBase
GO
/****** Object:  StoredProcedure [dbo].[FilterSessions]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FilterSessions]
@TherapistID int = null,
@SP int = null
as
select * from Sessions
where
(Sessions.TherapistID = @TherapistID or @TherapistID is null)
AND
(Sessions.SP = @SP or @SP is null)
GO
/****** Object:  StoredProcedure [dbo].[DoctorSpSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DoctorSpSearch]
@SP int
as
select * from Therapist
where
(Therapist.SP1 = @SP or Therapist.SP2 = @SP or Therapist.SP3 = @SP)
GO
/****** Object:  StoredProcedure [dbo].[DoctorFilterSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DoctorFilterSearch]
@ID int = null,
@SP nvarchar(200) = null
as
select * from Therapist
where
(Therapist.ID = @ID or @ID is null)
AND
(Therapist.SP1 = @SP or Therapist.SP2 = @SP or Therapist.SP3 = @SP or @SP is null)
GO
/****** Object:  StoredProcedure [dbo].[CertificatesUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CertificatesUpdate] 
    @ID int,
    @DoctorID int,
    @CertificateDate date,
    @ValidationDate date,
    @CertificateName nvarchar(50),
    @Description nvarchar(MAX),
    @PhotocopyLink nvarchar(MAX)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Certificates]
	SET    [DoctorID] = @DoctorID, [CertificateDate] = @CertificateDate, [ValidationDate] = @ValidationDate, [CertificateName] = @CertificateName, [Description] = @Description, [PhotocopyLink] = @PhotocopyLink
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]
	FROM   [dbo].[Certificates]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[CertificatesSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CertificatesSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink] 
	FROM   [dbo].[Certificates] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[CertificatesSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CertificatesSearch]
       @ID int=null
       , @DoctorID int=null
      ,@FirstName NVARCHAR(50)=null
     ,@CertificateDateFrom Date=null
      ,@CertificateDateTo Date=null
     ,@CertificateName NVARCHAR(50)=null
     ,@ExpirationDateFrom Date=null
     ,@ExpirationDateTo Date=null
    AS
    BEGIN
    SELECT Certificates.* FROM Certificates 
    WHERE 
    (DoctorID = @DoctorID or @DoctorID IS NULL) AND
    (Certificates.ID=@ID OR @ID IS NULL) AND
    (CertificateName like '%'+@CertificateName+'%' or @CertificateName is null) AND
    (CertificateDate between @CertificateDateFrom and @CertificateDateTo or @CertificateDateFrom is null or @CertificateDateTo is null) AND
    (ValidationDate between @ExpirationDateFrom and @ExpirationDateTo or @ExpirationDateFrom is null or @ExpirationDateTo is null)
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[CertificatesInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CertificatesInsert] 
    @DoctorID int,
    @CertificateDate date,
    @ValidationDate date,
    @CertificateName nvarchar(50),
    @Description nvarchar(MAX),
    @PhotocopyLink nvarchar(MAX)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Certificates] ([DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink])
	SELECT @DoctorID, @CertificateDate, @ValidationDate, @CertificateName, @Description, @PhotocopyLink
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]
	FROM   [dbo].[Certificates]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[CertificatesDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CertificatesDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Certificates]
	WHERE  [ID] = @ID

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[AdvancedUserFilter]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AdvancedUserFilter]
@Username nvarchar(50) = null
as
select * from Users
where
(Users.Username like '%' + @Username + '%')
GO
/****** Object:  StoredProcedure [dbo].[AdvancedDoctorFilter]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AdvancedDoctorFilter]
@DoctorName nvarchar(50) = null,
@Status int = null
as
select * from dbo.Therapist
where
(Therapist.FirstName like '%' + @DoctorName + '%' or Therapist.LastName like '%' + @DoctorName + '%' or @DoctorName is null)
AND
(Therapist.status = @Status or @Status is null)
GO
/****** Object:  StoredProcedure [dbo].[AdminSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AdminSearch]
@Username nvarchar(50)=null
as
select * from dbo.SystemAccounts
where
(SystemAccounts.Username like '%'+@UserName+'%' or @UserName is null)
GO
/****** Object:  StoredProcedure [dbo].[AccountPermissionsUpdate]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AccountPermissionsUpdate] 
    @ID int,
    @AccountID int,
    @PermissionGroup int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[AccountPermissions]
	SET    [AccountID] = @AccountID, [PermissionGroup] = @PermissionGroup
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [AccountID], [PermissionGroup]
	FROM   [dbo].[AccountPermissions]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[AccountPermissionsSelect]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AccountPermissionsSelect] 
    @ID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID], [AccountID], [PermissionGroup] 
	FROM   [dbo].[AccountPermissions] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[AccountPermissionsSearch]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountPermissionsSearch]
       @ID                  int=null
      ,@AccountID           int=null
      ,@Permission          int=null
      ,@PermissionGroup     NVARCHAR(50)=null
      
    AS
    BEGIN
    SELECT AccountPermissions.*  FROM AccountPermissions 
    JOIN SystemAccounts ON SystemAccounts.ID=AccountPermissions.AccountID
    WHERE 
    (AccountPermissions.ID=@ID OR @ID IS NULL) AND
    (AccountPermissions.AccountID = @AccountID OR @AccountID IS NULL ) AND 
    (AccountPermissions.PermissionGroup=@Permission or @Permission is null)
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[AccountPermissionsInsert]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AccountPermissionsInsert] 
    @AccountID int,
    @PermissionGroup int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[AccountPermissions] ([AccountID], [PermissionGroup])
	SELECT @AccountID, @PermissionGroup
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [AccountID], [PermissionGroup]
	FROM   [dbo].[AccountPermissions]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[AccountPermissionsDelete]    Script Date: 11/26/2013 17:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AccountPermissionsDelete] 
    @ID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[AccountPermissions]
	WHERE  [ID] = @ID

	COMMIT
GO

USE [NofoosDB]
GO
/****** Object:  Table [dbo].[AccountPermissions]    Script Date: 12/25/2013 14:48:44 ******/
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
/****** Object:  Table [dbo].[Certificates]    Script Date: 12/25/2013 14:48:44 ******/
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
INSERT [dbo].[Certificates] ([ID], [DoctorID], [CertificateDate], [ValidationDate], [CertificateName], [Description], [PhotocopyLink]) VALUES (1, 3, CAST(0xF6370B00 AS Date), CAST(0xF6370B00 AS Date), N'Master Degree of Psychology', N'dededededeeeeeeedddddddddddddddddddedddddddddddddddddddddddddddddddddddddddddddddddddddededeeeeeeeeeee', N'/content/img/UserImages/Doctors/certificate/b7ab65ac-7479-4d71-a10b-21c3783a8b05.png')
SET IDENTITY_INSERT [dbo].[Certificates] OFF
/****** Object:  Table [dbo].[FTrans]    Script Date: 12/25/2013 14:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTrans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[SessionID] [int] NULL,
	[PaymentMethod] [int] NULL,
	[Amount] [float] NULL,
	[PaymentInfo] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_FTrans] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FTrans] ON
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (1, 1, 27, 1, 50, N'null', CAST(0x0000A29B00000000 AS DateTime))
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (2, 1, 26, 1, 50, N'null', CAST(0x0000A29B00000000 AS DateTime))
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (3, 1, 27, 1, 50, N'null', CAST(0x0000A2A400000000 AS DateTime))
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (4, 1, 17, 1, 50, N'null', CAST(0x0000A29C00000000 AS DateTime))
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (5, 1, 28, 1, 50, N'null', CAST(0x0000A29C00000000 AS DateTime))
INSERT [dbo].[FTrans] ([ID], [UserID], [SessionID], [PaymentMethod], [Amount], [PaymentInfo], [Date]) VALUES (6, 1, 29, 1, 90, N'null', CAST(0x0000A29C00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[FTrans] OFF
/****** Object:  Table [dbo].[KnowledgeBase]    Script Date: 12/25/2013 14:48:44 ******/
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
SET IDENTITY_INSERT [dbo].[KnowledgeBase] ON
INSERT [dbo].[KnowledgeBase] ([ID], [Type], [ImageURL], [VideoURL], [Text], [Title]) VALUES (3, 1, N'/content/img/knowledgebase/001d6081-a07b-45e8-a981-cd1660dc6537.png', N' ', N'hhdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd', N'This is the second Post')
INSERT [dbo].[KnowledgeBase] ([ID], [Type], [ImageURL], [VideoURL], [Text], [Title]) VALUES (4, 2, N' ', N'http://www.youtube.com/embed/T953zdcvUCU', N'jhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhjhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhjhjhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh', N'Video Post')
SET IDENTITY_INSERT [dbo].[KnowledgeBase] OFF
/****** Object:  Table [dbo].[Lookups]    Script Date: 12/25/2013 14:48:44 ******/
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
/****** Object:  Table [dbo].[SessionRates]    Script Date: 12/25/2013 14:48:44 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 12/25/2013 14:48:44 ******/
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
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (12, 1, CAST(0x0000A29C01206420 AS DateTime), 50, 0, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (17, 1, CAST(0x0000A2A600FF6EA0 AS DateTime), 50, 0, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (20, 3, CAST(0x0000A29600F099C0 AS DateTime), 40, 0, 40, 1, 4, 40)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (21, 1, CAST(0x0000A29A00FF6EA0 AS DateTime), 50, 1, 50, 1, 12, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (25, 3, CAST(0x0000A29B00D68210 AS DateTime), 50, 0, 40, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (26, 3, CAST(0x0000A29E00DEBF70 AS DateTime), 50, 0, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (27, 3, CAST(0x0000A29C00FFB4F0 AS DateTime), 50, 0, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (28, 3, CAST(0x0000A29C00C1E8A0 AS DateTime), 50, 0, 50, 1, 8, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (29, 3, CAST(0x0000A29C00CCE520 AS DateTime), 60, 0, 90, 1, 2, 58)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (30, 3, CAST(0x0000A29F00C1E8A0 AS DateTime), 50, 0, 50, 1, 6, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (31, 3, CAST(0x0000A29F00C08910 AS DateTime), 40, 0, 50, 1, 6, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (32, 3, CAST(0x0000A29F00CCE520 AS DateTime), 50, 0, 50, 1, 6, 0)
INSERT [dbo].[Sessions] ([ID], [TherapistID], [Date], [Duration], [SP], [Price], [Type], [Status], [ElapsedTime]) VALUES (33, 3, CAST(0x0000A29F00D63BC0 AS DateTime), 50, 0, 50, 1, 6, 0)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
/****** Object:  Table [dbo].[SessionUser]    Script Date: 12/25/2013 14:48:44 ******/
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
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (7, 12, N'', 6, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (8, 20, N'1_MX4zMzEyMjQ3Mn5-TW9uIERlYyAxNiAwNjozNjozOCBQU1QgMjAxM34wLjM3NTQ0MDc4fg', 1, 2)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (9, 21, N'', 1, 12)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (10, 25, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (11, 26, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (17, 27, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (18, 17, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (19, 28, N'', 1, 10)
INSERT [dbo].[SessionUser] ([ID], [SessionID], [OTSessionID], [UserID], [Status]) VALUES (20, 29, N'1_MX4zMzEyMjQ3Mn5-U3VuIERlYyAyMiAwNDoyMDo0MSBQU1QgMjAxM34wLjUzOTQyNTczfg', 1, 2)
SET IDENTITY_INSERT [dbo].[SessionUser] OFF
/****** Object:  Table [dbo].[SystemAccounts]    Script Date: 12/25/2013 14:48:44 ******/
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
INSERT [dbo].[SystemAccounts] ([ID], [Username], [Password], [LastLogin], [Status]) VALUES (8, N'mohamed', N'12345', CAST(0xE1370B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[SystemAccounts] OFF
/****** Object:  Table [dbo].[Therapist]    Script Date: 12/25/2013 14:48:44 ******/
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
	[Language] [int] NULL,
	[HashCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Doctors_Admins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Therapist] ON
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone], [Language], [HashCode]) VALUES (1, N'Mohammed', N'Hegab', N'/content/img/UserImages/Doctors/hegab@deltacode.co.png', N'Therapist', N'master degree of hhhhhhh faculty of hahahahahahahahahahahahahahaha', 15, 250, 10, N'hegab@deltacode.co', N'123456', 1, CAST(0x0000A27A00000000 AS DateTime), N's', 1, 5, 6, N'0123456789', 0, N'')
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone], [Language], [HashCode]) VALUES (3, N'mohamed', N'Abogazya', N'/content/img/UserImages/Doctors/abogazya@delta.co.png', N'Therapist', N'My bio is awesome', 0, 0, 0, N'abogazya@delta.co', N'123123', 1, CAST(0x0000A28200E18B74 AS DateTime), N'', 1, 2, 5, N'01008822660', 1, N'')
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone], [Language], [HashCode]) VALUES (4, N'asd', N'mahdy', N'/content/img/UserImages/Doctors/Default46549878465465.png', N'', N'', 0, 0, 70, N'kkk@k.k', N'12345', 1, CAST(0x0000A29601271694 AS DateTime), N'', 0, 1, 2, N'123123123', 0, NULL)
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone], [Language], [HashCode]) VALUES (5, N'XXX', N'XXX', N'/content/img/UserImages/Doctors/Default46549878465465.png', N'', N'', 0, 0, 70, N'dd@d.com', N'123123', 10, CAST(0x0000A2980110B5D0 AS DateTime), N'', 0, 1, 2, N'1234567', 0, N'23464778-7146-457f-ad2b-2496c6e2e62a')
INSERT [dbo].[Therapist] ([ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone], [Language], [HashCode]) VALUES (6, N'XXX', N'XXX', N'/content/img/UserImages/Doctors/Default46549878465465.png', N'', N'hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh', 0, 0, 70, N'darkness_9988@hotmail.com', N'121212', 10, CAST(0x0000A298011AF198 AS DateTime), N'', 0, 1, 2, N'1234567', 0, N'02ac7aa7-ff91-45d7-ad18-86a0d293c698')
SET IDENTITY_INSERT [dbo].[Therapist] OFF
/****** Object:  Table [dbo].[UserPayments]    Script Date: 12/25/2013 14:48:44 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 12/25/2013 14:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[DisplayName] [nvarchar](50) NULL,
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
	[HashCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (1, N'Hegab', N'Mohammed', N'/content/img/UserImages/Doctors/3.jpg', CAST(0x0000816D00000000 AS DateTime), 0, 1, 2, N'123456', CAST(0x0000A27A00000000 AS DateTime), 1, 1, N'a', N'Hegab')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (2, N'mohamed_Abogazya@delta.co', N'Mohamed', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A28900EFB5DB AS DateTime), 0, 0, 0, N'12345', CAST(0x0000A28900EFB5DB AS DateTime), 11, 0, NULL, N'Abo Gazya')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (3, N'mohamed_Abogazya2@delta.co', N'Abogazya2', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A28D00CE7D2A AS DateTime), 0, 0, 0, N'123123', CAST(0x0000A28D00CE7D2A AS DateTime), 11, 0, NULL, N'68bee5ed-c3c9-473f-8065-7fec93dcaf00')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (5, N'mohamed.abogazya8@gmail.com', N'sadassd', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A28D00DFF980 AS DateTime), 0, 0, 0, N'12345', CAST(0x0000A28D00DFF980 AS DateTime), 1, 0, N'', N'fde9d21d-91eb-42da-84fc-dbadbd9c5ae4')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (6, N'darkness@delta.co', N'master', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A29600CE42E0 AS DateTime), 0, 0, 0, N'12345', CAST(0x0000A29600CE42E0 AS DateTime), 11, 0, NULL, N'34c6b4ba-45ea-4c86-b304-46b22e7ea5e2')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (7, N'X@D.co', N'X', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A29600D536BC AS DateTime), 0, 0, 0, N'12345', CAST(0x0000A29600D536BC AS DateTime), 11, 0, NULL, N'08423b1e-0f90-4151-b5b0-d1b4bc15aef8')
INSERT [dbo].[Users] ([ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]) VALUES (8, N'Guest@delta.co', N'Guest', N'/images/UsersImgs/Users/Default46549878465465.png', CAST(0x0000A29600D65AE2 AS DateTime), 0, 0, 0, N'12345', CAST(0x0000A29600D65AE3 AS DateTime), 11, 0, NULL, N'93d7b7f9-6a5d-4c58-b964-8bccbf6c5700')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  StoredProcedure [dbo].[AdvancedSessionSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UsersUpdate]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersUpdate] 
    @ID int,
    @Username nvarchar(50),
    @DisplayName nvarchar(50),
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
    @HashCode nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Users]
	SET    [Username] = @Username, [DisplayName] = @DisplayName, [ProfileImageLink] = @ProfileImageLink, [DateofBirth] = @DateofBirth, [Gender] = @Gender, [Country] = @Country, [Language] = @Language, [Password] = @Password, [LastLogin] = @LastLogin, [Status] = @Status, [SecretQuestion] = @SecretQuestion, [SecretAnswer] = @SecretAnswer, [HashCode] = @HashCode
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]
	FROM   [dbo].[Users]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UsersSelect]    Script Date: 12/25/2013 14:48:57 ******/
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

	SELECT [ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode] 
	FROM   [dbo].[Users] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UsersSearch]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersSearch]
       @ID int = null
      ,@Username nvarchar(50)=null
      ,@DisplayName nvarchar(50) = null
      ,@HashCode nvarchar(50) = null
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
    (Users.DisplayName LIKE '%'+@DisplayName+'%' OR @DisplayName IS NULL) AND
    (Users.HashCode LIKE '%'+@HashCode+'%' OR @HashCode IS NULL) AND
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
/****** Object:  StoredProcedure [dbo].[UsersInsert]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UsersInsert] 
    @Username nvarchar(50)=null,
    @DisplayName nvarchar(50)=null,
    @ProfileImageLink nvarchar(MAX)=null,
    @DateofBirth datetime=null,
    @Gender int=null,
    @Country int=null,
    @Language int=null,
    @Password nvarchar(MAX)=null,
    @LastLogin datetime=null,
    @Status int=null,
    @SecretQuestion int=null,
    @SecretAnswer nvarchar(200)=null,
    @HashCode nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Users] ([Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode])
	SELECT @Username, @DisplayName, @ProfileImageLink, @DateofBirth, @Gender, @Country, @Language, @Password, @LastLogin, @Status, @SecretQuestion, @SecretAnswer, @HashCode
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [Username], [DisplayName], [ProfileImageLink], [DateofBirth], [Gender], [Country], [Language], [Password], [LastLogin], [Status], [SecretQuestion], [SecretAnswer], [HashCode]
	FROM   [dbo].[Users]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UserPaymentsUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UserPaymentsSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UserPaymentsInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UserPaymentsDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateDoctorStatus]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[TherapistUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
    @Phone nvarchar(50),
    @Language int= null,
    @HashCode nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Therapist]
	SET    [FirstName] = @FirstName, [LastName] = @LastName, [ProfileImageLink] = @ProfileImageLink, [Title] = @Title, [Bio] = @Bio, [TotalSession] = @TotalSession, [TotalScore] = @TotalScore, [CostPercentage] = @CostPercentage, [Username] = @Username, [Password] = @Password, [status] = @status, [LastLogin] = @LastLogin, [sessionInfo] = @sessionInfo, [SP1] = @SP1, [SP2] = @SP2, [SP3] = @SP3, [Phone] = @Phone,[Language] = @Language,[HashCode]=@HashCode
	WHERE  [ID] = @ID
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone],[Language],[HashCode]
	FROM   [dbo].[Therapist]
	WHERE  [ID] = @ID	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistSelect]    Script Date: 12/25/2013 14:48:57 ******/
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

	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone],[Language],[HashCode]
	FROM   [dbo].[Therapist] 
	WHERE  ([ID] = @ID OR @ID IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistSearch]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TherapistSearch]
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
      ,@Lang int=null
      ,@HashCode nvarchar(50) = null
    AS
    BEGIN
    SELECT * FROM Therapist 
    WHERE 
    (Therapist.ID=@ID OR @ID IS NULL) AND
    (Therapist.SP1 = @SP1 or @SP1 is null) AND
    (Therapist.SP2 = @SP2 or @SP2 is null) AND
    (Therapist.SP3 = @SP3 or @SP3 is null) AND
    (Therapist.Phone = @Phone or @Phone is null)AND
    (Therapist.Language = @Lang or @Lang is null)AND
    (Therapist.FirstName like @FirstName OR @FirstName IS NULL) AND
    (Therapist.LastName like @LastName OR @LastName IS NULL) AND
    (Therapist.ProfileImageLink=@ProfileImageLink OR @ProfileImageLink IS NULL) AND
    (Therapist.Title LIKE @title OR @title IS NULL) AND
    (Therapist.Bio LIKE @bio OR @bio IS NULL) AND
    (Therapist.TotalScore=@TotalScore OR @TotalScore IS NULL) AND
    (Therapist.Username=@Username OR @Username IS NULL) AND
    (Therapist.Password=@Password OR @Password IS NULL) AND
    (Therapist.TotalSession=@TotalSessions OR @TotalSessions IS NULL) AND
    (Therapist.CostPercentage=@CostPercentage OR @CostPercentage IS NULL)AND
    (Therapist.status=@Status OR @Status IS NULL)AND
    (Therapist.HashCode=@HashCode OR @HashCode IS NULL)
    
    RETURN
    
    END
GO
/****** Object:  StoredProcedure [dbo].[TherapistInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
    @Phone nvarchar(50)=null,
    @Language int=null,
    @HashCode nvarchar(50) =null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Therapist] ([FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone],[Language],[HashCode])
	SELECT @FirstName, @LastName, @ProfileImageLink, @Title, @Bio, @TotalSession, @TotalScore, @CostPercentage, @Username, @Password, @status, @LastLogin, @sessionInfo, @SP1, @SP2, @SP3, @Phone,@Language,@HashCode
	
	-- Begin Return Select <- do not remove
	SELECT [ID], [FirstName], [LastName], [ProfileImageLink], [Title], [Bio], [TotalSession], [TotalScore], [CostPercentage], [Username], [Password], [status], [LastLogin], [sessionInfo], [SP1], [SP2], [SP3], [Phone],[Language],[HashCode]
	FROM   [dbo].[Therapist]
	WHERE  [ID] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[TherapistDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SystemAccountsCustomSearch]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SystemAccountsCustomSearch]

@Username nvarchar(50) 
,@Password nvarchar(max)
as 
select * from SystemAccounts
where 
(Username=@Username) and 
(Password=@Password)
GO
/****** Object:  StoredProcedure [dbo].[SessionUserUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionUserSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionUserSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionUserInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionUserDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionsUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionsSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionsSearch]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SessionsSearch]
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
GO
/****** Object:  StoredProcedure [dbo].[SessionsInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionsDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionRatesUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionRatesSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionRatesInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SessionRatesDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectByID]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectAllUsers]
as
select * from Users
GO
/****** Object:  StoredProcedure [dbo].[SelectAllSessions]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectAllDoctors]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectAllDoctors]
as
select * from Therapist
GO
/****** Object:  StoredProcedure [dbo].[LookupsUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[LookupsSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[LookupsSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[LookupsInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[LookupsDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[KnowledgeBaseDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLastResSession]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLastCreatedSession]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetLastCreatedSession]
@DocID int= null
as
select * from Sessions
where ID=(select MAX(ID) from Sessions)and
(therapistID=@DocID)
GO
/****** Object:  StoredProcedure [dbo].[GetFTransByUID]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetFTransByUID] 
@UserID int = null
as
select * from FTrans 
where 
(UserID = @UserID)
GO
/****** Object:  StoredProcedure [dbo].[GetFTransByDate]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetFTransByDate] 
@FromDate datetime = null,
@ToDate Datetime = null
as 
select * from FTrans 
where (DATE between @FromDate And @ToDate)
GO
/****** Object:  StoredProcedure [dbo].[GetFirstFiveDoctors]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFirstFiveDoctors]
as
select top 5 * from Therapist
where 
status = 1
GO
/****** Object:  StoredProcedure [dbo].[GetAllSessions]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllSessions]
as
select * from Sessions
GO
/****** Object:  StoredProcedure [dbo].[GetAllBlogs]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
creATE procedure [dbo].[GetAllBlogs]
as
select * from KnowledgeBase
GO
/****** Object:  StoredProcedure [dbo].[FTransInsert]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[FTransInsert]
@UserID int = null
,@SessionID int = null
,@Date date = null
,@PaymentInfo nvarchar(max) = null
,@PaymentMethod int = null
,@Amount float = null
As
insert into [dbo].[FTrans] ([UserID],[SessionID],[PaymentMethod],[Amount],[PaymentInfo],[Date])
values (@UserID,@SessionID,@PaymentMethod,@Amount,@PaymentInfo,@Date)
GO
/****** Object:  StoredProcedure [dbo].[FindSessionNow]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindSessionNow]
@FromDate datetime = null,
@ToDate Datetime = null,
@Status int = 6
as
select * from Sessions
where(DATE between @FromDate And @ToDate) And
(Status = @Status)
GO
/****** Object:  StoredProcedure [dbo].[FilterSessions]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[DoctorSpSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[DoctorFilterSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CustomNewFilter]    Script Date: 12/25/2013 14:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CustomNewFilter]
@DID int = null,
@Lang int = null,
@Type int = null,
@Status int = null
as
select * from Sessions 
join
Therapist 
on Therapist.ID = Sessions.TherapistID
where
(Therapist.ID = @DID or @DID is null) And
(Therapist.Language = @Lang or @Lang is null) And
(Sessions.Type = @Type or @Type is null)and
(Sessions.Status = @Status or @Status is null)
GO
/****** Object:  StoredProcedure [dbo].[CertificatesUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CertificatesSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CertificatesSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CertificatesInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CertificatesDelete]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AdvancedUserFilter]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AdvancedDoctorFilter]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AdminSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AccountPermissionsUpdate]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AccountPermissionsSelect]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AccountPermissionsSearch]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AccountPermissionsInsert]    Script Date: 12/25/2013 14:48:57 ******/
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
/****** Object:  StoredProcedure [dbo].[AccountPermissionsDelete]    Script Date: 12/25/2013 14:48:57 ******/
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

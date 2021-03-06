USE [Domain]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/8/2020 3:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Alias] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[ManagerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [EmailId], [Alias], [Type], [Position], [ManagerId]) VALUES (1, N'Amol_123', N'Amol', N'G', N'am@gmail.com', N'Ammu', N'Manager', N'Senior', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [EmailId], [Alias], [Type], [Position], [ManagerId]) VALUES (2, N'Santosh123', N'Santosh', N'Tatireddy', N'san@gmail.com', N'san', N'Client', NULL, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [EmailId], [Alias], [Type], [Position], [ManagerId]) VALUES (3, N'Sanjay43', N'Sanjay', N'Soni', N'san@yahoo.com', N'sunny', N'Manager', N'Junior', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [EmailId], [Alias], [Type], [Position], [ManagerId]) VALUES (4, N'Sowmya67', N'Sowmya', N'Bopiddi', N'sandy@hotmail.com', N'sandy', N'Client', NULL, 3)
SET IDENTITY_INSERT [dbo].[Users] OFF

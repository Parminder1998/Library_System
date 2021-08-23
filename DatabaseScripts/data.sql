INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5f04a3b7-8f02-4f24-aff5-33858d01cfa4', N'admin@library.com', N'ADMIN@LIBRARY.COM', N'admin@library.com', N'ADMIN@LIBRARY.COM', 0, N'AQAAAAEAACcQAAAAEKP4Op0bqDVTlTaIx7QTEmd4iuuUIK5i1kFAvt7QZ0zUcSoymeuHnzH1Gl2JNllMHw==', N'245YOMEQYL6OEELQWESVOS4BHZFOT74J', N'80562006-ecf4-4d2f-ac77-84e08a9d80b0', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Book] ON
INSERT INTO [dbo].[Book] ([Id], [BookName], [Category]) VALUES (1, N'Area 7', 1)
INSERT INTO [dbo].[Book] ([Id], [BookName], [Category]) VALUES (2, N'2001 : A Space Odyssey', 0)
INSERT INTO [dbo].[Book] ([Id], [BookName], [Category]) VALUES (3, N'Jack Reacher', 1)
INSERT INTO [dbo].[Book] ([Id], [BookName], [Category]) VALUES (4, N'The Return of Sherlock Holmes', 2)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Member] ON
INSERT INTO [dbo].[Member] ([Id], [MemberName], [ContactNumber]) VALUES (2, N'Patrick Nelson', N'021345644990')
INSERT INTO [dbo].[Member] ([Id], [MemberName], [ContactNumber]) VALUES (3, N'Greg Samson', N'021299567890')
INSERT INTO [dbo].[Member] ([Id], [MemberName], [ContactNumber]) VALUES (4, N'Samuel Anderson', N'021345655622')
INSERT INTO [dbo].[Member] ([Id], [MemberName], [ContactNumber]) VALUES (5, N'Riche McDonald', N'021279567890')
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[LendingRecord] ON
INSERT INTO [dbo].[LendingRecord] ([Id], [MemberId], [BookId], [ReturnByDate]) VALUES (2, 5, 1, N'2019-11-30 00:00:00')
INSERT INTO [dbo].[LendingRecord] ([Id], [MemberId], [BookId], [ReturnByDate]) VALUES (3, 3, 3, N'2019-11-22 00:00:00')
SET IDENTITY_INSERT [dbo].[LendingRecord] OFF

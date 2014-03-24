CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserName] NVARCHAR(100) NOT NULL UNIQUE, 
    [Password] NVARCHAR(100) NOT NULL, 
    [CreationDate] DATETIME NOT NULL, 
    [Email]  NVARCHAR(120) NOT NULL UNIQUE, 
    [CompanyId] INT NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_Account_ToCompany] FOREIGN KEY ([CompanyId]) REFERENCES Company([CompanyId]), 
    CONSTRAINT [FK_User_ToRoles] FOREIGN KEY (Roleid) REFERENCES roles(roleid)
)

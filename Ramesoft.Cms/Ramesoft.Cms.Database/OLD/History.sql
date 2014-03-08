CREATE TABLE [old].[History]
(
	HistoryId       int primary key identity(1,1),
	UserId         int , 
	CompanyId       int,
	ModuleName     varchar(30) not null,
	PropertyName    varchar(30),
	OldValue        varchar(max),
	NewValue        varchar(max),
	ModificationTime datetime2 not null,
	ModificationType char not null, 
    CONSTRAINT [FK_History_User] FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
	CONSTRAINT [FK_History_Company] FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId)
	)
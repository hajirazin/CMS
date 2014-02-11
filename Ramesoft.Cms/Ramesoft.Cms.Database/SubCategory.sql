CREATE TABLE [dbo].[SubCategory]
(
	SubCategoryId  int primary key identity(1,1),
	SubCategoryName varchar(50) not null,
	CategoryId  int not null unique
	Constraint [FK_SubCategory_Category] foreign key(CategoryId) references category(categoryid)
	)  
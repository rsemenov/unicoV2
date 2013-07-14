USE [unico]
GO

CREATE TABLE [Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] int NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ExternalId] [uniqueidentifier] NOT NULL,
	[CategoryId] int NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] decimal(10,2) NOT NULL,
	[Brand] int NOT NULL,
	[Availability] int NOT NULL,
	[Cartridge] [nvarchar](max) NULL
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Info] [nvarchar](max) NULL
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [CartItems](	
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Count] int NOT NULL
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Orders](	
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ExternalId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[CreatedOn] datetime NOT NULL,
	[ClosedOn] datetime NULL
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Orders] ADD CONSTRAINT [DF_Orders_CreatedOn] DEFAULT (getutcdate()) FOR [CreatedOn];  
  
GO

CREATE TABLE [ProductOrders](
	[ProductOrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Count] [int] NOT NULL,
	[Price] decimal(10,2) NOT NULL, --?????
	[WorkType] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[LastStatusUpdate] datetime NOT NULL
 CONSTRAINT [PK_ProductOrders] PRIMARY KEY CLUSTERED 
(
	[ProductOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Filters](
	[FilterId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceTable] [nvarchar](100) NOT NULL,
	[ReferenceColumn] [nvarchar](100) NOT NULL,
	[Type] [int] NOT NULL,
	[IsAvailable] bit NOT NULL,
 CONSTRAINT [PK_Filters] PRIMARY KEY CLUSTERED 
(
	[FilterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[Reference] [nvarchar](500) NULL,
	[TransactionType] [int] NOT NULL,
	[Amount] decimal(10,2) NOT NULL,
	[CreatedOn] datetime NOT NULL,
 CONSTRAINT [PK_Filters] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Transactions] ADD CONSTRAINT [DF_Transactions_CreatedOn] DEFAULT (getutcdate()) FOR [CreatedOn]; 

USE [unico]
GO

--------------- Accounts --------------------
--USE [unico]
--GO

GO

CREATE TABLE [Accounts](
	[AccountId] [int] identity(1,1) NOT NULL,
	[ExternalId] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](MAX) NOT NULL,
	[Role] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Accounts]
    ADD CONSTRAINT [DF_Accounts_CreatedOn] DEFAULT (getutcdate()) FOR [CreatedOn];
    
GO

CREATE TABLE [Profiles](
	[ProfileId] [int] identity(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[SecondPhone] [nvarchar](20) NULL
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Companies](
	[CompanyId] [int] identity(1,1) NOT NULL,
	[CompanyName] [nvarchar](500) NOT NULL,
	[ContactName] [nvarchar](500) NULL,
	[EDRPOU] [nvarchar](20) NULL,
	[INN] [nvarchar](20) NULL,
	[CertificateNumber] [nvarchar](100) NULL, 
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[SecondPhone] [nvarchar](20) NULL,
	[CreatedOn] [datetime] NOT NULL
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Companies]
    ADD CONSTRAINT [DF_Companies_CreatedOn] DEFAULT (getutcdate()) FOR [CreatedOn];





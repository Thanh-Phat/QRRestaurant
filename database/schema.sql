-- =============================
-- USERS
-- =============================
CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(50) NOT NULL UNIQUE,
	PasswordHash VARCHAR(200) NOT NULL,
	FullName NVARCHAR(100),
	Role VARCHAR(20) CHECK (Role IN ('Kitchen','Cashier','Manager')),
	IsActive BIT DEFAULT 1,
	CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- =============================
-- TABLES
-- =============================
CREATE TABLE Tables (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Status NVARCHAR(20) DEFAULT 'Empty',
	CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- =============================
-- QR CODES
-- =============================
CREATE TABLE QRCodes (
	Id INT PRIMARY KEY IDENTITY,
	TableId INT UNIQUE,
	Url NVARCHAR(255),
	FOREIGN KEY (TableId) REFERENCES Tables(Id)
);
GO

-- =============================
-- CATEGORIES
-- =============================
	CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL
);
GO

-- =============================
-- PRODUCTS
-- =============================
CREATE TABLE Products (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	ImageUrl NVARCHAR(255),
	CategoryId INT,
	IsActive BIT DEFAULT 1,
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

-- =============================
-- ORDERS
-- =============================
	CREATE TABLE Orders (
	Id INT PRIMARY KEY IDENTITY,
	TableId INT NOT NULL,
	UserId INT NULL,
	Status NVARCHAR(20) NOT NULL,
	TotalAmount DECIMAL(10,2) DEFAULT 0,
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (TableId) REFERENCES Tables(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- =============================
-- ORDER ITEMS
-- =============================
CREATE TABLE OrderItems (
	Id INT PRIMARY KEY IDENTITY,
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	Status NVARCHAR(20) DEFAULT 'Pending',
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (OrderId) REFERENCES Orders(Id),
	FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO

-- =============================
-- PAYMENTS
-- =============================
CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	OrderId INT NOT NULL UNIQUE,
	Method NVARCHAR(20), -- COD, BANK
	Status NVARCHAR(20) DEFAULT 'Pending',
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);
GO

-- =============================
-- SHIFTS
-- =============================
CREATE TABLE Shifts (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
	StartTime TIME,
	EndTime TIME
);
GO

-- =============================
-- SHIFT REPORTS
-- =============================
CREATE TABLE ShiftReports (
	Id INT PRIMARY KEY IDENTITY,
	ShiftId INT,
	UserId INT,
	TotalRevenue DECIMAL(10,2),
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (ShiftId) REFERENCES Shifts(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- =============================
-- CHAT SESSIONS
-- =============================
CREATE TABLE ChatSessions (
	Id INT PRIMARY KEY IDENTITY,
	TableId INT,
	Status NVARCHAR(20) DEFAULT 'Active',
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (TableId) REFERENCES Tables(Id)
);
GO

-- =============================
-- CHAT MESSAGES
-- =============================
CREATE TABLE ChatMessages (
	Id INT PRIMARY KEY IDENTITY,
	SessionId INT,
	Message NVARCHAR(MAX),
	IsBot BIT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (SessionId) REFERENCES ChatSessions(Id)
);
GO

-- =============================
-- CHAT CONTEXTS
-- =============================
CREATE TABLE ChatContexts (
	Id INT PRIMARY KEY IDENTITY,
	TableId INT,
	LastProduct NVARCHAR(255),
	UpdatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (TableId) REFERENCES Tables(Id)
);
GO

-- =============================
-- CHAT INTENTS
-- =============================
CREATE TABLE ChatIntents (
	Id INT PRIMARY KEY IDENTITY,
	Keyword NVARCHAR(100),
	Response NVARCHAR(MAX)
);
GO

-- =============================
-- INDEXES (PERFORMANCE)
-- =============================
CREATE INDEX IX_Orders_TableId ON Orders(TableId);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_OrderItems_ProductId ON OrderItems(ProductId);
CREATE INDEX IX_ChatMessages_SessionId ON ChatMessages(SessionId);
GO


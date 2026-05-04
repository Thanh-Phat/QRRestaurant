
- =============================
-- SEED DATA (TEST)
-- =============================
INSERT INTO Tables (Name) VALUES ('Table 1'), ('Table 2'), ('Table 3');

INSERT INTO Categories (Name) VALUES ('Drink'), ('Food');

INSERT INTO Products (Name, Price, CategoryId)
VALUES
('Milk Tea', 20000, 1),
('Coffee', 15000, 1),
('Fried Rice', 30000, 2);

INSERT INTO ChatIntents (Keyword, Response)
VALUES
('cheap', 'You can try lemon tea for 15k'),
('best seller', 'Milk tea and coffee are best sellers');
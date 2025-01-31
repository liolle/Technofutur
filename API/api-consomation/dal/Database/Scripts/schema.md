## Schemas 

#### Task Tables
```sql
CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Pending', 
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT CHK_Task_Status CHECK (Status IN ('Pending', 'In Progress', 'Completed'))
);
```

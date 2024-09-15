CREATE PROCEDURE sp_CreateUser
    @FirstName VARCHAR(100),
    @LastName VARCHAR(100),
    @Email VARCHAR(150),
    @Phone VARCHAR(20)
AS
BEGIN
    INSERT INTO users (first_name, last_name, email, phone)
    VALUES (@FirstName, @LastName, @Email, @Phone);
END


CREATE PROCEDURE sp_GetLast10Users
AS
BEGIN
    SELECT TOP 10 * FROM users ORDER BY user_id DESC;
END

CREATE PROCEDURE sp_UpdateUser
    @UserId INT,
    @FirstName VARCHAR(100),
    @LastName VARCHAR(100),
    @Email VARCHAR(150),
    @Phone VARCHAR(20)
AS
BEGIN
    UPDATE users
    SET first_name = @FirstName, last_name = @LastName, email = @Email, phone = @Phone
    WHERE user_id = @UserId;
END


CREATE PROCEDURE sp_GetDepartments
AS
BEGIN
    SELECT * FROM departments;
END


CREATE PROCEDURE sp_AssignUserToDepartment
    @UserId INT,
    @DepartmentId INT
AS
BEGIN
    DELETE FROM user_department WHERE user_id = @UserId; 
    INSERT INTO user_department (user_id, department_id) VALUES (@UserId, @DepartmentId);
END
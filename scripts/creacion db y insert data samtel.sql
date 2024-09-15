-- 1. CREACION BASE DE DATOS
CREATE DATABASE empresa_usuarios_db;

-- 2. CREACION DE LAS TABLAS
USE empresa_usuarios_db;


CREATE TABLE users (
    user_id INT PRIMARY KEY IDENTITY(1,1),  
    first_name VARCHAR(100) NOT NULL,        
    last_name VARCHAR(100) NOT NULL,         
    email VARCHAR(150) NOT NULL,             
    phone VARCHAR(20)                        
);


CREATE TABLE departments (
    department_id INT PRIMARY KEY IDENTITY(1,1), 
    department_name VARCHAR(100) NOT NULL         
);


CREATE TABLE user_department (
    user_id INT NOT NULL,                         
    department_id INT NOT NULL,                   
    CONSTRAINT fk_user FOREIGN KEY (user_id) REFERENCES users(user_id), 
    CONSTRAINT fk_department FOREIGN KEY (department_id) REFERENCES departments(department_id), 
    PRIMARY KEY (user_id, department_id)          
);

-- 3. INSERTAR DATA
INSERT INTO departments (department_name) VALUES
('Nomina'),                
('Facturacion'),          
('Servicio al Cliente'),  
('Tecnologia'),            
('Recursos Humanos');      


INSERT INTO users (first_name, last_name, email, phone) VALUES
('Carlos', 'Perez', 'carlosp@example.com', '1234567890'),
('Maria', 'Lopez', 'marial@example.com', '1234567891'),
('Luis', 'Gonzalez', 'luisg@example.com', '1234567892'),
('Ana', 'Ramarez', 'anar@example.com', '1234567893'),
('Jose', 'Martinez', 'josem@example.com', '1234567894'),
('Luca', 'Hernandez', 'luciah@example.com', '1234567895'),
('Pedro', 'Torres', 'pedrot@example.com', '1234567896'),
('Sofia', 'Rojas', 'sofiar@example.com', '1234567897'),
('Miguel', 'Vargas', 'miguelv@example.com', '1234567898'),
('Elena', 'Flores', 'elenaf@example.com', '1234567899'),
('Raul', 'Morales', 'raulm@example.com', '1234567800');

INSERT INTO user_department (user_id, department_id) VALUES
(1, 1), 
(2, 2),  
(3, 3),  
(4, 4), 
(5, 5),  
(6, 1),  
(7, 2), 
(8, 3),  
(9, 4),  
(10, 5), 
(11, 1);

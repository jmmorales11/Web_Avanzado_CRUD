
create database DBINSTITUCION ;
USE DBINSTITUCION;

Create table Materia (
id_materia int primary key identity(1,1),
nombre_materia varchar(50),
codigo_curso varchar(50),
);

Create table estudiante (
id_estudiante int primary key identity(1,1),
nombre_estudiante varchar(50),
apellido varchar(50),
cedula_estudiante varchar(50),
fecha_nacimiento date,
id_materia int references Materia(id_materia)
);




Insert into Materia(nombre_materia, codigo_curso)values ('Literatura','L1001');
Insert into Materia(nombre_materia, codigo_curso)values ('Matematicas','Ma002');
Insert into Materia(nombre_materia, codigo_curso)values ('Ingles','In003');
Insert into estudiante values('Jeimy', 'Morales', '1754146676','2002-4-4',1);

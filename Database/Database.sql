﻿--create database TrungTamNgoaiNgu
--go

use TrungTamNgoaiNgu
go

-- Tạo bảng PARENT
CREATE TABLE PARENT (
    ParentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Tạo bảng STUDENT
CREATE TABLE STUDENT (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100),
    DateOfBirth DATE,
    Address NVARCHAR(200),
    ParentID INT,
    CONSTRAINT FK_Student_Parent FOREIGN KEY (ParentID)
        REFERENCES PARENT(ParentID)
);

-- Tạo bảng TEACHER
CREATE TABLE TEACHER (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100),
    Expertise NVARCHAR(100)
);

-- Tạo bảng CLASS
CREATE TABLE CLASS (
    ClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(100) NOT NULL,
    Schedule NVARCHAR(100),
    Location NVARCHAR(100),
    TeacherID INT NOT NULL,
    CONSTRAINT FK_Class_Teacher FOREIGN KEY (TeacherID)
        REFERENCES TEACHER(TeacherID)
);

-- Tạo bảng ENROLLMENT
CREATE TABLE ENROLLMENT (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    ClassID INT NOT NULL,
    RegistrationDate DATE NOT NULL,
    CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentID)
        REFERENCES STUDENT(StudentID),
    CONSTRAINT FK_Enrollment_Class FOREIGN KEY (ClassID)
        REFERENCES CLASS(ClassID)
);

-- Tạo bảng ATTENDANCE
CREATE TABLE ATTENDANCE (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    EnrollmentID INT NOT NULL,
    Date DATE NOT NULL,
    Status NVARCHAR(50),
    CONSTRAINT FK_Attendance_Enrollment FOREIGN KEY (EnrollmentID)
        REFERENCES ENROLLMENT(EnrollmentID)
);

-- Tạo bảng FEEDBACK
CREATE TABLE FEEDBACK (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    EnrollmentID INT NOT NULL,
    TeacherID INT NOT NULL,
    Comments NVARCHAR(MAX),
    Date DATE NOT NULL,
    CONSTRAINT FK_Feedback_Enrollment FOREIGN KEY (EnrollmentID)
        REFERENCES ENROLLMENT(EnrollmentID),
    CONSTRAINT FK_Feedback_Teacher FOREIGN KEY (TeacherID)
        REFERENCES TEACHER(TeacherID)
);

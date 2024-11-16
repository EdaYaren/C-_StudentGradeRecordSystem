
CREATE DATABASE DbNoteRecordingSystem

USE DbNoteRecordingSystem


CREATE TABLE Tbl_Lesson (
    Student_ID SMALLINT PRIMARY KEY IDENTITY(1,1),      
    Student_Number CHAR(4),                        
    Student_Name VARCHAR(15),                      
    Student_Surname VARCHAR(20),                
    Student_Exam1 TINYINT,                         
    Student_Exam2 TINYINT,                         
    Student_Exam3 TINYINT,                         
    Average DECIMAL(18, 2),       
    Situation BIT    -- Durum (1 veya 0 değer alabilir, geçip geçmediğini belirtir)
);


INSERT INTO Tbl_Lesson VALUES 
('1235', 'Ali', 'Yıldız', 75, 81, NULL, NULL, NULL),
('1346', 'Mehmet', 'Çınar', 78, 95, NULL, NULL, NULL),
('1458', 'Ayşe', 'Güneş', 65, 66, NULL, NULL, NULL),
('1785', 'Veysel', 'Çınar', 14, 81, NULL, NULL, NULL),
('1662', 'Eda', 'Kaya', 74, 65, NULL, NULL, NULL),
('1485', 'Furkan', 'İnce', 45, NULL, NULL, NULL, NULL),
('1698', 'Baran', 'Yücedağ', 52, 96, NULL, NULL, NULL),
('1238', 'Yunus', 'Meşe', 36, 28, NULL, NULL, NULL),
('1336', 'Sinem', 'Telli', 78, NULL, NULL, NULL, NULL),
('1782', 'Ömer', 'Öztürk', 25, 36, NULL, NULL, NULL);

SELECT * FROM Tbl_Lesson




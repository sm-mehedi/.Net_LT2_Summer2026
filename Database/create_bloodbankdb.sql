IF DB_ID('BloodBankDB') IS NULL
BEGIN
    CREATE DATABASE BloodBankDB;
END
GO

USE BloodBankDB;
GO

IF OBJECT_ID('dbo.Donation', 'U') IS NOT NULL DROP TABLE dbo.Donation;
IF OBJECT_ID('dbo.Donor', 'U') IS NOT NULL DROP TABLE dbo.Donor;
GO

CREATE TABLE dbo.Donor (
    DonorId           INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName          VARCHAR(100)      NOT NULL,
    BloodGroup        VARCHAR(5)        NOT NULL,
    ContactNo         VARCHAR(20)       NOT NULL,
    City              VARCHAR(50)       NOT NULL,
    LastDonationDate  DATE              NULL
);
GO

CREATE TABLE dbo.Donation (
    DonationId    INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DonorId       INT               NOT NULL,
    DonationDate  DATE              NOT NULL,
    VolumeMl      INT               NOT NULL,
    CampName      VARCHAR(100)      NOT NULL,
    CONSTRAINT FK_Donation_Donor FOREIGN KEY (DonorId)
        REFERENCES dbo.Donor(DonorId)
        ON DELETE CASCADE
);
GO

INSERT INTO dbo.Donor (FullName, BloodGroup, ContactNo, City, LastDonationDate) VALUES
('Rahim Uddin',   'A+',  '01711000001', 'Dhaka',      '2026-05-10'),
('Karim Ahmed',   'O+',  '01711000002', 'Chattogram', '2026-06-15'),
('Fatima Begum',  'B+',  '01711000003', 'Sylhet',     '2026-03-20'),
('Ayesha Khatun', 'AB+', '01711000004', 'Dhaka',      '2026-07-01'),
('Jahangir Alam', 'O-',  '01711000005', 'Khulna',     NULL);
GO

INSERT INTO dbo.Donation (DonorId, DonationDate, VolumeMl, CampName) VALUES
(1, '2026-01-10', 450, 'City Hospital Camp'),
(1, '2026-05-10', 450, 'University Camp'),
(2, '2026-06-15', 500, 'Red Crescent Camp'),
(3, '2026-03-20', 350, 'City Hospital Camp'),
(4, '2026-07-01', 450, 'Community Camp');
GO

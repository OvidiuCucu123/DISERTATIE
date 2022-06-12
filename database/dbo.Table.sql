CREATE TABLE [dbo].[AngajatiTbl]
(
	[AngajatID] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Nume] VARCHAR(50) NOT NULL, 
    [Adresa] VARCHAR(50) NOT NULL, 
    [Telefon] VARCHAR(10) NOT NULL, 
    [DataAngajare] VARCHAR(50) NOT NULL, 
    [Functia] VARCHAR(50) NOT NULL, 
    [Departament] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[EmotionalTone]
(
	EmotionalID varchar(255) NOT NULL PRIMARY KEY,
	Name varchar(255) NOT NULL,
	ID varchar(255) NOT NULL,
	WordCount int NOT NULL,
	NormalizedScore int NOT NULL,
	RawScore float NOT NULL,
	/* TODO: constraint and index needed*/
)
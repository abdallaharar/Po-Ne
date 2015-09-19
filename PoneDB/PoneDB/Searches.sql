CREATE TABLE [dbo].[Searches]
(
	[SearchID] INT NOT NULL PRIMARY KEY,
	SocialID varchar(255) FOREIGN KEY REFERENCES SocialTone(SocialID),
	EmotionalID varchar(255) FOREIGN KEY REFERENCES EmotionalTone(EmotionalID),
	WritingID varchar(255) FOREIGN KEY REFERENCES WritingTone(WritingID)
)


/*CREATE TABLE [dbo].[AudioFiles](  
    [ID] [int] IDENTITY(1,1) NOT NULL,  
    [Name] [nvarchar](50) NULL,  
    [FileSize] [int] NULL,  
    [FilePath] [nvarchar](100) NULL,  
 CONSTRAINT [PK_AudioFiles] PRIMARY KEY CLUSTERED   
(  
    [ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  

CREATE TABLE [dbo].[Ratings](
    [RID] INT IDENTITY(1,1) NOT NULL, 
    [Tension] INT NOT NULL, 
    [Relaxation] INT NOT NULL,
    [Comments] NVARCHAR (MAX),
    [AudioID] INT NOT NULL,
    Constraint [PK_dbo.Ratings] PRIMARY KEY CLUSTERED ([RID] ASC), 
    CONSTRAINT [FK_dbo.Ratings_dbo.AudioFiles_ID] FOREIGN KEY ([AudioID]) REFERENCES [dbo].[AudioFiles] ([ID]) ON DELETE CASCADE


)*/

/*CREATE TABLE [dbo].[Words](
    [WID] INT IDENTITY (1,1) NOT NULL, 
    [Word] NVARCHAR (MAX) NOT NULL, 
    [Type] NVARCHAR (MAX) NOT NULL, 
    [Rating] INT NOT NULL, 
    CONSTRAINT [PK_dbo.Words] PRIMARY KEY CLUSTERED ([WID] ASC)


)*/

INSERT INTO [dbo].[Words] (WORD, TYPE, RATING) VALUES
('about','Preposition', '1'),
('above','Preposition', '1'),
('across','Preposition', '1'),
('after','Preposition', '1'),
('against','Preposition', '1'),
('along','Preposition', '1'),
('among','Preposition', '1'),
('around','Preposition', '1'),
('at','Preposition', '1'),
('before','Preposition', '1'),
('behind','Preposition', '1'),
('below','Preposition', '1'),
('beneath','Preposition', '1'),
('beside','Preposition', '1'),
('between','Preposition', '1'),
('by','Preposition', '1'),
('down','Preposition', '1'),
('during','Preposition', '1'),
('except','Preposition', '1'),
('for','Preposition', '1'),
('from','Preposition', '1'),
('in','Preposition', '1'),
('in front of','Preposition', '1'),
('inside','Preposition', '1'),
('instead of','Preposition', '1'),
('into','Preposition', '1'),
('like','Preposition', '1'),
('near','Preposition', '1'),
('of','Preposition', '1'),
('off','Preposition', '1'),
('on','Preposition', '1'),
('onto','Preposition', '1'),
('on top of','Preposition', '1'),
('out of','Preposition', '1'),
('outside','Preposition', '1'),
('over','Preposition', '1'),
('past','Preposition', '1'),
('since','Preposition', '1'),
('through','Preposition', '1'),
('to','Preposition', '1'),
('toward','Preposition', '1'),
('under','Preposition', '1'),
('underneath','Preposition', '1'),
('until','Preposition', '1'),
('up','Preposition', '1'),
('upon','Preposition', '1'),
('with','Preposition', '1'),
('within','Preposition', '1'),
('without ','Preposition', '1')
  
GO  
  


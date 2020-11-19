CREATE TABLE [dbo].[AudioFiles](  
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


)
  
GO  
  

